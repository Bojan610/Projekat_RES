using Microsoft.Win32;
using Server;
using Server.Klase;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
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
using System.Windows.Shapes;

namespace EvidencijaPotrosnjeIVremenskihParametara
{
    /// <summary>
    /// Interaction logic for ImportWindow.xaml
    /// </summary>
    [ExcludeFromCodeCoverage]
    public partial class ImportWindow : Window
    {
        public ImportWindow()
        {
            InitializeComponent();

            ComboBoxDrzaveImport();

            DataContext = this;
        }

        public bool Validacija()
        {
            bool rez = true;

            if (comboBoxDrzave.SelectedItem == null)
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

            if (datePocetni.SelectedDate == null)
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

            if (labelaPotvrdaPotrosnja.Content.ToString() == "-")
            {
                rez = false;
                labelaGreskaPotrosnja.Content = "Ucitati file o potrosnji!";
            }
            else
            {
                buttonPotrosnja.BorderBrush = Brushes.Green;
                labelaGreskaPotrosnja.Content = "";
            }

            if (labelaPotvrdaVreme.Content.ToString() == "-")
            {
                rez = false;
                labelaGreskaVreme.Content = "Ucitati file o vremenu!";
            }
            else
            {
                buttonVreme.BorderBrush = Brushes.Green;
                labelaGreskaVreme.Content = "";
            }

            return rez;
        }
        
        private void ComboBoxDrzaveImport()
        {
            Drzava.drzave = new List<Drzava>();
            Drzava.drzave.Add(new Drzava("Srbija", "SE", "Beograd"));
            Drzava.drzave.Add(new Drzava("Albanija", "AL", "Tirana"));
            Drzava.drzave.Add(new Drzava("Nemacka", "DE", "Berlin"));
            Drzava.drzave.Add(new Drzava("Italija", "IT", "Rim"));
            Drzava.drzave.Add(new Drzava("Litvanija", "LT", "Vilnus"));
            Drzava.drzave.Add(new Drzava("Poljska", "PL", "Lodj"));
            Drzava.drzave.Add(new Drzava("Norveska", "NO", "Oslo"));
            Drzava.drzave.Add(new Drzava("Hrvatska", "HR", "Zagreb"));
            Drzava.drzave.Add(new Drzava("Holandija", "NL", "Amsterdam"));
            Drzava.drzave.Add(new Drzava("Rumunija", "RO", "Temisvar"));

            List<string> nazivi = new List<string>();
            foreach(var item in Drzava.drzave)
            {
                nazivi.Add(item.NazivDrzave);
            }
            comboBoxDrzave.ItemsSource = nazivi;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (Validacija())
            {
                List<Potrosnja> potrosnja = new List<Potrosnja>();
                Data data = new Data();

                foreach(var item in data.UcitavanjePotrosnje(labelaPotvrdaPotrosnja.Content.ToString()))
                {
                    if (comboBoxDrzave.SelectedItem.ToString() == item.NazivDrzave && item.UctVreme >= datePocetni.SelectedDate && item.UctVreme <= dateKrajnji.SelectedDate)
                    {
                        potrosnja.Add(item);
                    }
                }

                List<Drzava> listDrzave = new List<Drzava>();
              
                foreach (Drzava drzava in Drzava.drzave)
                {
                    if (comboBoxDrzave.SelectedItem.ToString() == drzava.NazivDrzave)
                    {
                        listDrzave.Add(drzava);
                        break;
                    }
                }
                

                List<VremenskiPodaci> vremenskiPodaci = new List<VremenskiPodaci>();

                foreach (var item in data.UcitavanjeVremenskihPodataka(labelaPotvrdaVreme.Content.ToString()))
                {
                    if(item.Datum >= datePocetni.SelectedDate && item.Datum <= dateKrajnji.SelectedDate)
                    {
                        vremenskiPodaci.Add(item);
                    }
                }
                
                data.CuvajPodatke(potrosnja, vremenskiPodaci);

                foreach(var item in data.UcitavanjeTabele("C:\\Users\\PC\\Desktop\\resProjekat\\Projekat_RES-master\\Server\\ulazni_podaci\\tabela.csv"))
                {
                    if(comboBoxDrzave.SelectedItem.ToString() == item.NazivDrzave)
                    {
                        MainWindow.podaci.Add(item);
                    }
                }

                BazaPodataka.BazaPodataka.UpisUBazu(potrosnja, vremenskiPodaci, listDrzave);

                this.Close();
            }
            else
            {
                MessageBox.Show("Polja nisu dobro popunjena!", "Greska!", MessageBoxButton.OK, MessageBoxImage.Error);
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
                //string path = System.IO.Path.GetFullPath(op.FileName);
                labelaPotvrdaVreme.Content = fileName;
            }
        }

        private void ButtonPotrosnja_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();
            op.Title = "Select a file";
            op.Filter = "All files (*.*)|*.*";

            if (op.ShowDialog() == true)
            {
                string fileName = op.FileName;
                //string path = System.IO.Path.GetFullPath(op.FileName);
                labelaPotvrdaPotrosnja.Content = op.FileName;

            }
        }
    }
}
