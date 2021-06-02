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
    /// Interaction logic for Konobari.xaml
    /// </summary>
    public partial class Konobari : Window
    {
        private IKonobariCRUD factory;
        public BindingList<Radnik> konobari { get; set; }

        public Konobari()
        {
            factory = new KonobariCRUD();
            InitializeComponent();
            UcitajSveKonobare();
        }


        private void UcitajSveKonobare()
        {
            konobari = new BindingList<Radnik>(factory.UcitajSveKonobare());
            KonobariList.ItemsSource = konobari;
        }

        private void ButtonObrisi_Click(object sender, RoutedEventArgs e)
        {
            var vl = ((FrameworkElement)sender).DataContext as Konobar;
            if (vl != null)
            {
                factory.ObrisiKonobara(vl.Jmbg);
                UcitajSveKonobare();
            }
        }

        private void ButtonSacuvaj_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (JmbgTextBox.Text != "" && ImeTextBox.Text != "" && PrezimeTextBox.Text != "" && BrojTelefonaTextBox.Text != "")// && UlogaTextBox.Text != "")
                    factory.DodajKonobara(JmbgTextBox.Text, ImeTextBox.Text, PrezimeTextBox.Text, BrojTelefonaTextBox.Text);
            }
            catch
            {
                MessageBox.Show("Greska!", "Popunite sva polja!", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            UcitajSveKonobare();
        }

        private void ButtonMenjaj_Click(object sender, RoutedEventArgs e)
        {
            var vl = ((FrameworkElement)sender).DataContext as Konobar;
            if (vl != null)
            {
                JmbgTextBox.Text = vl.Jmbg;
                ImeTextBox.Text = vl.Ime;
                PrezimeTextBox.Text = vl.Prezime;
                BrojTelefonaTextBox.Text = vl.BrojTelefona;
                //UlogaTextBox.Text = vl.TipRadnika;

                JmbgTextBox.IsReadOnly = true;
              //UlogaTextBox.IsReadOnly = true;
            }
        }

        private void ButtonIzmeni_Click(object sender, RoutedEventArgs e)
        {
            factory.IzmeniKonobara(JmbgTextBox.Text, ImeTextBox.Text, PrezimeTextBox.Text, BrojTelefonaTextBox.Text);
            ResetFields();
            UcitajSveKonobare();
        }

        void ResetFields()
        {
            JmbgTextBox.Text = "";
            ImeTextBox.Text = "";
            PrezimeTextBox.Text = "";
            BrojTelefonaTextBox.Text = "";
           // UlogaTextBox.Text = "Konobar";

            JmbgTextBox.IsReadOnly = false;
//UlogaTextBox.IsReadOnly = false;
        }

        private void ButtonOdustane_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
