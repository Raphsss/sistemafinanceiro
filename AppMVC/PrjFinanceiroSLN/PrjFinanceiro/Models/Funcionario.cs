using System;
using System.ComponentModel.DataAnnotations;

namespace PrjFinanceiro.Models
{
    public class Funcionario
    {
        [Key]
        public int Codigo { get; set; }

        [Required]
        [StringLength(100)]
        public string Nome { get; set; }

        [DataType(DataType.Date)]
        public DateTime DataNascimento { get; set; }

        [StringLength(100)]
        public string Cidade { get; set; }

        [StringLength(100)]
        public string EstadoUF { get; set; }

        [Required]
        [StringLength(20)]
        public string CPF { get; set; }

        [StringLength(20)]
        public string Telefone { get; set; }
    }
}
