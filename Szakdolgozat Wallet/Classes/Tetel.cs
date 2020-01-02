using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Szakdolgozat_Wallet.Classes
{
    [Table("Tétel")]
    public class Tetel
    {
        public int ID { get; set; }
        [Required]
        [MaxLength(50)]
        public string Tetel_Neve { get; set; }
        [Required]
        public Kategoria Kategoria_ID { get; set; }
        [Required]
        [MaxLength(50)]
        public string Vasarlas_Ideje { get; set; }
        [Required]
        public int Menyiseg { get; set; }
        [Required]
        public int Erteke { get; set; }
        [MaxLength(50)]
        public string Vasarlas_Helye { get; set; }
    }
}
