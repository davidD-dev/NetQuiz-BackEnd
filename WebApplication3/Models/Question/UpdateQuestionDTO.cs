using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using WebApplication3.Context;
using WebApplication3.Models.Answer;
using WebApplication3.Models.Quiz;

namespace WebApplication3.Models.Question
{
    public class UpdateQuestionDTO : EntityWithId
    {
        public string Text { get; set; }

        public IList<UpdateAnswerDTO> Answers { get; set; }

        public QuestionTypes Type { get; set; }
        
        [JsonIgnore]
        public Guid QuizId { get; set; }
        
        [JsonIgnore]
        public UpdateQuizDTO Quiz { get; set; }
        
    }
}