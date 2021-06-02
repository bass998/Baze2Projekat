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
    /// Interaction logic for Jela.xaml
    /// </summary>
    public partial class Jela : Window
    {
        private IJelaCRUD factory;
        public BindingList<Proizvod> jela { get; set; }

        public Jela()
        {
            factory = new JelaCRUD();
            InitializeComponent();
            UcitajSvaJela();
        }


        private void UcitajSvaJela()
        {
            jela = new BindingList<Proizvod>(factory.UcitajSvaJela());
            JelaList.ItemsSource = jela;
        }

        private void ButtonObrisi_Click(object sender, RoutedEventArgs e)
        {
            var vl = ((FrameworkElement)sender).DataContext as Jelo;
            if (vl != null)
            {
                factory.ObrisiJelo(vl.Naziv);
                UcitajSvaJela();
            }
        }

        private void ButtonSacuvaj_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (NazivTextBox.Text != "" && CenaTextBox.Text != "" && SastojciTextBox.Text != "" && KuvarJmbgTextBox.Text != "")
                    factory.DodajJelo(NazivTextBox.Text, Int32.Parse(CenaTextBox.Text), SastojciTextBox.Text, KuvarJmbgTextBox.Text);
            }
            catch
            {
                MessageBox.Show("Greska!", "Popunite sva polja!", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            UcitajSvaJela();
        }

        private void ButtonMenjaj_Click(object sender, RoutedEventArgs e)
        {
            var vl = ((FrameworkElement)sender).DataContext as Jelo;
            if (vl != null)
            {
                NazivTextBox.Text = vl.Naziv;
                CenaTextBox.Text = vl.Cena.ToString();
                TipProizvodaTextBox.Text = vl.TipProizvoda;
                SastojciTextBox.Text = vl.Sastojci;
                KuvarJmbgTextBox.Text = vl.KuvarJmbg;

                NazivTextBox.IsReadOnly = true;
                KuvarJmbgTextBox.IsReadOnly = true;
                TipProizvodaTextBox.IsReadOnly = true;
            }
        }

        private void ButtonIzmeni_Click(object sender, RoutedEventArgs e)
        {
            factory.IzmeniJelo(NazivTextBox.Text, Int32.Parse(CenaTextBox.Text), SastojciTextBox.Text);
            ResetFields();
            UcitajSvaJela();
        }

        void ResetFields()
        {

            NazivTextBox.Text = "";
            CenaTextBox.Text = "";
            SastojciTextBox.Text = "";

            NazivTextBox.IsReadOnly = false;
            KuvarJmbgTextBox.IsReadOnly = false;
        }

        private void ButtonOdustane_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
