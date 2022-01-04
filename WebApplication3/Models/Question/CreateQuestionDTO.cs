using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WebApplication3.Models.Answer;
using WebApplication3.Services.Question;
using WebApplication3.Services.Quiz;

namespace WebApplication3.Models.Question
{
    public class CreateQuestionDTO : IValidatableObject
    {
        public string Text { get; set; }

        public IList<CreateAnswerDTO> Answers { get; set; }

        public QuestionTypes Type { get; set; }

        public Guid QuizId { get; set; }
        
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var service = (IQuestionService)validationContext.GetService(typeof(IQuestionService));
            List<bool> correctAnswer = Answers.Where(x => x.IsCorrect).Select(x => x.IsCorrect).ToList();

            Console.WriteLine(correctAnswer);
            if (this.Type == QuestionTypes.MultipleAnswer)
            {
                if (correctAnswer.Count() < 2)
                {
                    yield return new ValidationResult("Une question à choix multiples doit avoir au moins 2 bonnes réponse", new List<string>() { nameof(this.Answers) });
                }

            }
            
            if (this.Type == QuestionTypes.UniqueAnswer)
            {
                if (correctAnswer.Count() != 1)
                {
                    yield return new ValidationResult("Une question à choix unique doit avoir une seule bonnes réponse", new List<string>() { nameof(this.Answers) });
                }

            }
        }
    }
}
