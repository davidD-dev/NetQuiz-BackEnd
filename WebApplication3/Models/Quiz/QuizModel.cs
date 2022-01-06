using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WebApplication3.Context;
using WebApplication3.Services.Quiz;
using WebApplication3.Models.Question;
using System.Diagnostics;
using BCryptNet = BCrypt.Net.BCrypt;
using WebApplication3.Models.Score;

namespace WebApplication3.Models.Quiz

{
    public class QuizModel : EntityWithId
    {
        
        public string Name { get; set; }

        public ICollection<QuestionModel> Questions { get; set; }

        public QuizStatus Status { get; set; }

        public ICollection<ScoreModel> Scores { get; set; }

        public int Rate { get; set; }
        
        public int NumberOfVote { get; set; }

        public string Password { get; set; }


    }
}
