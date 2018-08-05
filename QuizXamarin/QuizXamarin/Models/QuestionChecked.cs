using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizXamarin.Models
{
    public class QuestionChecked
    {
        public int QuestionId { get; set; }

        public string QuestionString { get; set; }

        public virtual ICollection<AnswerChecked> Answers { get; set; }

        public virtual ICollection<UserQuestionAnswer> UserQuestionAnswers { get; set; }

    }
}
