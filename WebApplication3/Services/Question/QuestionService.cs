using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication3.Models.Question;
using WebApplication3.Repository.Question;

namespace WebApplication3.Services.Question
{
    public class QuestionService : IQuestionService
    {
        private IQuestionRepository _repository;
        private QuestionTypes _questionTypes;

        public QuestionService(IQuestionRepository repository)
        {
            this._repository = repository;
            this._questionTypes = new QuestionTypes();
        }

        public IEnumerable<GetQuestionDTO> GetByQuiz(Guid idQuiz)
        {
            return this._repository.GetByQuiz(idQuiz);
        }

        public List<KeyValuePair<string, int>> GetAllTypes()
        {
            var types = QuestionTypes.GetValues(typeof(QuestionTypes)).Cast<QuestionTypes>().ToList();
            List<KeyValuePair<string, int>> questionsTypes = types.Select(x => new KeyValuePair<string, int>(x.GetDescription(), (int)x)).ToList();
            return questionsTypes;
        }

        public void Delete(Guid id)
        {
            this._repository.Delete(id);
            this.Save();
        }

        public void Insert(QuestionModel quiz)
        {
            this._repository.Insert(quiz);
            this.Save();
        }

        public int Update(QuestionModel quiz)
        {
            QuestionModel existing = this._repository.GetByIdWithoutTracking(quiz.Id);
            if (existing != null)
            {
                this._repository.Update(quiz);
                return this.Save();
            }
            return 0;
        }

        public int Save()
        {
            return this._repository.Save();
        }
    }
}
