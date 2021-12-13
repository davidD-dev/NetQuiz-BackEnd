using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication3.Models.Score;

namespace WebApplication3.Repository.Score
{
    public interface IScoreRepository : ICrudRepository<ScoreModel>
    {
        public List<GetScoreDTO> GetScoreByQuizId(Guid quizId);
    }
}
