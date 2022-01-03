using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using WebApplication3.Context;
using WebApplication3.Models.Answer;
using WebApplication3.Models.Quiz;

namespace WebApplication3.Models.Question
{
    public class QuestionModel : EntityWithId, IValidatableObject
    {
        [Required]
        public string Text { get; set; }
        
        [Required]
        public ICollection<AnswerModel> Answers { get; set; }
        
        [Required]
        public QuestionTypes Type { get; set; }

        [JsonIgnore]
        public Guid QuizId { get; set; }
        [JsonIgnore]
        public QuizModel Quiz { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {

            // A multiple choices question must have at least one correct answer
            if (this.Type == QuestionTypes.MultipleAnswer)
            {
                if (this._getNbRightAnswers() < 1)
                {
                    yield return new ValidationResult("Une question a choix multiple doit avoir au moins une réponse correct", new List<string>() { nameof(this.Answers) });
                }
            }

            // A classical question must have only one correct answer
            if (this.Type == QuestionTypes.UniqueAnswer)
            {
                if (this._getNbRightAnswers() != 1)
                {
                    yield return new ValidationResult("Une question classque ne peut avoir qu'une seule réponse correct", new List<string>() { nameof(this.Answers) });

                }
            }
        }

        private int _getNbRightAnswers ()
        {
           return this.Answers.Where(answer => answer.IsCorrect == true).Count();
        }
    }
}
