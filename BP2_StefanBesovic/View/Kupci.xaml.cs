using BP2_StefanBesovic.ViewModel.Implementation;
using BP2_StefanBesovic.ViewModel.Intefaces;
using ProjectLogic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
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
    /// Interaction logic for Kupci.xaml
    /// </summary>
    public partial class Kupci : Window
    {
        private IKupciCRUD factory;
        public BindingList<Kupac> kupci { get; set; }

        public Kupci()
        {
            factory = new KupciCRUD();
            InitializeComponent();
            UcitajSveKupce();
        }


        private void UcitajSveKupce()
        {
            kupci = new BindingList<Kupac>(factory.UcitajSveKupce());
            KupciList.ItemsSource = kupci;
        }

        private void ButtonObrisi_Click(object sender, RoutedEventArgs e)
        {
            var vl = ((FrameworkElement)sender).DataContext as Kupac;
            if (vl != null)
            {
                factory.ObrisiKupca(vl.Jmbg);
                UcitajSveKupce();
            }
        }

        private void ButtonSacuvaj_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (JmbgTextBox.Text != "" && ImeTextBox.Text != "" && PrezimeTextBox.Text != "" && BrojTelefonaTextBox.Text != "")
                    factory.DodajKupca(JmbgTextBox.Text, ImeTextBox.Text, PrezimeTextBox.Text, BrojTelefonaTextBox.Text);
            }
            catch
            {
                MessageBox.Show("Greska!", "Popunite sva polja!", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            UcitajSveKupce();
        }

        private void ButtonMenjaj_Click(object sender, RoutedEventArgs e)
        {
            var vl = ((FrameworkElement)sender).DataContext as Kupac;
            if (vl != null)
            {
                JmbgTextBox.Text = vl.Jmbg;
                ImeTextBox.Text = vl.Ime;
                PrezimeTextBox.Text = vl.Prezime;
                BrojTelefonaTextBox.Text = vl.BrojTelefona;

                JmbgTextBox.IsReadOnly = true;
            }
        }

        private void ButtonIzmeni_Click(object sender, RoutedEventArgs e)
        {
            factory.IzmeniKupca(JmbgTextBox.Text, ImeTextBox.Text, PrezimeTextBox.Text, BrojTelefonaTextBox.Text);
            ResetFields();
            UcitajSveKupce();
        }

        void ResetFields()
        {

            JmbgTextBox.Text = "";
            ImeTextBox.Text = "";
            PrezimeTextBox.Text = "";
            BrojTelefonaTextBox.Text = "";

            JmbgTextBox.IsReadOnly = false;
        }

        private void ButtonOdustane_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void ButtonIzracunaj_Click(object sender, RoutedEventArgs e)
        {
            if (JmbgTextBox.Text == "")
            {
                MessageBox.Show("Izaberi KUPCA!", "Greska", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                factory.UkupnaPotrosnja(JmbgTextBox.Text);
            }
        }

    }
}
