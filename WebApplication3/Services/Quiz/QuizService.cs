using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using WebApplication3.Context;
using WebApplication3.Repository.Quiz;
using WebApplication3.Services;
using WebApplication3.Models.Quiz;
using BCryptNet = BCrypt.Net.BCrypt;
using AutoMapper;
using WebApplication3.Models.Question;

namespace WebApplication3.Services.Quiz
{
    public class QuizService : IQuizService
    {

        private readonly IQuizRepository _repository;
        private readonly IMapper _mapper;

        public QuizService(IQuizRepository repository, IMapper mapper)
        {
            this._repository = repository;
            this._mapper = mapper;
        }

        public List<GetAllQuizDTO> getAll()
        {
            return this._repository.GetAll();
        }

        public List<GetAllQuizDTO> GetDraftQuizzes()
        {
            return this._repository.GetDraftQuizzes();
        }
        
        public List<GetAllQuizDTO> GetPublishQuizzes()
        {
            return this._repository.GetPublishQuizzes();
        }

        public GetQuizDTO getById(Guid id)
        {
            return this._repository.GetById(id);
        }

        public QuizModel getByName(string name)
        {
            return this._repository.getByName(name);
        }

        public List<KeyValuePair<string, int>> GetStatus()
        {
            var status =  QuizStatus.GetValues(typeof(QuizStatus)).Cast<QuizStatus>().ToList();
            List<KeyValuePair<string, int>> statusDescriptions = status.Select(x => new KeyValuePair<string, int>(x.GetDescription(), (int)x)).ToList();
            return statusDescriptions;
            
        }

        public void Delete(Guid id)
        {
            this._repository.Delete(id);
            this.Save();
        }

        public void Insert(CreateQuizDTO quiz)
        {
            string passwordHash = BCryptNet.HashPassword(quiz.Password, BCryptNet.GenerateSalt(12));
            quiz.Password = passwordHash;


            QuizModel model = this._mapper.Map<QuizModel>(quiz);
            model.Rate = 0;
            model.Status = QuizStatus.Draft;
            this._repository.Insert(model);
            this.Save();
        }

        public int Update(Guid id, UpdateQuizDTO quiz)
        {
            var quizDbDTO = this._repository.GetByIdModel(id);
            var quizDbPassword = this._repository.GetByIdWithoutTracking(id);
            
            if (quizDbPassword != null)
            {
                if (quizDbPassword.Status != QuizStatus.Draft)
                {
                    return 0;
                }
                bool verified = BCryptNet.Verify(quiz.Password, quizDbPassword.Password);
                if (verified)
                {

                    quiz.Password = quizDbPassword.Password;
                    QuizModel model = this._mapper.Map<QuizModel>(quiz);
                    //QuizModel quizdbModel = this._mapper.Map<QuizModel>(quizDbDTO);
                    
                    this._mapper.Map<QuizModel, QuizModel>(model, quizDbDTO);
                    //quizdbModel.Id = id;

                    this._repository.Update(quizDbDTO);
                    return this.Save();
                } else
                {
                    return -1;
                }
            }
            return 0;

        }

        public int Publish(Guid id)
        {
            QuizModel existing = this._repository.GetByIdWithoutTracking(id);
            if (existing != null)
            {
                if (existing.Status != QuizStatus.Draft)
                {
                    return 0;
                }
                else
                {
                    //QuizModel model = this._mapper.Map<QuizModel>(existing);
                    existing.Status = QuizStatus.Published;
                    this._repository.Update(existing);
                    return this.Save();
                }
            }
            return 0;

        }

        public int Save()
        {
            return this._repository.Save();
        }

        private void trueFalseQuestion()
        {

        }
    }
}
