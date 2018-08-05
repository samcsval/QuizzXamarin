using System.Collections.Generic;


namespace QuizXamarin.Models
{
    public class QuestionResponse
    {
        public int QuestionId { get; set; }

        public string QuestionString { get; set; }

       public List<Answer> Answers { get; set; }

    }
}