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
using System.Windows.Navigation;
using System.Windows.Shapes;
using ProjectLogic;

namespace BP2_StefanBesovic
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private RestoranDbModelContainer db;
        public MainWindow()
        {
            InitializeComponent();
            db = new RestoranDbModelContainer();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            /*
            Vlasnik w = new Vlasnik();
            w.Jmbg = "1212121212121";
            w.Ime = "Milos";
            w.Prezime = "Milovanovic";
            w.BrojTelefona = "0661232312";

            db.Vlasnici.Add(w);
            db.SaveChanges();
            

            Kupac k = new Kupac();
            k.Jmbg = "1112223331112";
            k.Ime = "Miran";
            k.Prezime = "Miric";
            k.BrojTelefona = "0621232312";

            db.Kupci.Add(k);
            db.SaveChanges();


            Konobar r = new Konobar();
            r.Jmbg = "2223334445556";
            r.Ime = "Ziki";
            r.Prezime = "Miric";
            r.BrojTelefona = "0692312312";
            
            db.Radnici.Add(r);
            db.SaveChanges();

            Kupuje kp = new Kupuje();
            kp.NudiRestoranNaziv = "StefansDinner";
            kp.NudiProizvodNaziv = "Susi";
            kp.KonobarJmbg = "2223334445556";
            kp.KupacJmbg = "1112223331112";

            db.Kupovine.Add(kp);
            db.SaveChanges();

            */


            db.Proizvodi.Remove(db.Proizvodi.Find("Fanta1.5"));
            db.SaveChanges();

        }
    }
}
