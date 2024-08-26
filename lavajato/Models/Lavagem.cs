using System.ComponentModel.DataAnnotations;

namespace lavajato.Models
{
    public class Lavagem
    {
        [Key]
        public int CodLav { get; set; }
        [Required]
        public int DataLav { get; set; }
        [Required]
        public int ValorLav { get; set; }
        [Required]
        public int CodCarro { get; set; }
        [Required]
        public Carro Carro { get; set; }
        [Required]
        public int CodTipoLav { get; set; }
        public TipoLavagem TipoLavagem { get; set; }
    
    }
}
