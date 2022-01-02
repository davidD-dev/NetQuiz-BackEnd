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

        private IQuizRepository _repository;
        private readonly IMapper _mapper;

        public QuizService(IQuizRepository repository, IMapper mapper)
        {
            this._repository = repository;
            this._mapper = mapper;
        }

        public IEnumerable<GetAllQuizDTO> getAll()
        {
            return this._repository.GetAll();
        }

        public GetQuizDTO getById(Guid id)
        {
            return this._repository.GetById(id);
        }

        public QuizModel getByName(string name)
        {
            return this._repository.getByName(name);
        }

        public List<string> GetStatus()
        {
            var status =  QuizStatus.GetValues(typeof(QuizStatus)).Cast<QuizStatus>().ToList();
            List<string> statusDescriptions = status.Select(x => x.GetDescription()).ToList();
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
            quiz.Status = QuizStatus.Draft;


            QuizModel model = this._mapper.Map<QuizModel>(quiz);
            model.Rate = 0;
            this._repository.Insert(model);
            this.Save();
        }

        public int Update(UpdateQuizDTO quiz)
        {
            QuizModel existing = this._repository.GetByIdWithoutTracking(quiz.Id);
            if (existing != null)
            {
                if (existing.Status != QuizStatus.Draft)
                {
                    return 0;
                }
                bool verified = BCryptNet.Verify(quiz.Password, existing.Password);
                if (verified)
                {

                    quiz.Password = existing.Password;
                    QuizModel model = this._mapper.Map<QuizModel>(quiz);
                    this._repository.Update(model);
                    return this.Save();
                } else
                {
                    return -1;
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
