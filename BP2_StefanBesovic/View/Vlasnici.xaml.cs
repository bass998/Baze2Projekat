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
using BP2_StefanBesovic.ViewModel.Intefaces;
using BP2_StefanBesovic.ViewModel.Implementation;
using System.ComponentModel;
using ProjectLogic;

namespace BP2_StefanBesovic.View
{
    /// <summary>
    /// Interaction logic for Vlasnici.xaml
    /// </summary>
    public partial class Vlasnici : Window
    {
        private IVlasniciCRUD factory;
        public BindingList<Vlasnik> vlasnici { get; set; }

        public Vlasnici()
        {
            factory = new VlasniciCRUD();
            InitializeComponent();
            UcitajSveVlasnike();
        }


        private void UcitajSveVlasnike()
        {
            vlasnici = new BindingList<Vlasnik>(factory.UcitajSveVlasnike());
            VlasniciList.ItemsSource = vlasnici;
        }

        private void ButtonObrisi_Click(object sender, RoutedEventArgs e)
        {
            var vl = ((FrameworkElement)sender).DataContext as Vlasnik;
            if (vl != null)
            {
                factory.ObrisiVlasnika(vl.Jmbg);
                UcitajSveVlasnike();
            }
        }

        private void ButtonSacuvaj_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if(JmbgTextBox.Text != "" && ImeTextBox.Text != "" && PrezimeTextBox.Text != "" && BrojTelefonaTextBox.Text != "")
                    factory.DodajVlasnika(JmbgTextBox.Text, ImeTextBox.Text, PrezimeTextBox.Text, BrojTelefonaTextBox.Text);
            }
            catch
            {
                MessageBox.Show("Greska!", "Popunite sva polja!", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            UcitajSveVlasnike();
        }

        private void ButtonMenjaj_Click(object sender, RoutedEventArgs e)
        {
            var vl = ((FrameworkElement)sender).DataContext as Vlasnik;
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
            factory.IzmeniVlasnika(JmbgTextBox.Text, ImeTextBox.Text, PrezimeTextBox.Text, BrojTelefonaTextBox.Text);
            ResetFields();
            UcitajSveVlasnike();
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
    }
}
