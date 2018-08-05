using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizXamarin.Models
{
    public class User
    {
        public int UserId { get; set; }

        public string Name { get; set; }

        public virtual ICollection<UserQuestionAnswer> UserQuestionAnswers { get; set; }
    }
}
