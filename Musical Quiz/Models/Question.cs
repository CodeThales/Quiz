using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Musical_Quiz.Models
{
    public class Question
    {
        [Key]
        public int Id { get; set; }        
        public string Quest { get; set; }

        [ForeignKey("Quiz")]
        public int QuizId { get; set; }
        
    }
}
