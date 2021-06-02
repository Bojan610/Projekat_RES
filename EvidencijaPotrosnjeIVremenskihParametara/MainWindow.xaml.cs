using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using Server;
using Server.Klase;

namespace EvidencijaPotrosnjeIVremenskihParametara
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static BindingList<TabelaPodaci> podaci { get; set; }

        public MainWindow()
        {
            if(podaci == null)
            {
                podaci = new BindingList<TabelaPodaci>();
            }
            DataContext = this;
            InitializeComponent();
        }

        public bool Validacija()
        {
            bool rez = true;

            if (textBoxNaziv.Text == "")
            {
                rez = false;
                textBoxNaziv.BorderBrush = Brushes.Red;
                labelaGreskaNazivDrzaveFilter.Content = "Naziv drzave nije popunjen!";
            }
            else
            {
                textBoxNaziv.BorderBrush = Brushes.Green;
                labelaGreskaNazivDrzaveFilter.Content = "";
            }

            if (textBoxSifra.Text == "")
            {
                rez = false;
                textBoxSifra.BorderBrush = Brushes.Red;
                labelaGreskaSifraDrzaveFilter.Content = "Sifra drzave nije popunjena!";
            }
            else
            {
                textBoxSifra.BorderBrush = Brushes.Green;
                labelaGreskaSifraDrzaveFilter.Content = "";
            }

            if (textBoxMernoMesto.Text == "")
            {
                rez = false;
                textBoxMernoMesto.BorderBrush = Brushes.Red;
                labelaGreskaMernoMestoFilter.Content = "Merno mesto nije popunjeno!";
            }
            else
            {
                textBoxMernoMesto.BorderBrush = Brushes.Green;
                labelaGreskaMernoMestoFilter.Content = "";
            }

            if (datePocetniFilter.SelectedDate == null)
            {
                rez = false;
                datePocetniFilter.BorderBrush = Brushes.Red;
                labelaGreskaDatumFilter.Content = "Datum nije izabran!";
            }
            else
            {
                datePocetniFilter.BorderBrush = Brushes.Green;
                labelaGreskaDatumFilter.Content = "";
            }

            if (dateKrajnjiFilter.SelectedDate == null)
            {
                rez = false;
                dateKrajnjiFilter.BorderBrush = Brushes.Red;
                labelaGreskaDatumFilter.Content = "Datum nije izabran!";
            }
            else
            {
                dateKrajnjiFilter.BorderBrush = Brushes.Green;
                labelaGreskaDatumFilter.Content = "";
            }

            return rez;
        }

        //private void ComboBoxDrzave()
        //{
        //    Drzava.drzave = new List<Drzava>();
        //    Drzava.drzave.Add(new Drzava("Srbija", "SE", "Beograd"));
        //    Drzava.drzave.Add(new Drzava("Albanija", "AL", "Tirana"));
        //    Drzava.drzave.Add(new Drzava("Nemacka", "DE", "Berlin"));
        //    Drzava.drzave.Add(new Drzava("Italija", "IT", "Rim"));
        //    Drzava.drzave.Add(new Drzava("Litvanija", "LT", "Vilnus"));
        //    Drzava.drzave.Add(new Drzava("Poljska", "PL", "Lodj"));
        //    Drzava.drzave.Add(new Drzava("Norveska", "NO", "Oslo"));
        //    Drzava.drzave.Add(new Drzava("Hrvatska", "HR", "Zagreb"));
        //    Drzava.drzave.Add(new Drzava("Holandija", "NL", "Amsterdam"));
        //    Drzava.drzave.Add(new Drzava("Rumunija", "RO", "Temisvar"));
        //    List<string> nazivi = new List<string>();
        //    foreach(var item in Drzava.drzave)
        //    {
        //        nazivi.Add(item.NazivDrzave);
        //    }
        //    comboBoxDrzaveFilter.ItemsSource = nazivi;
        //}

        private void ImportButton(object sender, RoutedEventArgs e)
        {
            ImportWindow importWindow = new ImportWindow();
            importWindow.ShowDialog();

        }


        private void ButtonFilter_Click(object sender, RoutedEventArgs e)
        {
            if (Validacija())
            {
                int brojac = 0;
                List<TabelaPodaci> pom = Data.UcitavanjeTabele();
                foreach (var item in pom)
                {
                    Drzava pomDrzava = new Drzava(textBoxNaziv.ToString(), textBoxSifra.ToString(), textBoxMernoMesto.ToString());

                    if (Drzava.drzave.Contains(pomDrzava))
                    {
                        if (pomDrzava.NazivDrzave == item.NazivDrzave && item.UctVreme >= datePocetniFilter.SelectedDate && item.UctVreme <= dateKrajnjiFilter.SelectedDate)
                        {
                            brojac++;
                            continue;
                        }
                        else
                        {
                            try
                            {
                                podaci.RemoveAt(brojac);
                            }
                            catch (Exception)
                            {
                                continue;
                            }
                        }
                    }
                }
                tabela.Items.Refresh();
            }
            else
            {
                MessageBox.Show("Nisu dobro uneti podaci!", "Greska!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        
        private void ButtonExport_Click(object sender, RoutedEventArgs e)
        {
           
            string path = "C:\\Users\\bojan\\Desktop\\6. semestar\\Razvoj softvera\\Projekat\\Projekat_RES\\Server\\export\\export.csv";
            string csv = "";

            List<TabelaPodaci> pomLista = Data.UcitavanjeTabele();

            foreach(var item in pomLista)
            {
                if(csv != "")
                {
                    csv = csv + "\n" + String.Format($"{item.NazivDrzave},{item.SifraDrzave},{item.MernoMesto},{item.UctVreme},{item.KolicinaEnergije},{item.Temperatura},{item.AtmPritisak},{item.VlazVazduha},{item.BrzinaVetra}");
                }
                else
                {
                    csv = String.Format($"{item.NazivDrzave},{item.SifraDrzave},{item.MernoMesto},{item.UctVreme},{item.KolicinaEnergije},{item.Temperatura},{item.AtmPritisak},{item.VlazVazduha},{item.BrzinaVetra}");
                }
            }

            File.WriteAllText(path, csv);
        }
    }
}
