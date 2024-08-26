using System.ComponentModel.DataAnnotations;

namespace lavajato.Models
{
    public class Carro
    {
        [Key]
        public int CodCarro { get; set; }
        [Required]
        public string Marca { get; set;}
        [Required]
        public string Modelo { get; set;}
        [Required]
        public int Ano {get; set; }
        [Required]
        public string Placa { get; set; }
        [Required]
        public int CodCliente { get; set; }
        public Cliente Cliente { get; set; }
        public ICollection<Lavagem> Lavagem { get; set; }   
    }
}
