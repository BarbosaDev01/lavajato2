using System.ComponentModel.DataAnnotations;

namespace lavajato.Models
{
    public class TipoLavagem
    {
        [Key]
        public int CodTipoLav { get; set; }
        [Required]
        public string DescTipoLav { get; set; }
        [Required]
        public int PrecoTipoLav { get; set; }
        
        public ICollection<Lavagem> Lavagem { get; set; }
    }
}
