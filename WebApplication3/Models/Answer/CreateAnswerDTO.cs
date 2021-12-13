using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication3.Models.Answer
{
    public class CreateAnswerDTO
    {
        public string Text { get; set; }

        public bool IsCorrect { get; set; }

        public Guid QuestionId { get; set; }
    }
}
