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
    /// Interaction logic for Restorani.xaml
    /// </summary>
    public partial class Restorani : Window
    {
        private IRestoraniCRUD factory;
        public BindingList<Restoran> restorani { get; set; }

        public Restorani()
        {
            factory = new RestoraniCRUD();
            InitializeComponent();
            UcitajSveRestorane();
        }


        private void UcitajSveRestorane()
        {
            restorani = new BindingList<Restoran>(factory.UcitajSveRestorane());
            RestoraniList.ItemsSource = restorani;
        }

        private void ButtonObrisi_Click(object sender, RoutedEventArgs e)
        {
            var vl = ((FrameworkElement)sender).DataContext as Restoran;
            if (vl != null)
            {
                factory.ObrisiRestoran(vl.Naziv);
                UcitajSveRestorane();
            }
        }

        private void ButtonSacuvaj_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (NazivTextBox.Text != "" && AdresaTextBox.Text != "" && GradTextBox.Text != "" && BrojTelefonaTextBox.Text != "" && VlasnikJmbgTextBox.Text != "")
                    factory.DodajRestoran(NazivTextBox.Text, AdresaTextBox.Text, GradTextBox.Text, BrojTelefonaTextBox.Text, VlasnikJmbgTextBox.Text);
            }
            catch
            {
                MessageBox.Show("Greska!", "Popunite sva polja!", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            UcitajSveRestorane();
        }

        private void ButtonMenjaj_Click(object sender, RoutedEventArgs e)
        {
            var vl = ((FrameworkElement)sender).DataContext as Restoran;
            if (vl != null)
            {
                NazivTextBox.Text = vl.Naziv;
                AdresaTextBox.Text = vl.Adresa;
                GradTextBox.Text = vl.Grad;
                BrojTelefonaTextBox.Text = vl.BrojTelefona;
                VlasnikJmbgTextBox.Text = vl.VlasnikJmbg;

                NazivTextBox.IsReadOnly = true;
            }
        }

        private void ButtonIzmeni_Click(object sender, RoutedEventArgs e)
        {
            factory.IzmeniRestoran(NazivTextBox.Text, AdresaTextBox.Text, GradTextBox.Text, BrojTelefonaTextBox.Text, VlasnikJmbgTextBox.Text);
            ResetFields();
            UcitajSveRestorane();
        }

        void ResetFields()
        {

            NazivTextBox.Text = "";
            AdresaTextBox.Text = "";
            GradTextBox.Text = "";
            BrojTelefonaTextBox.Text = "";
            VlasnikJmbgTextBox.Text = "";

            NazivTextBox.IsReadOnly = false;
        }

        private void ButtonOdustane_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
