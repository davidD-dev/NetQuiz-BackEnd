using System;
using System.Text.Json.Serialization;
using WebApplication3.Context;
using WebApplication3.Models.Question;

namespace WebApplication3.Models.Answer
{
    public class UpdateAnswerDTO : EntityWithId
    {
        public string Text { get; set; }

        public bool IsCorrect { get; set; }
        
        [JsonIgnore]
        public Guid QuestionId { get; set; }
        
        [JsonIgnore]
        public UpdateQuestionDTO Question { get; set; }
    }
}