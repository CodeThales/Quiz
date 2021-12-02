using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Musical_Quiz.Models
{
    public class Question
    {
        [Key]
        public int Id { get; set; }        
        public string Quest { get; set; }

        //[ForeignKey("Quiz")]
        public int QuizId { get; set; }
        public List<Quiz> Quiz { get; set; }

    }
}
