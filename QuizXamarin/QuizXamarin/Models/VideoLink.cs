using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizXamarin.Models
{
    public class VideoLink
    {
        public int VideoLinkId { get; set; }

        public decimal MinutesRequired { get; set; }

        public string Description { get; set; }

        public string Link { get; set; }
    }
}
