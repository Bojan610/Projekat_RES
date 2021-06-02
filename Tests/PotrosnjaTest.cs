using EvidencijaPotrosnjeIVremenskihParametara.Klase;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
    [TestFixture]
    public class PotrosnjaTest
    {
        [Test]
        [TestCase("Srbija", "SE", null, 1234)]
        [TestCase("Nemacka", "DE", null, 3344)]
        [TestCase("Spanija", "SP", null, 1000)]
        public void PotrosnjaDobriParametri(string nazivDrzave, string sifraDrzave, DateTime uctVreme,double kolicinaEnergije)
        {
            Potrosnja potrosnja = new Potrosnja(nazivDrzave, sifraDrzave, uctVreme, kolicinaEnergije);

            Assert.AreEqual(potrosnja.NazivDrzave, nazivDrzave);
            Assert.AreEqual(potrosnja.SifraDrzave, sifraDrzave);
            Assert.AreEqual(potrosnja.KolicinaEnergije, kolicinaEnergije);
        }

        [Test]
        [TestCase("", "SE", null, 1234)]
        [TestCase("Nemacka", "", null, 3344)]
        [TestCase("Spanija", "SP", null, -1)]
        [TestCase("srbija", "SE", null, 1000)]
        [TestCase("Srbija", "sE", null, 1000)]
        [TestCase("Svajcarska", "Sw", null, 2350)]
        [TestCase("Rumunija", "ro", null, 1300)]
        [TestCase("Francuska", "FRA", null, 123)]
        [ExpectedException(typeof(ArgumentException))]
        public void PotrosnjaLosiParametri(string nazivDrzave, string sifraDrzave, DateTime uctVreme, double kolicinaEnergije)
        {
            Potrosnja potrosnja = new Potrosnja(nazivDrzave, sifraDrzave, uctVreme, kolicinaEnergije);
        }

        [Test]
        [TestCase(null, "SE", null, 0)]
        [TestCase("Srbija", null, null, 0)]
        [ExpectedException(typeof(ArgumentNullException))]
        public void PotrosnjaNullParametri(string nazivDrzave, string sifraDrzave, DateTime uctVreme, double kolicinaEnergije)
        {
            Potrosnja potrosnja = new Potrosnja(nazivDrzave, sifraDrzave, uctVreme, kolicinaEnergije);
        }
    }
}
