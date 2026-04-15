using System.ComponentModel.DataAnnotations;

namespace PrjFinanceiro.Models
{
    public class Agencia
    {
        [Key]
        public int Codigo { get; set; }
        [Required]
        public string Nome { get; set; }
        [Required]
        public string Cidade { get; set; }
        [Required]
        public string EstadoUF { get; set; }
    }
}
