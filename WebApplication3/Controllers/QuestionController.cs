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
        
        

        [HttpGet("questions/types")]
        public List<KeyValuePair<string, int>> GetAllTypes()
        {
            return this._service.GetAllTypes();

        }
        


    }
}
