using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication3.Models.Question;

namespace WebApplication3.Services.Question
{
    public interface IQuestionService
    {
        List<KeyValuePair<string, int>> GetAllTypes();
    }
}
