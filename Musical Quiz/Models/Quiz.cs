using System.ComponentModel.DataAnnotations;

namespace Musical_Quiz.Models
{
    public class Quiz
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Escolha o estilo musical")]
        public string Theme { get; set; }
    }
}
