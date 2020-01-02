using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Szakdolgozat_Wallet.Classes;

namespace Szakdolgozat_Wallet
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        WalletContext context = new WalletContext();
        List<Kategoria> KategoriaLista = new List<Kategoria>();
        Regex regex = new Regex("[^0-9]+");

        //Kategoria l;

        public MainWindow()
        {
            InitializeComponent();

            KategoriaLista = context.Kategoriak.ToList();
            dg_tetelek.ItemsSource = context.Tetelek.ToList();





            KategoriaLista.Insert(0, new Kategoria() { ID = 0 });
            cb_kategoriak.ItemsSource = KategoriaLista;
            cb_kategoriak.SelectedValuePath = "ID";
            cb_kategoriak.DisplayMemberPath = "Kategoria_Nev";
            cb_kategoriak.SelectedValue = 0;

            dp_time.SelectedDate = DateTime.Now;


            //lb_havikeret.Content = AktualisKolcseg();


            


            #region beolvas gombra
            //string[] name;
            //string a = "";
            //Kategoria l = new Kategoria();

            //WalletContext btn_context = new WalletContext();


            //TabItem uj = new TabItem
            //{
            //    Header = Txb_Kategoria.Text,

            //};


            //name = Txb_Kategoria.Text.Split();


            //for (int i = 0; i < name.Count(); i++)
            //{
            //    a += name[i] + "_";
            //}

            //uj.Name = "TBI_Kategoria_" + a.Substring(0, a.Length - 1);


            //l.Kategoria_Nev = Txb_Kategoria.Text;

            //btn_context.Kategoriak.Add(l);
            //btn_context.SaveChanges();
            //Txb_Kategoria.Clear();

            //Tab1.Items.Add(uj);
            #endregion


        }

        //private int AktualisKolcseg()
        //{
        //    string Honap = DateTime.Now.ToString("MM");
        //    int vissza = 0;

        //    if (context.Kölcsegvetesek.Count() > 0)
        //    {
        //        var aktkolcseg = (from akt in context.Kölcsegvetesek
        //                          where akt.Honap.Contains(Honap)
        //                          select akt.Havi_keret).ToList();
        //        vissza = aktkolcseg[0];
        //    }

        //    return vissza;
        //}

        private void DataGrid_RowEditEnding(object sender, DataGridRowEditEndingEventArgs e)
        {

        }

        private void Btn_ad_Click(object sender, RoutedEventArgs e)
        {

            Kategoria l = new Kategoria();

            if (txb_kategoria.Text == "")
            {

                MessageBox.Show("Kötelező a kategória nevét megadni!", "Hiba'", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                l.Kategoria_Nev = txb_kategoria.Text;

                context.Kategoriak.Add(l);
                context.SaveChanges();
                txb_kategoria.Clear();
                cb_kategoriak.ItemsSource = context.Kategoriak.ToList();
                cb_kategoriak.SelectedIndex = l.ID - 1;
            }



        }

        private void Btn_tetelek_Click(object sender, RoutedEventArgs e)
        {

            


            if (dp_time.SelectedDate > DateTime.Now)
            {
                MessageBox.Show("Jövőbeni dátum nem adható meg!", "Hiba!", MessageBoxButton.OK, MessageBoxImage.Error);

            }
            else
            {

                

                if (context.Kölcsegvetesek.Count() == 0)
                {


                    if (txb_haviKeret.Text == "" && regex.IsMatch("[^0-9]+") == false)
                    {
                        MessageBox.Show("Nem adtál meg havi keretösszeget vagy a megadot adat nem helyes(Csak számok irhatók!!!)", "Havi keretösszeg!", MessageBoxButton.OK, MessageBoxImage.Warning);
                    }
                    else
                    {
                        Kolcsegvetes kolcseg = new Kolcsegvetes();
                        List<Kolcsegvetes> kolcsegLista = new List<Kolcsegvetes>();




                        kolcseg.Havi_keret = int.Parse(txb_haviKeret.Text);


                        //context.Kölcsegvetesek.Add(k);
                        //context.SaveChanges();

                        //Kolcsegvetes kolcseg;

                        //kolcseg.Havi_keret = int.Parse(txb_haviKeret.Text);
                        kolcseg.Ev = dp_time.SelectedDate.Value.ToString("yyyy");
                        kolcseg.Honap = dp_time.SelectedDate.Value.ToString("MM");
                        context.Kölcsegvetesek.Add(kolcseg);
                        context.SaveChanges();
                    }

                    lb_havikeret.Content = txb_haviKeret.Text;
                    txb_haviKeret.Clear();

                }
                Tetelek tetelekAblak = new Tetelek(context, dp_time.SelectedDate.Value.ToString("yyyy.MM.dd."), cb_kategoriak);
                tetelekAblak.ShowDialog();
                dg_tetelek.ItemsSource = context.Tetelek.ToList();
            }

        }

        private void Btn_Keres_Click(object sender, RoutedEventArgs e)
        {
            int összeg = 0;
            int felhasznalhato = 0;
            int havikeret = 0;
            string keresettNap = dp_time.SelectedDate.Value.ToString("yyyy.MM.dd.");

            if (cb_kategoriak.SelectedIndex == 0)
            {
                var talalatok = (from i in context.Tetelek
                                 select i).ToList();
                dg_tetelek.ItemsSource = talalatok;
            }

            if (cb_kategoriak.SelectedIndex > 0)
            {
                var keres = (from a in context.Tetelek
                             where a.Kategoria_ID.ID == cb_kategoriak.SelectedIndex && a.Vasarlas_Ideje.Contains(keresettNap)
                             select a).ToList();
                dg_tetelek.ItemsSource = keres;
            }

            //for (int i = 0; i < context.Tetelek.Count(); i++)
            //{
            //    //összeg += t.Erteke;
            //}

            //havikeret = int.Parse(txb_haviKeret.Text);

            //felhasznalhato = havikeret - összeg;

            //if (felhasznalhato >= 0)
            //{
            //    lb_sporolt.Content = havikeret - összeg;
            //    lb_tullepett.Content = 0;
            //}

            //if (felhasznalhato < 0)
            //{
            //    lb_sporolt.Content = havikeret - összeg;
            //    lb_tullepett.Content = -1 * (havikeret - összeg);
            //}

            //lb_felhasznalhato.Content = felhasznalhato;

        }


    }
}
