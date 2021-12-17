using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using WebApplication3.Context;
using WebApplication3.Repository;
using WebApplication3.Services.Quiz;
using WebApplication3.Models.Quiz;
using AutoMapper;

namespace WebApplication3.Context
{
    [ApiController]
    public class QuizController : ControllerBase
    {

        private readonly ILogger<QuizController> _logger;
        private readonly IQuizService _quizService;
        private readonly IMapper _mapper;


        public QuizController(ILogger<QuizController> logger, IQuizService service, IMapper mapper)
        {
            _logger = logger;
            _quizService = service;
            _mapper = mapper;
        }

        [HttpGet("quizzes")]
        public IEnumerable<GetAllQuizDTO> GetAll()
        {
            return this._quizService.getAll();
        }

        [HttpGet("quiz/{id}")]
        public IActionResult GetById(Guid id)
        {
            var quiz = this._quizService.getById(id);
            return Ok(quiz);
        }

        [HttpGet("quiz/status")]
        public List<string> GetStatus()
        {
            return this._quizService.GetStatus();
        }


        [HttpPost("quiz/create")]
        public IActionResult Insert(CreateQuizDTO quiz)
        {
            if (ModelState.IsValid)
            {
                 this._quizService.Insert(quiz);
                return Created("", quiz);
            } else
            {
                this._logger.LogWarning("Insertion échoué : model non valide");
                return BadRequest();
            }
            
        }

        [HttpDelete("quiz/delete/{id}")]
        public IActionResult Delete(Guid id)
        {
            this._quizService.Delete(id);
            return Ok();
        }

        [HttpPut("quiz/update")]
        public IActionResult Update(UpdateQuizDTO quiz)
        {
            int res = this._quizService.Update(quiz);

            switch (res) {
                case -1:
                    return Unauthorized();
                case < 0:
                    return BadRequest();
                default:
                    return Ok();


            }

        }


    }
}
