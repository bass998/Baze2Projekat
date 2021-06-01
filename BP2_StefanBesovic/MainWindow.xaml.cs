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
using System.Windows.Navigation;
using System.Windows.Shapes;
using ProjectLogic;
using BP2_StefanBesovic.View;

namespace BP2_StefanBesovic
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void vlasniciBtn_Click(object sender, RoutedEventArgs e)
        {
            Vlasnici prozor = new Vlasnici();
            prozor.Show();
        }

        private void restoraniBtn_Click(object sender, RoutedEventArgs e)
        {
            Restorani prozor = new Restorani();
            prozor.Show();
        }

        private void kupciBtn_Click(object sender, RoutedEventArgs e)
        {
            Kupci prozor = new Kupci();
            prozor.Show();
        }
    }
}
