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
    /// Interaction logic for Proizvodi.xaml
    /// </summary>
    public partial class Proizvodi : Window
    {
        private IProizvodiCRUD factory;
        public BindingList<Proizvod> proizvodi { get; set; }

        public Proizvodi()
        {
            factory = new ProizvodiCRUD();
            InitializeComponent();
            UcitajSveProizvode();
        }


        private void UcitajSveProizvode()
        {
            proizvodi = new BindingList<Proizvod>(factory.UcitajSveProizvode());
            ProizvodiList.ItemsSource = proizvodi;
        }

        private void ButtonObrisi_Click(object sender, RoutedEventArgs e)
        {
            var vl = ((FrameworkElement)sender).DataContext as Proizvod;
            if (vl != null)
            {
                factory.ObrisiProizvod(vl.Naziv);
                UcitajSveProizvode();
            }
        }

        private void ButtonSacuvaj_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (NazivTextBox.Text != "" && CenaTextBox.Text != "" && TipProizvodaTextBox.Text != "" && DodatnoTextBox.Text != "" )
                    factory.DodajProizvod(NazivTextBox.Text, Int32.Parse(CenaTextBox.Text), TipProizvodaTextBox.Text, DodatnoTextBox.Text, KuvarJmbgTextBox.Text);
            }
            catch
            {
                MessageBox.Show("Greska!", "Popunite sva polja!", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            UcitajSveProizvode();
        }

        private void ButtonMenjaj_Click(object sender, RoutedEventArgs e)
        {
            var vl = ((FrameworkElement)sender).DataContext as Proizvod;
            if (vl != null)
            {
                NazivTextBox.Text = vl.Naziv;
                CenaTextBox.Text = vl.Cena.ToString();
                TipProizvodaTextBox.Text = vl.TipProizvoda;
                if (TipProizvodaTextBox.Text == "Jelo"){
                    DodatnoTextBox.Text = ((Jelo)vl).Sastojci;
                    KuvarJmbgTextBox.Text = ((Jelo)vl).KuvarJmbg;
                }
                else
                {
                    DodatnoTextBox.Text = ((Pice)vl).Velicina;
                    KuvarJmbgTextBox.Text = "";
                }

                NazivTextBox.IsReadOnly = true;
                TipProizvodaTextBox.IsReadOnly = true;
                KuvarJmbgTextBox.IsReadOnly = true;
            }
        }

        private void ButtonIzmeni_Click(object sender, RoutedEventArgs e)
        {
            factory.IzmeniProizvod(NazivTextBox.Text, Int32.Parse(CenaTextBox.Text), DodatnoTextBox.Text);
            ResetFields();
            UcitajSveProizvode();
        }

        void ResetFields()
        {

            NazivTextBox.Text = "";
            CenaTextBox.Text = "";
            TipProizvodaTextBox.Text = "";
            DodatnoTextBox.Text = "";
            KuvarJmbgTextBox.Text = "";

            NazivTextBox.IsReadOnly = false;
            TipProizvodaTextBox.IsReadOnly = false;
            KuvarJmbgTextBox.IsReadOnly = false;
        }

        private void ButtonOdustane_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
