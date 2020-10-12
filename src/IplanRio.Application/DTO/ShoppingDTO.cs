using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace IplanRio.Application.DTO
{
    public class ShoppingDTO : BaseDTO
    {
        [Required(ErrorMessage = "O Nome não pode ser nulo")]
        [MaxLength(255)]
        [Display(Name = "Nome")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O Endereco não pode ser nulo")]
        [MaxLength(255)]
        [Display(Name = "Endereço")]
        public string Endereco { get; set; }

        [Required(ErrorMessage = "A Hora de Abertura não pode ser nula")]
        [MaxLength(5)]
        [RegularExpression(@"^([0-1]?[0-9]|2[0-3]):[0-5][0-9]$", ErrorMessage = "Digite uma Hora Abertura válida")]
        [Display(Name = "Hora Abertura")]
        public string HoraAbertura { get; set; }

        [Required(ErrorMessage = "A Hora de Fechamento não pode ser nula")]
        [MaxLength(5)]
        [RegularExpression(@"^([0-1]?[0-9]|2[0-3]):[0-5][0-9]$", ErrorMessage = "Digite uma Hora Fechamento válida")]
        [Display(Name = "Hora Fechamento")]
        public string HoraFechamento { get; set; }
    }
}
