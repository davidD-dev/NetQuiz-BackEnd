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
        public List<GetAllQuizDTO> GetAll()
        {
            return this._quizService.getAll();
        }

        [HttpGet("quizzes/draft")]
        public List<GetAllQuizDTO> GetDraftQuizzes()
        {
            return this._quizService.GetDraftQuizzes();
        }
        
        [HttpGet("quizzes/publish")]
        public List<GetAllQuizDTO> GetPublishQuizzes()
        {
            return this._quizService.GetPublishQuizzes();
        }

        [HttpGet("quiz/{id}")]
        public IActionResult GetById(Guid id)
        {
            var quiz = this._quizService.getById(id);
            return Ok(quiz);
        }
        

        [HttpPost("quiz/{id}/rate")]
        public IActionResult Rate(Guid id, RateDTO values)
        {
            return ReturnActionResult(this._quizService.Rate(id, values.Rate));
        }


        [HttpPost("quiz")]
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
        
        
        
        [HttpPost("quiz/{id}/checkAccess")]
        public IActionResult CheckAccess(Guid id, PasswordDTO values)
        {
            GetQuizDTO res = this._quizService.CheckAccess(id, values.Password);
            if (res == null)
            {
                return Unauthorized();
            }
            else
            {
                return Ok(res);
            }

        }

        [HttpPost("quiz/{id}/publish")]
        public IActionResult Publish(Guid id)
        {
            int res = this._quizService.Publish(id);
            return ReturnActionResult(res);

        }

        [HttpDelete("quiz/{id}")]
        public IActionResult Delete(Guid id)
        {
            this._quizService.Delete(id);
            return Ok();
        }

        [HttpPut("quiz/{id}")]
        public IActionResult Update(Guid id, UpdateQuizDTO quiz)
        {
            var res = this._quizService.Update(id, quiz);

            return ReturnActionResult(res);


        }

        private IActionResult ReturnActionResult(int result)
        {

            return result switch
            {
                -1 => Unauthorized(),
                -2 => NotFound(),
                0 => BadRequest(),
                _ => Ok(),
            };
        }

    }

}
