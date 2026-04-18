using System.ComponentModel.DataAnnotations;

namespace PrjFinanceiro.Models
{
    public class Agencia
    {
        [Key]
        public int Codigo { get; set; }

        [Required]
        [StringLength(100)]
        public string Nome { get; set; }

        [Required]
        [StringLength(100)]
        public string Cidade { get; set; }

        [Required]
        [StringLength(100)]
        public string EstadoUF { get; set; }
    }
}
