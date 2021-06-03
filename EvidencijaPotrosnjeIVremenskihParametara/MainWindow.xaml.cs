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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Server;
using Server.Klase;

namespace EvidencijaPotrosnjeIVremenskihParametara
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    [ExcludeFromCodeCoverage]
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
        

        private void ImportButton(object sender, RoutedEventArgs e)
        {
            ImportWindow importWindow = new ImportWindow();
            importWindow.ShowDialog();

        }


        private void ButtonFilter_Click(object sender, RoutedEventArgs e)
        {
            if (Validacija())
            {
                var brojac = 0;
                foreach (var item in Drzava.drzave)
                {
                    if (textBoxNaziv.Text == item.NazivDrzave && textBoxSifra.Text == item.SifraDrzave && textBoxMernoMesto.Text == item.NazivMernogMesta)
                    {
                        MainWindow.podaci.Clear();
                        Filter filter = new Filter();
                        foreach(var item2 in filter.FiltriranjePodataka(item, (DateTime)datePocetniFilter.SelectedDate, (DateTime)dateKrajnjiFilter.SelectedDate))
                        {
                            MainWindow.podaci.Add(item2);
                        }
                    }
                    else
                    {
                        brojac++;
                    }
                }
                if (brojac == Drzava.drzave.Count)
                {
                    MessageBox.Show("Uneta drzava ne postoji!", "Greska!", MessageBoxButton.OK, MessageBoxImage.Error);
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
            //string path = "C:\\Users\\bojan\\Desktop\\6. semestar\\Razvoj softvera\\Projekat\\Projekat_RES\\Server\\export\\export.csv";

            string path = "C:\\Users\\PC\\Desktop\\resProjekat\\Projekat_RES-master\\Server\\export\\export.csv";
            string csv = "";
            Data data = new Data();

            List<TabelaPodaci> pomLista = data.UcitavanjeTabele("C:\\Users\\PC\\Desktop\\resProjekat\\Projekat_RES-master\\Server\\ulazni_podaci\\tabela.csv");

            foreach (var item in pomLista)
            {
                if (csv != "")
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
