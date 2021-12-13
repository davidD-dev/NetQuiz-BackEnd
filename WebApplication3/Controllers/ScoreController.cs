using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication3.Models.Score;
using WebApplication3.Services.Score;

namespace WebApplication3.Controllers
{
    [ApiController]
    public class ScoreController : ControllerBase
    {
        private IMapper _mapper;
        private IScoreService _service;
        ILogger<ScoreController> _logger;

        public ScoreController(IScoreService service, IMapper mapper, ILogger<ScoreController> logger)
        {
            this._logger = logger;
            this._mapper = mapper;
            this._service = service;
        }

        [HttpPost("score/create")]
        public IActionResult Insert(CreateScoreDTO newScore)
        {
            if (ModelState.IsValid)
            {
                var insertedScore = this._service.Insert(newScore);
                if (insertedScore == null)
                {
                    return StatusCode(500);
                } else
                {
                    return Created("",insertedScore);
                }
                
            }
            else
            {
                this._logger.LogWarning("Insertion échoué : model non valide");
                return BadRequest();
            }
        }

        [HttpGet("scores/{quizId}")]
        public IActionResult GetScoreByQuiz(Guid quizId)
        {
            var result = this._service.GetScoreByQuiz(quizId);
            return Ok(result);
        }
    }
}
