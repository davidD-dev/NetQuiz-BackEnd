using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication3.Models.Score;
using WebApplication3.Repository.Score;

namespace WebApplication3.Services.Score
{
    public class ScoreService : IScoreService
    {
        private IScoreRepository _repository;
        private readonly IMapper _mapper;

        public ScoreService(IScoreRepository repository, IMapper mapper )
        {
            this._repository = repository;
            this._mapper = mapper;
        }

        public List<GetScoreDTO> GetScoreByQuiz(Guid quizId)
        {
            return this._repository.GetScoreByQuizId(quizId);
        }

        public GetScoreDTO Insert(CreateScoreDTO score)
        {
            ScoreModel model = this._mapper.Map<ScoreModel>(score);
            var result = this._repository.Insert(model);
            GetScoreDTO insertedScore = this._mapper.Map<GetScoreDTO>(result);
            this.Save();
            return insertedScore;
        }

        public int Save()
        {
            return this._repository.Save();
        }
    }
}
