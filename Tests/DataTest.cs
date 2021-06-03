using NUnit.Framework;
using Server;
using Server.Klase;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
    [TestFixture]
    class DataTest
    {
        //TESTOVI ZA UCITAVANJE POTROSNJE ENERGIJE------------------------------------------------------------------------------------
        [Test]
        [TestCase(null)]
        [TestCase("")]
        public void ProveraUcitavanjePotrosnje(string path)
        {
            Data data = new Data();

            Assert.AreEqual(null, data.UcitavanjePotrosnje(path));
            Assert.AreEqual(null, data.UcitavanjePotrosnje(path));
        }

        [Test]
        [TestCase("aaa")]
        public void ProveraPutanjePotrosnja(string path)
        {
            Data data = new Data();

            Assert.Throws<FileNotFoundException>(
                   () =>
                   {
                       data.UcitavanjePotrosnje(path);
                   });
        }

        [Test]
        [TestCase("C:\\Users\\PC\\Desktop\\resProjekat\\Projekat_RES-master\\Server\\ulazni_podaci\\potrosnja energije\\podaci_o_potrosnji.csv")]
        public void ProveraPovratneVrPotrosnje(string path)
        {
            Data data = new Data();
            Assert.IsNotNull(data.UcitavanjePotrosnje(path));
        }

        //TESTOVI ZA UCITAVANJE VREMENSKIH PODATAKA------------------------------------------------------------------------------------
        [Test]
        [TestCase(null)]
        [TestCase("")]
        public void ProveraUcitavanjeVremenskihPodataka(string path)
        {
            Data data = new Data();

            Assert.AreEqual(null, data.UcitavanjeVremenskihPodataka(path));
            Assert.AreEqual(null, data.UcitavanjeVremenskihPodataka(path));
        }

        [Test]
        [TestCase("aaaa")]
        public void ProveraPutanjeVremenskihPodataka(string path)
        {
            Data data = new Data();

            Assert.Throws<FileNotFoundException>(
                   () =>
                   {
                       data.UcitavanjeVremenskihPodataka(path);
                   });
        }

        [Test]
        [TestCase("C:\\Users\\PC\\Desktop\\resProjekat\\Projekat_RES-master\\Server\\ulazni_podaci\\vremenski podaci\\vremenski_podaci.csv")]
        public void ProveraPovratneVrVremenskihPodataka(string path)
        {
            Data data = new Data();
            Assert.IsNotNull(data.UcitavanjeVremenskihPodataka(path));
        }

        //TESTOVI ZA CUVANJE PODATAKA U tabela.csv FAJLU------------------------------------------------------------------------------------
        [Test]
        public void ProveraPovratneVrCuvajPodatke()
        {
            Data data = new Data();

            //List<Potrosnja> pom1 = new List<Potrosnja>();
            //List<VremenskiPodaci> pom2 = new List<VremenskiPodaci>();
            //pom1.Add(new Potrosnja("Albanija", "AL", DateTime.Parse("31-12-2016  11:00"), 1000));
            //pom2.Add(new VremenskiPodaci("Tirana", 3, 771.1, 41, 2, DateTime.Parse("31-12-2016  11:00")));
            Drzava.drzave.Add(new Drzava("Albanija", "AL", "Tirana"));
            
            var pom1 = data.UcitavanjePotrosnje("C:\\Users\\PC\\Desktop\\resProjekat\\Projekat_RES-master\\Server\\ulazni_podaci\\potrosnja energije\\podaci_o_potrosnji.csv");
            var pom2 = data.UcitavanjeVremenskihPodataka("C:\\Users\\PC\\Desktop\\resProjekat\\Projekat_RES-master\\Server\\ulazni_podaci\\vremenski podaci\\vremenski_podaci.csv");

            string csv = "Albanija,AL,Tirana,31-Dec-16 11:00:00 AM,1000,3,771.1,41,2\n" +
                         "Albanija,AL,Tirana,31-Dec-16 12:00:00 PM,1000,5,772.1,31,2";
            Assert.AreEqual(csv, data.CuvajPodatke(pom1, pom2));
            Assert.AreEqual(null, data.CuvajPodatke(new List<Potrosnja>(), null));
            Assert.AreEqual(null, data.CuvajPodatke(null, new List<VremenskiPodaci>()));
            Assert.AreEqual(null, data.CuvajPodatke(null, null));
        }

        //TESTOVI ZA UCITAVANJE TABELE------------------------------------------------------------------------------------
        [Test]
        [TestCase(null)]
        [TestCase("")]
        public void ProveraUcitavanjeTabele(string path)
        {
            Data data = new Data();

            Assert.AreEqual(null, data.UcitavanjeTabele(path));
            Assert.AreEqual(null, data.UcitavanjeTabele(path));
            Assert.AreEqual(null, data.UcitavanjeTabele(path));
        }

        [Test]
        [TestCase("aaa")]
        public void ProveraPutanje(string path)
        {
            Data data = new Data();

            Assert.Throws<FileNotFoundException>(
                   () =>
                   {
                       data.UcitavanjeTabele(path);
                   });
        }

        [Test]
        [TestCase("C:\\Users\\PC\\Desktop\\resProjekat\\Projekat_RES-master\\Server\\ulazni_podaci\\tabela.csv")]
        public void ProveraPovratneVrUcitavanjeTabele(string path)
        {
            Data data = new Data();
            Assert.IsNotNull(data.UcitavanjeTabele(path));
        }
    }
}
