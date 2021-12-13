using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication3.Models.Question
{
    public enum QuestionTypes
    {
        // A true or false quesiton
        TrueFalse,

        // A question with multiple choices and several correct answers 
        MultipleAnswer,

        // A qestion with multiple choice but only one answer correct
        SingleAnswer,

        // A quesiton with a text area for the answer
        TextAnswer
    }
}
