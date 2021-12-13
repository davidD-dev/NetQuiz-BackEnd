using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication3.Models.Answer;

namespace WebApplication3.Services.Answer
{
    public interface IAnswerService
    {
        public List<GetAnswerDTO> GetCorrectAnswerByQuestionId(Guid questionId);
    }
}
