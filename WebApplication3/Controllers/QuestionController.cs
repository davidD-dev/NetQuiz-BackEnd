using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using WebApplication3.Models.Question;
using WebApplication3.Services.Question;

namespace WebApplication3.Controllers
{
    [ApiController]
    public class QuestionController : ControllerBase
    {
        private readonly ILogger<QuestionController> _logger;
        private readonly IQuestionService _service;
        private readonly IMapper _mapper;

        public QuestionController(ILogger<QuestionController> logger, IQuestionService service, IMapper mapper)
        {
            _logger = logger;
            _service = service;
            _mapper = mapper;
        }
        
        [HttpGet("questions")]
        public IEnumerable<QuestionModel> GetAll()
        {
            return this._service.GetAll(); ;

        }

        [HttpGet("questions/{quizId}")]
        public IEnumerable<GetQuestionDTO> GetByQuiz(Guid quizId)
        {
            return this._service.GetByQuiz(quizId); ;

        }

        [HttpGet("questions/types")]
        public List<KeyValuePair<string, int>> GetAllTypes()
        {
            return this._service.GetAllTypes();

        }

        [HttpDelete("question/delete/{id}")]
        public IActionResult Delete(Guid id)
        {
            this._service.Delete(id);
            return Ok();
        }

        [HttpPost("question/create")]
        public IActionResult Insert(GetQuestionDTO question)
        {
            QuestionModel model = this._mapper.Map<QuestionModel>(question);
            this._service.Insert(model);
            return Ok();
        }

        [HttpPut("question/update")]
        public IActionResult Update(GetQuestionDTO quiz)
        {
            var model = _mapper.Map<QuestionModel>(quiz);
            int res = this._service.Update(model);
            if (res > 0)
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }

        }


    }
}
