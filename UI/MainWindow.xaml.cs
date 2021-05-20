using Microsoft.Office.Interop.Excel;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
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
using WpfProjekat.Klase;

namespace WpfProjekat
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            ComboBoxDrzave();
        }

        public bool Validacija()
        {
            bool rez = true;
            
            if(comboBoxDrzaveFilter.SelectedItem == null)
            {
                rez = false;
                borderDrzaveFilter.BorderBrush = Brushes.Red;
                labelaGreskaDrzaveFilter.Content = "Nije izabrana drzava!";
            }
            else
            {
                borderDrzaveFilter.BorderBrush = Brushes.Green;
                labelaGreskaDrzaveFilter.Content = "";
            }

            if (datePocetniFilter.SelectedDate == null)
            {
                rez = false;
                datePocetniFilter.BorderBrush = Brushes.Red;
                labelaGreskaPocetniFilter.Content = "Pocetni datum nije izabran!";
            }
            else
            {
                datePocetniFilter.BorderBrush = Brushes.Green;
                labelaGreskaPocetniFilter.Content = "";
            }

            if (dateKrajnjiFilter.SelectedDate == null)
            {
                rez = false;
                dateKrajnjiFilter.BorderBrush = Brushes.Red;
                labelaGreskaKrajnjiFilter.Content = "Krajnji datum nije izabran!";
            }
            else
            {
                dateKrajnjiFilter.BorderBrush = Brushes.Green;
                labelaGreskaKrajnjiFilter.Content = "";
            }

            return rez;
        }

        private void ComboBoxDrzave()
        {
            List<string> drzave = new List<string>();
            drzave.Add("Srbija");
            drzave.Add("Hrvatska");
            comboBoxDrzaveFilter.ItemsSource = drzave;
        }

        private void ImportButton(object sender, RoutedEventArgs e)
        {
            ImportWindow importWindow = new ImportWindow();
            importWindow.ShowDialog();
        }
       

        private void ButtonFilter_Click(object sender, RoutedEventArgs e)
        {
            if (Validacija())
            {

            }
            else
            {
                MessageBox.Show("Nisu dobro uneti podaci!", "Greska!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void ButtonRxit_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Da li zelite da napustite program?", "", MessageBoxButton.YesNo, MessageBoxImage.Question);
            Close();
        }
    }
}
