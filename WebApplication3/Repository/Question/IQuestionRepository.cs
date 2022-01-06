using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication3.Models.Question;

namespace WebApplication3.Repository.Question
{
    public interface IQuestionRepository : ICrudRepository<QuestionModel>
    {
    }
}
