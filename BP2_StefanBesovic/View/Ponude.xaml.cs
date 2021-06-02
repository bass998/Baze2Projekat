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
    /// Interaction logic for Ponude.xaml
    /// </summary>
    public partial class Ponude : Window
    {
        private INudiCRUD factory;
        public BindingList<Nudi> ponude { get; set; }

        public Ponude()
        {
            factory = new NudiCRUD();
            InitializeComponent();
            UcitajSvePonude();
        }


        private void UcitajSvePonude()
        {
            ponude = new BindingList<Nudi>(factory.UcitajPonude());
            PonudeList.ItemsSource = ponude;
        }

        private void ButtonObrisi_Click(object sender, RoutedEventArgs e)
        {
            var vl = ((FrameworkElement)sender).DataContext as Nudi;
            if (vl != null)
            {
                factory.ObrisiPonudu(vl.RestoranNaziv, vl.ProizvodNaziv);
                UcitajSvePonude();
            }
        }

        private void ButtonSacuvaj_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (NazivRestoranaTextBox.Text != "" && NazivProizvodaTextBox.Text != "")
                    factory.DodajPonudu(NazivRestoranaTextBox.Text, NazivProizvodaTextBox.Text);
            }
            catch
            {
                MessageBox.Show("Greska!", "Popunite sva polja!", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            UcitajSvePonude();
        }

        private void ButtonOdustane_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
