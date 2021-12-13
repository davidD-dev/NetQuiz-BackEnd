using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication3.Models.Answer;
using WebApplication3.Models.Question;
using WebApplication3.Models.Quiz;

namespace WebApplication3.Context
{
    public class AppDbContext : DbContext
    {
        public DbSet<QuizModel> Quiz { get; set; }

        public DbSet<QuestionModel> Question { get; set; }

        public DbSet<AnswerModel> Answer { get; set; }

        public AppDbContext() 
        {

        }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
    }
}
