using MySql.Data.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Szakdolgozat_Wallet.Classes;

namespace Szakdolgozat_Wallet
{
    [DbConfigurationType(typeof(MySqlEFConfiguration))]
    public class WalletContext: DbContext
    {
        public DbSet<Kategoria>Kategoriak { get; set; }
        public DbSet<Tetel>Tetelek { get; set; }
        public DbSet<Kolcsegvetes> Kölcsegvetesek { get; set; }
    }
}
