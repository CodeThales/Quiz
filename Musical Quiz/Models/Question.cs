using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Musical_Quiz.Models
{
    public class Question
    {
        public int Id { get; set; }
        public int? QuizId { get; set; }
        public string Quest { get; set; }
    }
}
