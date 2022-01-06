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
        List<GetAllQuizDTO> getAll();

        List<GetAllQuizDTO> GetDraftQuizzes();
        
        List<GetAllQuizDTO> GetPublishQuizzes();

        QuizModel getByName(string name);

        GetQuizDTO getById(Guid id);

        int Rate(Guid id, int rate);

        void Insert(CreateQuizDTO quiz);

        void Delete(Guid id);
        

        int Update(Guid id, UpdateQuizDTO quiz);

        int Publish(Guid id);
        

        GetQuizDTO CheckAccess(Guid id, string password);

    }
}
