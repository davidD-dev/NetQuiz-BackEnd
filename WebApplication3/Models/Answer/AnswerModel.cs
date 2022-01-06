using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using WebApplication3.Context;
using WebApplication3.Models.Question;

namespace WebApplication3.Models.Answer
{
    public class AnswerModel : EntityWithId
    {
        [Required]
        public string Text { get; set; }

        [Required]
        public bool IsCorrect { get; set; }

        [JsonIgnore]
        public Guid QuestionId { get; set; }

        [JsonIgnore]
        // Private allow us to ignore this property during our GetAll
        public QuestionModel Question { get; set; }


    }
}
