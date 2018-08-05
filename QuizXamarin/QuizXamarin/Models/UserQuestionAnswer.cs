using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizXamarin.Models
{
    public class UserQuestionAnswer
    {
        public int UserQuestionAnswerId { get; set; }

        public int AnswerId { get; set; }

        public int UserId { get; set; }

        public int QuestionId { get; set; }

        public virtual Answer Answer { get; set; }

        public virtual User User { get; set; }

        public virtual Question Question { get; set; }
    }
}
