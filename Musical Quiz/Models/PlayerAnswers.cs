using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Musical_Quiz.Models
{
    public class PlayerAnswers
    {
        public int Id { get; set; }
        public int QuestionId { get; set; }
        public int PlayeId { get; set; }
        public int OptionsId { get; set; }
    }
}
