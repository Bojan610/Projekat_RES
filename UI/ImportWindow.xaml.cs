using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Data;
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

namespace WpfProjekat
{
    /// <summary>
    /// Interaction logic for ImportWindow.xaml
    /// </summary>
    public partial class ImportWindow : Window
    {
        public ImportWindow()
        {
            InitializeComponent();
            this.DataContext = new Server.ViewModel.ImportViewModel();
        }

        /*public bool Validacija()
        {
            bool rez = true;

            if(comboBoxDrzave.SelectedItem == null)
            {
                rez = false;
                borderDrzava.BorderBrush = Brushes.Red;
                labelaGreskaDrzava.Content = "Nije izabrana drzava!";
            }
            else
            {
                borderDrzava.BorderBrush = Brushes.Green;
                labelaGreskaDrzava.Content = "";
            }

            if(datePocetni.SelectedDate == null)
            {
                rez = false;
                datePocetni.BorderBrush = Brushes.Red;
                labelaGreskaPocetniDatum.Content = "Pocetni datum nije izabran!";
            }
            else
            {
                datePocetni.BorderBrush = Brushes.Green;
                labelaGreskaPocetniDatum.Content = "";
            }

            if (dateKrajnji.SelectedDate == null)
            {
                rez = false;
                dateKrajnji.BorderBrush = Brushes.Red;
                labelaGreskaKrajnjiDatum.Content = "Krajnji datum nije izabran!";
            }
            else
            {
                dateKrajnji.BorderBrush = Brushes.Green;
                labelaGreskaKrajnjiDatum.Content = "";
            }

            if(labelaPotvrdaPotrosnja.Content == "")
            {
                rez = false;
                buttonPotrosnja.BorderBrush = Brushes.Red;
                labelaGreskaPotrosnja.Content = "Nije ucitan file o potrosnji!";
            }
            else
            {
                buttonPotrosnja.BorderBrush = Brushes.Green;
                labelaGreskaPotrosnja.Content = "";
            }

            if (labelaPotvrdaVreme.Content == "")
            {
                rez = false;
                buttonVreme.BorderBrush = Brushes.Red;
                labelaGreskaVreme.Content = "Nije ucitan file o vremenu!";
            }
            else
            {
                buttonVreme.BorderBrush = Brushes.Green;
                labelaGreskaVreme.Content = "";
            }

            return rez;
        }

        private void ComboBoxDrzave_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void ButtonPotrosnja_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();
            op.Title = "Select a file";
            op.Filter = "All files (*.*)|*.*";

            if (op.ShowDialog() == true)
            {
                string fileName = op.FileName;
                string path = System.IO.Path.GetFullPath(op.FileName);
                labelaPotvrdaPotrosnja.Content = op.FileName;
                
            }
        }

        private void ButtonVreme_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();
            op.Title = "Select a file";
            op.Filter = "All files (*.*)|*.*";

            if (op.ShowDialog() == true)
            {
                string fileName = op.FileName;
                string path = System.IO.Path.GetFullPath(op.FileName);
                labelaPotvrdaVreme.Content = fileName;
                
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (Validacija())
            {

            }
            else
            {
                MessageBox.Show("Polja nisu dobro popunjena!", "Greska!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }*/
    }
}
