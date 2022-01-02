using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication3.Models.Question
{
/*    public class QuestionTypes
    {
        public List<KeyValuePair<string, int>> Types { 
            get; 
            private set; 
        }
        
        public QuestionTypes()
        {
            Types = new List<KeyValuePair<string, int>>();
            Types.Add(new KeyValuePair<string, int>("Choix multiple", 0));
            Types.Add(new KeyValuePair<string, int>("Choix unique", 1));
            Types.Add(new KeyValuePair<string, int>("Réponse libre", 2));
        }


    }*/

    public static class Extensions
    {
        public static string GetDescription(this QuestionTypes status)
        {
            DescriptionAttribute[] attributes = (DescriptionAttribute[])status
            .GetType()
            .GetField(status.ToString())
            .GetCustomAttributes(typeof(DescriptionAttribute), false);

            return attributes.Length > 0 ? attributes[0].Description : string.Empty;
        }
    }

    public enum QuestionTypes
    {
        [Description("Choix multiple")]
        MultipleAnswer,

        [Description("Choix unique")]
        UniqueAnswer,

        [Description("Réponse libre")]
        freeAnswer,
    }

}
