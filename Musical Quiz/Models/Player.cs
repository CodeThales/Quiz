using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel.DataAnnotations;

namespace Musical_Quiz.Models
{
    public class Player
    {
        [Key]
        public int Id { get; set; }

        [Display(Name ="Nome do jogador")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [MaxLength(10, ErrorMessage = "O campo {0} deve ter no máximo {1} caracteres")]
        public string FirstName { get; set; }

        [Display(Name = "Sobrenome do jogador")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [MaxLength(10, ErrorMessage = "O campo {0} deve ter no máximo {1} caracteres")]
        public string LastName { get; set; }
        public int Points { get; set; }        
    }
}
