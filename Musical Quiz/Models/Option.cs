using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Musical_Quiz.Models
{
    public class Option
    {
        [Key]
        public int Id { get; set; }        
        public string Alternative { get; set; }
        public bool IsCorrect { get; set; }

        //[ForeignKey("Question")]
        public int QuestionId { get; set; }
        public List<Question> Question { get; set; }
    }
}
