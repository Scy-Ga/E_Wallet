using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Szakdolgozat_Wallet.Classes;

namespace Szakdolgozat_Wallet
{
    /// <summary>
    /// Interaction logic for Tetelek.xaml
    /// </summary>
    public partial class Tetelek : Window
    {

        WalletContext tetelContext;
        string datum;
        ComboBox Cbox;
        

        public Tetelek(WalletContext context, string Datum, ComboBox combo)
        {

            InitializeComponent();

            tetelContext = context;
            datum = Datum;
            Cbox = combo;
            
            



        }

        private void Btn_ok_Click(object sender, RoutedEventArgs e)
        {


            Tetel tetel = new Tetel();
            List<Tetel> tetelLista = new List<Tetel>();





            tetel.Tetel_Neve = txb_termeknev.Text;
            tetel.Menyiseg = int.Parse(txb_db.Text);
            tetel.Vasarlas_Ideje = datum;
            tetel.Erteke = int.Parse(txb_ara.Text);

            if (txb_vasHelye.Text.Length == 0)
            {
                tetel.Vasarlas_Helye = "Ismeretlen";
            }
            else
            {
                tetel.Vasarlas_Helye = txb_vasHelye.Text;
            }

            tetel.Kategoria_ID = (Kategoria)Cbox.SelectedItem;

            tetelContext.Tetelek.Add(tetel);
            tetelContext.SaveChanges();


            Close();




        }

        private void Btn_megsem_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
