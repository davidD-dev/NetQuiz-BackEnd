using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication3.Context;
using WebApplication3.Models.Answer;
using WebApplication3.Models.Question;
using WebApplication3.Models.Quiz;

namespace WebApplication3.Repository.Answer
{
    public class AnswerRepository : CrudRepository<AnswerModel>, IAnswerRepository
    {
        private AppDbContext _context = null;
        private DbSet<QuizModel> QuizTable = null;
        private DbSet<QuestionModel> QuestionTable = null;
        private DbSet<AnswerModel> AnswerTable = null;
        public AnswerRepository(AppDbContext context) : base(context)
        {
            this._context = context;
            QuizTable = context.Set<QuizModel>();
            QuestionTable = context.Set<QuestionModel>();
            AnswerTable = context.Set<AnswerModel>();
        }

        public List<GetAnswerDTO> GetCorrectAnswerByQuestionId(Guid questionId)
        {
            var preQuery = AnswerTable.Where(answer => answer.QuestionId == questionId).Where(answer => answer.IsCorrect == true);
            return GetQuestionRequest(preQuery).ToList();
        }

        private static IQueryable<GetAnswerDTO> GetQuestionRequest(IQueryable<AnswerModel> query)
        {
            return query.Select(answerElement => new  GetAnswerDTO
                    {
                        Id = answerElement.Id,
                        Text = answerElement.Text,
                    })
            .AsNoTracking();
        }


    }
}
