using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication3.Context;
using WebApplication3.Models.Answer;
using WebApplication3.Models.Question;
using WebApplication3.Models.Quiz;

namespace WebApplication3.Repository.Question
{
    public class QuestionRepository : CrudRepository<QuestionModel>, IQuestionRepository
    {

        private AppDbContext _context = null;
        private DbSet<QuizModel> QuizTable = null;
        private DbSet<QuestionModel> QuestionTable = null;
        private DbSet<AnswerModel> AnswerTable = null;
        public QuestionRepository(AppDbContext context) : base(context)
        {
            this._context = context;
            QuizTable = context.Set<QuizModel>();
            QuestionTable = context.Set<QuestionModel>();
            AnswerTable = context.Set<AnswerModel>();
        }

        public IEnumerable<GetQuestionDTO> GetByQuiz(Guid idQuiz)
        {
            IQueryable<QuestionModel> preQuery = QuestionTable.Where(x => x.QuizId == idQuiz);


            return GetQuestionRequest(preQuery).ToList();
        }

        public QuestionModel GetByIdWithoutTracking(Guid id)
        {
            IQueryable<QuestionModel> result = QuestionTable.Where(x => x.Id == id).AsNoTracking();

            return result.FirstOrDefault();
        }

        private IQueryable<GetQuestionDTO> GetQuestionRequest(IQueryable<QuestionModel> query)
        {
            return query.Select(questionElement => new GetQuestionDTO
            {
                Id = questionElement.Id,
                Text = questionElement.Text,
                Type = questionElement.Type,
                QuizId = questionElement.QuizId,
                Answers = AnswerTable.Where(answer => questionElement.Id == answer.QuestionId).Select(answerElement => new GetAnswerDTO
                {
                    Id = answerElement.Id,
                    Text = answerElement.Text,
                    IsCorrect = answerElement.IsCorrect
                }
                    ).ToList()
            }).AsNoTracking();
        }
    }
}
