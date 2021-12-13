using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication3.Models.Quiz
{
    public class GetAllQuizDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public QuizStatus Status { get; set; }
        public int Rate { get; set; }
    }
}
