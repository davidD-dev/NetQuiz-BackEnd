using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication3.Models.Score;
using WebApplication3.Repository.Score;

namespace WebApplication3.Services.Score
{
    public interface IScoreService
    {
        public List<GetScoreDTO> GetScoreByQuiz(Guid quizId);

        public GetScoreDTO Insert(CreateScoreDTO score);
        
    }
}
