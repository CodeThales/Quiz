using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Musical_Quiz.Models
{
    public class PlayerAnswers
    {
        [Key]
        public int Id { get; set; }

        //[ForeignKey("Player")]
        [Column(Order = 1)]
        public int PlayerId { get; set; }
        public List<Player> Player { get; set; }

        //[ForeignKey("Question")]
        [Column(Order = 2)]
        public int QuestionId { get; set; }
        public List<Question> Question { get; set; }

        //[ForeignKey("Option")]
        [Column(Order = 2)]
        public int OptionId { get; set; }
        public List<Option> Option { get; set; }
    }
}
