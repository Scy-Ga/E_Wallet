using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Szakdolgozat_Wallet.Classes
{
    [Table("Kölcségvetés")]
    public class Kolcsegvetes
    {
        public int ID { get; set; }
        [Required]
        [MaxLength(5)]
        public string Ev { get; set; }
        [Required]
        [MaxLength(2)]
        public string Honap { get; set; }
        public int Havi_keret { get; set; }
        public int Felhasznalt_keret { get; set; }
        public int Megtakaritott_penz { get; set; }
        public int Atlepett_keret { get; set; }


    }
}
