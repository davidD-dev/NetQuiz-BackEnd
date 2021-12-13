using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication3.Models.Question;

namespace WebApplication3.Models.Quiz
{
    public class UpdateQuizFormatedDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public QuizStatus Status { get; set; }
        public IList<CreateQuestionDTO> Questions { get; set; }
    }
}
