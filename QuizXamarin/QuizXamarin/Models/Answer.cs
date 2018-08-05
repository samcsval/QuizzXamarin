using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizXamarin.Models
{
    public class Answer
    {
        public int AnswerId { get; set; }

        public string AnswerString { get; set; }

        public int QuestionId { get; set; }

        public bool IsCorrect { get; set; }

        public virtual Question Question { get; set; }

        public virtual ICollection<UserQuestionAnswer> UserQuestionAnswers { get; set; }
    }
}
