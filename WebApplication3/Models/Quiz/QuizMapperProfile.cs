using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication3.Models.Answer;
using WebApplication3.Models.Question;
using WebApplication3.Models.Score;

namespace WebApplication3.Models.Quiz
{
    public class QuizMapperProfile : Profile
    {
        public QuizMapperProfile()
        {
            CreateMap<QuizModel, GetQuizDTO>().ReverseMap();
            CreateMap<QuizModel, CreateQuizDTO>().ReverseMap();

            CreateMap<QuestionModel, GetQuestionDTO>().ReverseMap();
            CreateMap<QuestionModel, CreateQuestionDTO>().ReverseMap();

            CreateMap<AnswerModel, GetAnswerDTO>().ReverseMap();
            CreateMap<AnswerModel, CreateAnswerDTO>().ReverseMap();

            CreateMap<ScoreModel, GetScoreDTO>().ReverseMap();
            CreateMap<ScoreModel, CreateScoreDTO>().ReverseMap();

            CreateMap<QuizModel, UpdateQuizDTO>().ReverseMap();
        }
    }
}
