using System.Collections.Generic;
using System.Linq;
using WebApplication3.Models.Question;
using WebApplication3.Repository.Question;

namespace WebApplication3.Services.Question
{
    public class QuestionService : IQuestionService
    {
        private QuestionTypes _questionTypes;
        
        
        public QuestionService(IQuestionRepository repository)
        {
            this._questionTypes = new QuestionTypes();
        }



        public List<KeyValuePair<string, int>> GetAllTypes()
        {
            var types = QuestionTypes.GetValues(typeof(QuestionTypes)).Cast<QuestionTypes>().ToList();
            var questionsTypes = types.Select(x => new KeyValuePair<string, int>(x.GetDescription(), (int)x)).ToList();
            return questionsTypes;
        }
    }
}
