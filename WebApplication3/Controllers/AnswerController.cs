using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication3.Services.Answer;

namespace WebApplication3.Controllers
{
    [ApiController]
    public class AnswerController : ControllerBase
    {
        private readonly ILogger<AnswerController> _logger;
        private readonly IAnswerService _answerService;
        private readonly IMapper _mapper;


        public AnswerController(ILogger<AnswerController> logger, IAnswerService service, IMapper mapper)
        {
            _logger = logger;
            _answerService = service;
            _mapper = mapper;
        }

        [HttpGet("answers/correct/{questionId}")]
        public IActionResult GetCorrectAnswerByQuestionId(Guid questionId)
        {
            var result = this._answerService.GetCorrectAnswerByQuestionId(questionId);

            return Ok(result);
        }


    }
}
