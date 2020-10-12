using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace IplanRio.Domain.Entities
{
    [Table("Shopping")]
    public class Shopping : Base
    {
        [Required]
        [Column("Nome")]
        public virtual string Nome { get; set; }

        [Required]
        [Column("Endereco")]
        public virtual string Endereco { get; set; }

        [Required]
        [Column("HoraAbertura")]
        public virtual string HoraAbertura { get; set; }

        [Required]
        [Column("HoraFechamento")]
        public virtual string HoraFechamento { get; set; }
    }
}
