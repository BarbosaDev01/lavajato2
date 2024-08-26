using System.ComponentModel.DataAnnotations;

namespace lavajato.Models
{
    public class Cliente
    {
        [Key]
        public int CodCliente { get; set; }
        [Required]
        public string NomeCliente { get; set; }
        [Required]
        public string EndCliente { get; set; }
        [Required]
        public string FoneCliente { get; set; }

        public ICollection<Carro> Carro { get; set; }
    }
}
