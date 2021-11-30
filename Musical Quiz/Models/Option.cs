using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Musical_Quiz.Models
{
    public class Option
    {
        [Key]
        public int Id { get; set; }        
        public string Alternative { get; set; }
        public bool IsCorrect { get; set; }

        [ForeignKey("Question")]
        public int QuestionId { get; set; }
    }
}
