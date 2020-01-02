using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Szakdolgozat_Wallet.Classes
{
    [Table("Kategória")]
    public class Kategoria
    {
        public int ID { get; set; }
        [Required]
        [MaxLength(50)]
        public string Kategoria_Nev { get; set; }
    }
}
