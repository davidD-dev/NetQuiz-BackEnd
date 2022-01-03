using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication3.Context;
using WebApplication3.Models.Quiz;
using WebApplication3.Repository;

namespace WebApplication3.Repository.Quiz
{
    public interface IQuizRepository : ICrudRepository<QuizModel>
    {
        public QuizModel getByName(string name);

        public new QuizModel GetByIdModel(Guid id);

        // Key word new offer possibility to mask the GetAll function inherit from ICrudRepository
        public new List<GetAllQuizDTO> GetAll();

        public new GetQuizDTO GetById(Guid id);

        // Return the quiz that match id without tracking the model
        public QuizModel GetByIdWithoutTracking(Guid id);

        // Return Quizzes wiches in draft state
        public List<GetAllQuizDTO> GetDraftQuizzes();
        
        // Return Quizzes published
        public List<GetAllQuizDTO> GetPublishQuizzes();
        

    }
}
