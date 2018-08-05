using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizXamarin.Models
{
    public class Question
    {
        public int QuestionId { get; set; }

        public string QuestionString { get; set; }

        public virtual ICollection<Answer> Answers { get; set; }

        public virtual ICollection<UserQuestionAnswer> UserQuestionAnswers { get; set; }

    }
}
