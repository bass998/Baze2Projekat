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
    /// Interaction logic for Kuvari.xaml
    /// </summary>
    public partial class Kuvari : Window
    {
        private IKuvariCRUD factory;
        public BindingList<Radnik> kuvari { get; set; }

        public Kuvari()
        {
            factory = new KuvariCRUD();
            InitializeComponent();
            UcitajSveKuvare();
        }


        private void UcitajSveKuvare()
        {
            kuvari = new BindingList<Radnik>(factory.UcitajSveKuvare());
            KuvariList.ItemsSource = kuvari;
        }

        private void ButtonObrisi_Click(object sender, RoutedEventArgs e)
        {
            var vl = ((FrameworkElement)sender).DataContext as Kuvar;
            if (vl != null)
            {
                factory.ObrisiKuvara(vl.Jmbg);
                UcitajSveKuvare();
            }
        }

        private void ButtonSacuvaj_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (JmbgTextBox.Text != "" && ImeTextBox.Text != "" && PrezimeTextBox.Text != "" && BrojTelefonaTextBox.Text != "")// && UlogaTextBox.Text != "")
                    factory.DodajKuvara(JmbgTextBox.Text, ImeTextBox.Text, PrezimeTextBox.Text, BrojTelefonaTextBox.Text);
            }
            catch
            {
                MessageBox.Show("Greska!", "Popunite sva polja!", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            UcitajSveKuvare();
        }

        private void ButtonMenjaj_Click(object sender, RoutedEventArgs e)
        {
            var vl = ((FrameworkElement)sender).DataContext as Kuvar;
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
            factory.IzmeniKuvara(JmbgTextBox.Text, ImeTextBox.Text, PrezimeTextBox.Text, BrojTelefonaTextBox.Text);
            ResetFields();
            UcitajSveKuvare();
        }

        void ResetFields()
        {
            JmbgTextBox.Text = "";
            ImeTextBox.Text = "";
            PrezimeTextBox.Text = "";
            BrojTelefonaTextBox.Text = "";
            // UlogaTextBox.Text = "Kuvar";

            JmbgTextBox.IsReadOnly = false;
            //UlogaTextBox.IsReadOnly = false;
        }

        private void ButtonOdustane_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
