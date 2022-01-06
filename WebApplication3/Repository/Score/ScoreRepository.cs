using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication3.Context;
using WebApplication3.Models.Answer;
using WebApplication3.Models.Question;
using WebApplication3.Models.Quiz;
using WebApplication3.Models.Score;

namespace WebApplication3.Repository.Score
{
    public class ScoreRepository : CrudRepository<ScoreModel>, IScoreRepository
    {
        private AppDbContext _context = null;
        private DbSet<QuizModel> QuizTable = null;
        private DbSet<QuestionModel> QuestionTable = null;
        private DbSet<AnswerModel> AnswerTable = null;
        private DbSet<ScoreModel> ScoreTable = null;
        public ScoreRepository(AppDbContext context) : base(context)
        {
            this._context = context;
            QuizTable = context.Set<QuizModel>();
            QuestionTable = context.Set<QuestionModel>();
            AnswerTable = context.Set<AnswerModel>();
            ScoreTable = context.Set<ScoreModel>();
        }

        public List<GetScoreDTO> GetScoreByQuizId(Guid quizId)
        {
            var preQuery = ScoreTable.Where(score => score.QuizId == quizId).OrderByDescending(s => s.Score);
            return GetScoreRequest(preQuery).ToList();
        }

        private static IQueryable<GetScoreDTO> GetScoreRequest(IQueryable<ScoreModel> query)
        {
            return query.Select(score => new GetScoreDTO
            {
                Id = score.Id,
                UserName = score.UserName,
                Score = score.Score,
                QuizId = score.QuizId
            }).AsNoTracking();
        }
    }
}
