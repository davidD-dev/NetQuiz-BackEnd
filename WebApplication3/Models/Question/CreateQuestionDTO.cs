using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication3.Models.Answer;

namespace WebApplication3.Models.Question
{
    public class CreateQuestionDTO
    {
        public string Text { get; set; }

        public IList<CreateAnswerDTO> Answers { get; set; }

        public QuestionTypes Type { get; set; }

        public Guid QuizId { get; set; }
    }
}
