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
    /// Interaction logic for Pica.xaml
    /// </summary>
    public partial class Pica : Window
    {
        private IPicaCRUD factory;
        public BindingList<Proizvod> pica { get; set; }

        public Pica()
        {
            factory = new PicaCRUD();
            InitializeComponent();
            UcitajSvaPica();
        }


        private void UcitajSvaPica()
        {
            pica = new BindingList<Proizvod>(factory.UcitajSvaPica());
            PicaList.ItemsSource = pica;
        }

        private void ButtonObrisi_Click(object sender, RoutedEventArgs e)
        {
            var vl = ((FrameworkElement)sender).DataContext as Pice;
            if (vl != null)
            {
                factory.ObrisiPice(vl.Naziv);
                UcitajSvaPica();
            }
        }

        private void ButtonSacuvaj_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (NazivTextBox.Text != "" && CenaTextBox.Text != "" && VelicinaTextBox.Text != "")
                    factory.DodajPice(NazivTextBox.Text, Int32.Parse(CenaTextBox.Text), VelicinaTextBox.Text);
            }
            catch
            {
                MessageBox.Show("Greska!", "Popunite sva polja!", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            UcitajSvaPica();
        }

        private void ButtonMenjaj_Click(object sender, RoutedEventArgs e)
        {
            var vl = ((FrameworkElement)sender).DataContext as Pice;
            if (vl != null)
            {
                NazivTextBox.Text = vl.Naziv;
                CenaTextBox.Text = vl.Cena.ToString();
                TipProizvodaTextBox.Text = vl.TipProizvoda;
                VelicinaTextBox.Text = vl.Velicina;

                NazivTextBox.IsReadOnly = true;
                TipProizvodaTextBox.IsReadOnly = true;
                VelicinaTextBox.IsReadOnly = true;
            }
        }

        private void ButtonIzmeni_Click(object sender, RoutedEventArgs e)
        {
            factory.IzmeniPice(NazivTextBox.Text, Int32.Parse(CenaTextBox.Text), VelicinaTextBox.Text);
            ResetFields();
            UcitajSvaPica();
        }

        void ResetFields()
        {

            NazivTextBox.Text = "";
            CenaTextBox.Text = "";
            VelicinaTextBox.Text = "";

            NazivTextBox.IsReadOnly = false;
        }

        private void ButtonOdustane_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
