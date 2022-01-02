using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication3.Context;
using WebApplication3.Models.Quiz;

namespace WebApplication3.Services.Quiz
{
    public interface IQuizService
    {
        IEnumerable<GetAllQuizDTO> getAll();

        QuizModel getByName(string name);

        GetQuizDTO getById(Guid id);

        void Insert(CreateQuizDTO quiz);

        void Delete(Guid id);

        int Save();

        int Update(UpdateQuizDTO quiz);

        List<KeyValuePair<string, int>> GetStatus();

    }
}
