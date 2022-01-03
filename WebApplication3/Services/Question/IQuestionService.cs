using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication3.Models.Question;

namespace WebApplication3.Services.Question
{
    public interface IQuestionService
    {
        IEnumerable<GetQuestionDTO> GetByQuiz(Guid idQuiz);

        List<QuestionModel> GetAll();

        void Insert(QuestionModel quiz);

        void Delete(Guid id);

        int Save();

        int Update(QuestionModel quiz);

        List<KeyValuePair<string, int>> GetAllTypes();
    }
}
