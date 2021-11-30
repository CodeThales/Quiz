using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Musical_Quiz.Models
{
    public class Option
    {
        public int Id { get; set; }
        public int? QuestionsId { get; set; }
        public string Option { get; set; }
        public bool IsCorrect { get; set; }
    }
}
