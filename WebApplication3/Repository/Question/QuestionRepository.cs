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







    }
}
