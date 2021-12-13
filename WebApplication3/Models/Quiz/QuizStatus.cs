using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication3.Models.Quiz
{
    public static class Extensions
    {
        public static string GetDescription(this QuizStatus status)
        {
            DescriptionAttribute[] attributes = (DescriptionAttribute[])status
            .GetType()
            .GetField(status.ToString())
            .GetCustomAttributes(typeof(DescriptionAttribute), false);

            return attributes.Length > 0 ? attributes[0].Description : string.Empty;
        }
    }

    public enum QuizStatus
    {
        [Description("Brouillon")]
        Draft,

        [Description("Publié")]
        Published
    }
}
