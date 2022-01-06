using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using WebApplication3.Context;
using WebApplication3.Models.Answer;
using WebApplication3.Models.Quiz;

namespace WebApplication3.Models.Question
{
    public class GetQuestionDTO : EntityWithId
    {
        public string Text { get; set; }

        public IList<GetAnswerDTO> Answers { get; set; }

        public QuestionTypes Type { get; set; }

        [JsonIgnore]
        public Guid QuizId { get; set; }
        [JsonIgnore]
        public GetQuizDTO Quiz { get; set; }
    }
}
