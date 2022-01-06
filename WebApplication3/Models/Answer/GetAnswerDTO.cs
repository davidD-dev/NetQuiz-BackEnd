using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using WebApplication3.Context;
using WebApplication3.Models.Question;

namespace WebApplication3.Models.Answer
{
    public class GetAnswerDTO : EntityWithId
    {
        public string Text { get; set; }
        
        public bool? IsCorrect { get; set; }
        
        [JsonIgnore]
        public Guid QuizId { get; set; }
        [JsonIgnore]
        public GetQuestionDTO Quiz { get; set; }
    }
}
