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
    /// Interaction logic for Radnici.xaml
    /// </summary>
    public partial class Radnici : Window
    {
        private IRadniciCRUD factory;
        public BindingList<Radnik> radnici { get; set; }

        public Radnici()
        {
            factory = new RadniciCRUD();
            InitializeComponent();
            UcitajSveRadnike();
        }


        private void UcitajSveRadnike()
        {
            radnici = new BindingList<Radnik>(factory.UcitajSveRadnike());
            RadniciList.ItemsSource = radnici;
        }

        private void ButtonObrisi_Click(object sender, RoutedEventArgs e)
        {
            var vl = ((FrameworkElement)sender).DataContext as Kupac;
            if (vl != null)
            {
                factory.ObrisiRadnika(vl.Jmbg);
                UcitajSveRadnike();
            }
        }

        private void ButtonSacuvaj_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (JmbgTextBox.Text != "" && ImeTextBox.Text != "" && PrezimeTextBox.Text != "" && BrojTelefonaTextBox.Text != "" && UlogaTextBox.Text != "")
                    factory.DodajRadnika(JmbgTextBox.Text, ImeTextBox.Text, PrezimeTextBox.Text, BrojTelefonaTextBox.Text, UlogaTextBox.Text);
            }
            catch
            {
                MessageBox.Show("Greska!", "Popunite sva polja!", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            UcitajSveRadnike();
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
                UlogaTextBox.Text = "";

                JmbgTextBox.IsReadOnly = true;
            }
        }

        private void ButtonIzmeni_Click(object sender, RoutedEventArgs e)
        {
            factory.IzmeniRadnika(JmbgTextBox.Text, ImeTextBox.Text, PrezimeTextBox.Text, BrojTelefonaTextBox.Text);
            ResetFields();
            UcitajSveRadnike();
        }

        void ResetFields()
        {

            JmbgTextBox.Text = "";
            ImeTextBox.Text = "";
            PrezimeTextBox.Text = "";
            BrojTelefonaTextBox.Text = "";
            UlogaTextBox.Text = "";

            JmbgTextBox.IsReadOnly = false;
        }

        private void ButtonOdustane_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
