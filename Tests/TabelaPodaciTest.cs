using NUnit.Framework;
using Server.Klase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
    [TestFixture]
    class TabelaPodaciTest
    {
        [Test]
        [TestCase("Srbija", "SE", "Beograd", "01-01-2018 00:00", 1110, 12, 3, 5, 2)]
        [TestCase("Spanija", "SP", "Madrid", "01-01-2018 00:00", 1110, 30, 1.1, 5.2, 2)]
        [TestCase("Austrija", "AU", "Bec", "01-01-2018 00:00", 2310, 15, 2, 4, 1)]
        public void TabelaPodaciDobriParametri(string nazivDrzave, string sifraDrzave, string mernoMesto, DateTime uctVreme, double kolicinaEnergije, double temperatura, double atmPritisak, double vlazVazduha, double brzinaVetra)
        {
            TabelaPodaci tabelaPodaci = new TabelaPodaci(nazivDrzave, sifraDrzave, mernoMesto, uctVreme, kolicinaEnergije, temperatura, atmPritisak, vlazVazduha, brzinaVetra);

            Assert.AreEqual(tabelaPodaci.NazivDrzave, nazivDrzave);
            Assert.AreEqual(tabelaPodaci.SifraDrzave, sifraDrzave);
            Assert.AreEqual(tabelaPodaci.MernoMesto, mernoMesto);
            Assert.AreEqual(tabelaPodaci.UctVreme, uctVreme);
            Assert.AreEqual(tabelaPodaci.KolicinaEnergije, kolicinaEnergije);
            Assert.AreEqual(tabelaPodaci.Temperatura, temperatura);
            Assert.AreEqual(tabelaPodaci.AtmPritisak, atmPritisak);
            Assert.AreEqual(tabelaPodaci.VlazVazduha, vlazVazduha);
            Assert.AreEqual(tabelaPodaci.BrzinaVetra, brzinaVetra);
        }

        [Test]
        [TestCase("", "SP", "Madrid", "01-01-2018 00:00", 1110, 12, 3, 5, 2)]
        [TestCase("Spanija", "", "Madrid", "01-01-2018 00:00", 1110, 12, 3, 5, 2)]
        [TestCase("Spanija", "SP", "", "01-01-2018 00:00", 1110, 12, 3, 5, 2)]
        [TestCase("Spanija", "SP", "Madrid", "01-01-2018 00:00", -12, 12, 3, 5, 2)]
        [TestCase("Spanija", "SP", "Madrid", "01-01-2018 00:00", 12, 12, -3, 5, 2)]
        [TestCase("Spanija", "SP", "Madrid", "01-01-2018 00:00", 12, 12, 3, -5, 2)]
        [TestCase("Spanija", "SP", "Madrid", "01-01-2018 00:00", 12, 12, 3, 5, -2)]
        [TestCase("srbija", "SE", "Beograd", "01-01-2018 00:00", 1110, 12, 3, 5, 2)]
        [TestCase("Srbija", "Se", "Beograd", "01-01-2018 00:00", 1110, 12, 3, 5, 2)]
        [TestCase("Srbija", "sE", "Beograd", "01-01-2018 00:00", 1110, 12, 3, 5, 2)]
        [TestCase("Srbija", "SEr", "Beograd", "01-01-2018 00:00", 1110, 12, 3, 5, 2)]
        [TestCase("Srbija", "SE", "beograd", "01-01-2018 00:00", 1110, 12, 3, 5, 2)]
        [ExpectedException(typeof(ArgumentException))]
        public void TabelaPodaciLosiParametri(string nazivDrzave, string sifraDrzave, string mernoMesto, DateTime uctVreme, double kolicinaEnergije, double temperatura, double atmPritisak, double vlazVazduha, double brzinaVetra)
        {
            TabelaPodaci tabelaPodaci = new TabelaPodaci(nazivDrzave, sifraDrzave, mernoMesto, uctVreme, kolicinaEnergije, temperatura, atmPritisak, vlazVazduha, brzinaVetra);
        }

        [Test]
        [TestCase(null, "SP", "Madrid", "01-01-2018 00:00", 1110, 12, 3, 5, 2)]
        [TestCase("Spanija", null, "Madrid", "01-01-2018 00:00", 1110, 12, 3, 5, 2)]
        [TestCase("Spanija", "SP", null, "01-01-2018 00:00", 1110, 12, 3, 5, 2)]
        [TestCase("Spanija", "SP", "Madrid", null, 1110, 12, 3, 5, 2)]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TabelaPodaciNullParametri(string nazivDrzave, string sifraDrzave, string mernoMesto, DateTime uctVreme, double kolicinaEnergije, double temperatura, double atmPritisak, double vlazVazduha, double brzinaVetra)
        {
            TabelaPodaci tabelaPodaci = new TabelaPodaci(nazivDrzave, sifraDrzave, mernoMesto, uctVreme, kolicinaEnergije, temperatura, atmPritisak, vlazVazduha, brzinaVetra);
        }
    }
}
