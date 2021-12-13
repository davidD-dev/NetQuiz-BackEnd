using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Linq;
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

        public Guid QuizId { get; set; }
        public QuizModel Quiz { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {

            // A question must have 4 answer possible, exepte for the question with the text area and the True or False question
            if (this.Type != QuestionTypes.TextAnswer && this.Type != QuestionTypes.TrueFalse)
            {
                if (this.Answers.Count() != 4)
                {
                    Debug.WriteLine(this.Type);
                    yield return new ValidationResult("Une question doit avoir 4 propositions de réponse", new List<string>() { nameof(this.Answers) });

                }
            }

            // A multiple choices question must have at least one correct answer
            if (this.Type == QuestionTypes.MultipleAnswer)
            {
                if (this._getNbRightAnswers() < 1)
                {
                    yield return new ValidationResult("Une question a choix multiple doit avoir au moins une réponse correct", new List<string>() { nameof(this.Answers) });
                }
            }

            // A classical question must have only one correct answer
            if (this.Type == QuestionTypes.SingleAnswer)
            {
                if (this._getNbRightAnswers() != 1)
                {
                    yield return new ValidationResult("Une question classque ne peut avoir qu'une seule réponse correct", new List<string>() { nameof(this.Answers) });

                }
            }

            // A True or False quesiton must have 2 possible answer and only one correct
            if (this.Type == QuestionTypes.TrueFalse)
            {
                if (this._getNbRightAnswers() != 1)
                {
                    yield return new ValidationResult("Une question Vrai / Faux ne peut avoir qu'une seule réponse correct", new List<string>() { nameof(this.Answers) });
                }

                if (this.Answers.Count() != 2)
                {
                    yield return new ValidationResult("Une question Vrai / Faux ne peut avoir que 2 réponses possible", new List<string>() { nameof(this.Answers) });
                }
            }
        }

        private int _getNbRightAnswers ()
        {
           return this.Answers.Where(answer => answer.IsCorrect == true).Count();
        }
    }
}
