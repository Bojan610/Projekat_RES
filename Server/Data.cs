using Server.Klase;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    public class Data
    {
        public static List<VremenskiPodaci> UcitavanjeVremenskihPodataka(string path)
        {
            List<VremenskiPodaci> lista = new List<VremenskiPodaci>();

            FileStream stream = new FileStream(path, FileMode.Open);
            StreamReader sr = new StreamReader(stream);
            string line = "";
            while ((line = sr.ReadLine()) != null)
            {
                string[] tokens = line.Split(',', '\n');

                VremenskiPodaci vp = new VremenskiPodaci(tokens[0], Double.Parse(tokens[1]), Double.Parse(tokens[2]), Double.Parse(tokens[3]), Double.Parse(tokens[4]), DateTime.Parse(tokens[5]));
                lista.Add(vp);

                for (int i = 6; i < tokens.Length; i++)
                {
                    if (i % 6 == 0)
                    {
                        VremenskiPodaci pom = new VremenskiPodaci(tokens[i], Double.Parse(tokens[i + 1]), Double.Parse(tokens[i + 2]), Double.Parse(tokens[i + 3]), Double.Parse(tokens[i + 4]), DateTime.Parse(tokens[i + 5]));
                        lista.Add(pom);
                    }
                }
            }

            sr.Close();
            stream.Close();

            return lista;
        }

        public static List<Potrosnja> UcitavanjePotrosnje(string path)
        {
            List<Potrosnja> lista = new List<Potrosnja>();

            //path = HostingEnvironment.MapPath(path);
            FileStream stream = new FileStream(path, FileMode.Open);
            StreamReader sr = new StreamReader(stream);
            string line = "";
            while ((line = sr.ReadLine()) != null)
            {
                string[] tokens = line.Split(',', '\n');

                Potrosnja p = new Potrosnja(tokens[0], tokens[1], DateTime.Parse(tokens[2]), Double.Parse(tokens[3]));
                lista.Add(p);

                for (int i = 4; i < tokens.Length; i++)
                {
                    if (i % 4 == 0)
                    {
                        Potrosnja pom = new Potrosnja(tokens[i], tokens[i + 1], DateTime.Parse(tokens[i + 2]), Double.Parse(tokens[i + 3]));
                        lista.Add(pom);
                    }
                }
            }

            sr.Close();
            stream.Close();

            return lista;
        }

        public static void CuvajPodatke(List<Potrosnja> lista, List<VremenskiPodaci> vremenskiPodaci)
        {
            string path = "C:\\Users\\bojan\\Desktop\\6. semestar\\Razvoj softvera\\Projekat\\Projekat_RES\\Server\\ulazni_podaci\\tabela.csv";
            string csv = "";

            string pom = "";

            foreach (var potrosnja in lista)
            {
                foreach (var item in vremenskiPodaci)
                {
                    foreach (var d in Drzava.drzave)
                    {
                        if (potrosnja.NazivDrzave == d.NazivDrzave)
                        {
                            pom = d.NazivMernogMesta;
                        }

                        if (pom == item.MernoMesto)
                        {
                            pom = "";
                            string pomDatum1 = potrosnja.UctVreme.ToString().Substring(0, 10);
                            string pomDatum2 = item.Datum.ToString().Substring(0, 10);
                            if (pomDatum1 == pomDatum2)
                            {
                                if (csv != "")
                                {
                                    csv = csv + "\n" + String.Format($"{potrosnja.NazivDrzave}," +
                                                             $"{potrosnja.SifraDrzave}," +
                                                             $"{item.MernoMesto}," +
                                                             $"{potrosnja.UctVreme}," +
                                                             $"{potrosnja.KolicinaEnergije}," +
                                                             $"{item.Temperatura}," +
                                                             $"{item.AtmPritisak}," +
                                                             $"{item.VlaznostVazduha}," +
                                                             $"{item.BrzinaVetra}"); break;
                                }
                                else
                                {
                                    csv = String.Format($"{potrosnja.NazivDrzave}," +
                                                             $"{potrosnja.SifraDrzave}," +
                                                             $"{item.MernoMesto}," +
                                                             $"{potrosnja.UctVreme}," +
                                                             $"{potrosnja.KolicinaEnergije}," +
                                                             $"{item.Temperatura}," +
                                                             $"{item.AtmPritisak}," +
                                                             $"{item.VlaznostVazduha}," +
                                                             $"{item.BrzinaVetra}"); break;
                                }
                            }
                        }
                    }
                }
            }

            File.WriteAllText(path, csv);
        }

        public static List<TabelaPodaci> UcitavanjeTabele()
        {
            List<TabelaPodaci> lista = new List<TabelaPodaci>();

            string path = "C:\\Users\\bojan\\Desktop\\6. semestar\\Razvoj softvera\\Projekat\\Projekat_RES\\Server\\ulazni_podaci\\tabela.csv";
            FileStream stream = new FileStream(path, FileMode.Open);
            StreamReader sr = new StreamReader(stream);
            string line = "";
            while ((line = sr.ReadLine()) != null)
            {
                string[] tokens = line.Split(',', '\n');

                for (int i = 0; i < tokens.Length; i++)
                {
                    if (i == 0 || i % 9 == 0)
                    {
                        TabelaPodaci tp = new TabelaPodaci(tokens[i], tokens[i + 1], tokens[i + 2], DateTime.Parse(tokens[i + 3]), Double.Parse(tokens[i + 4]), Double.Parse(tokens[i + 5]), Double.Parse(tokens[i + 6]), Double.Parse(tokens[i + 7]), Double.Parse(tokens[i + 8]));
                        lista.Add(tp);
                    }
                }
            }

            sr.Close();
            stream.Close();

            return lista;
        }
    }
}
