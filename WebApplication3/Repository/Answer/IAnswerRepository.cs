using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication3.Models.Answer;

namespace WebApplication3.Repository.Answer
{
    public interface IAnswerRepository : ICrudRepository<AnswerModel>
    {
        public List<GetAnswerDTO> GetCorrectAnswerByQuestionId(Guid questionId);
    }
}
