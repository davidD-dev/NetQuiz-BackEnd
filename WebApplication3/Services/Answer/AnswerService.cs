using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication3.Models.Answer;
using WebApplication3.Repository.Answer;

namespace WebApplication3.Services.Answer
{
    public class AnswerService : IAnswerService
    {

        private IAnswerRepository _repository;

        public AnswerService(IAnswerRepository repository)
        {
            this._repository = repository;
        }
        public List<GetAnswerDTO> GetCorrectAnswerByQuestionId(Guid questionId)
        {
            return this._repository.GetCorrectAnswerByQuestionId(questionId);
        }
    }
}
