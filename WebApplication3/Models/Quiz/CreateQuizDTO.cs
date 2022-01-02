using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WebApplication3.Models.Question;
using WebApplication3.Services.Quiz;

namespace WebApplication3.Models.Quiz
{
    public class CreateQuizDTO : IValidatableObject
    {
        [Required]
        [StringLength(20, ErrorMessage = "La taille du nom est de 20 maximum")]
        public string Name { get; set; }
        public QuizStatus Status { get; set; }
        public IList<CreateQuestionDTO> Questions { get; set; }
        public string Password { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var service = (IQuizService)validationContext.GetService(typeof(IQuizService));
            var existingQuiz = service.getByName(this.Name);
            if (existingQuiz != null)
            {
                yield return new ValidationResult("Ce nom est déjà utilisé", new List<string>() { nameof(this.Name) });
                
            }

            if (this.Password == null || this.Password == "")
            {
                yield return new ValidationResult("Veuillez entrez un mot de passe", new List<string>() { nameof(this.Password) });
            }

            if (this.Questions.Count() != 10)
            {
                yield return new ValidationResult("Un quiz doit contenir 10 questions", new List<string>() { nameof(this.Questions) });
            }

        }
    }
}
