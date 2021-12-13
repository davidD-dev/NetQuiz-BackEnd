using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication3.Models.Score
{
    public class CreateScoreDTO
    {
        public string UserName { get; set; }
        public int Score { get; set; }

        public Guid QuizId { get; set; }
    }
}
