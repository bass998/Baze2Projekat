using BP2_StefanBesovic.ViewModel.Implementation;
using BP2_StefanBesovic.ViewModel.Intefaces;
using ProjectLogic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace BP2_StefanBesovic.View
{
    /// <summary>
    /// Interaction logic for Kupovine.xaml
    /// </summary>
    public partial class Kupovine : Window
    {
        private IKupovineCRUD factory;
        public BindingList<Kupuje> kupovine { get; set; }

        public Kupovine()
        {
            factory = new KupovineCRUD();
            InitializeComponent();
            UcitajSveKupovine();
        }


        private void UcitajSveKupovine()
        {
            kupovine = new BindingList<Kupuje>(factory.UcitajKupovine());
            KupovineList.ItemsSource = kupovine;
        }

        private void ButtonObrisi_Click(object sender, RoutedEventArgs e)
        {
            var vl = ((FrameworkElement)sender).DataContext as Kupuje;
            if (vl != null)
            {
                factory.ObrisiKupovinu(vl.NudiRestoranNaziv, vl.NudiProizvodNaziv, vl.KupacJmbg, vl.KonobarJmbg);
                UcitajSveKupovine();
            }
        }

        private void ButtonSacuvaj_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (NazivRestoranaTextBox.Text != "" && NazivProizvodaTextBox.Text != "" && KupacJmbgTextBox.Text != "" && KonobarJmbgTextBox.Text != "" )
                    factory.DodajKupovinu(NazivRestoranaTextBox.Text, NazivProizvodaTextBox.Text, KupacJmbgTextBox.Text, KonobarJmbgTextBox.Text);
            }
            catch
            {
                MessageBox.Show("Greska!", "Popunite sva polja!", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            UcitajSveKupovine();
        }

        private void ButtonOdustane_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
