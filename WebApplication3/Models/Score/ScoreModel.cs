using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication3.Context;
using WebApplication3.Models.Quiz;

namespace WebApplication3.Models.Score
{
    public class ScoreModel : EntityWithId
    {
        public string UserName { get; set; }
        public int Score { get; set; }

        public Guid QuizId { get; set; }

        public QuizModel Quiz { get; set; }


    }
}
