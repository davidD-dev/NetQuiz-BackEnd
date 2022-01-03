using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication3.Context;
using WebApplication3.Repository;
using WebApplication3.Models.Quiz;
using WebApplication3.Models.Question;
using WebApplication3.Models.Answer;

namespace WebApplication3.Repository.Quiz
{
    public class QuizRepository : CrudRepository<QuizModel>, IQuizRepository
    {

        private AppDbContext _context = null;
        private DbSet<QuizModel> QuizTable = null;
        private DbSet<QuestionModel> QuestionTable = null;
        private DbSet<AnswerModel> AnswerTable = null;
        public QuizRepository(AppDbContext context) : base(context)
        {
            this._context = context;
            QuizTable = context.Set<QuizModel>();
            QuestionTable = context.Set<QuestionModel>();
            AnswerTable = context.Set<AnswerModel>();
        }

        public new List<GetAllQuizDTO> GetAll()
        {
            var preQuery = QuizTable.AsQueryable();
            return GetAllQuizRequest(preQuery).ToList();

        }

        public QuizModel getByName(string name)
        {
            IQueryable<QuizModel> elements = QuizTable.Where(x => x.Name == name);
            return elements.Count() > 0 ? elements.First() : null;
        }

        public new GetQuizDTO GetById(Guid id)
        {
            var preQuery = QuizTable.Where(quiz => quiz.Id == id).AsNoTracking();

            return GetQuizRequest(preQuery).FirstOrDefault();
        }

        public QuizModel GetByIdWithoutTracking(Guid id)
        {
            IQueryable<QuizModel> elements = QuizTable.Where(x => x.Id == id).AsNoTracking();

            return elements.FirstOrDefault();
        }

        public List<GetAllQuizDTO> GetDraftQuizzes()
        {
            var preQuery = QuizTable.Where(quiz => quiz.Status == QuizStatus.Draft);
            return GetAllQuizRequest(preQuery).ToList();
        }
        
        public List<GetAllQuizDTO> GetPublishQuizzes()
        {
            var preQuery = QuizTable.Where(quiz => quiz.Status == QuizStatus.Published);
            return GetAllQuizRequest(preQuery).ToList();
        }

        private IQueryable<GetQuizDTO> GetQuizRequest(IQueryable<QuizModel> query)
        {
            return query.Select(quiz => new GetQuizDTO
            {
                Id = quiz.Id,
                Name = quiz.Name,
                Status = quiz.Status,
                Rate = quiz.Rate,
                Questions = QuestionTable.Where(question => quiz.Id == question.QuizId).Select(questionElement => new GetQuestionDTO
                {
                    Id = questionElement.Id,
                    Text = questionElement.Text,
                    Type = questionElement.Type,
                    QuizId = questionElement.QuizId,
                    Answers = AnswerTable.Where(answer => questionElement.Id == answer.QuestionId).Select(answerElement => new GetAnswerDTO
                    {
                        Id = answerElement.Id,
                        Text = answerElement.Text,
                    }
                        ).ToList()
                }).ToList()
            }).AsNoTracking();
        }
        private IQueryable<GetAllQuizDTO> GetAllQuizRequest(IQueryable<QuizModel> query)
        {
            return query.Select(quiz => new GetAllQuizDTO
            {
                Id = quiz.Id,
                Name = quiz.Name,
                Status = quiz.Status,
                Rate = quiz.Rate
            }).AsNoTracking();
        }

    }
}
