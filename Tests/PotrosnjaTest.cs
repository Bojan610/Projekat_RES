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
    public class PotrosnjaTest
    {
        [Test]
        [TestCase("Srbija", "SE", "01-01-2018 00:00", 1234)]
        [TestCase("Nemacka", "DE", "01-01-2018 00:00", 3344)]
        [TestCase("Spanija", "SP", "01-01-2018 00:00", 1000)]
        public void PotrosnjaDobriParametri(string nazivDrzave, string sifraDrzave, DateTime uctVreme, double kolicinaEnergije)
        {
            Potrosnja potrosnja = new Potrosnja(nazivDrzave, sifraDrzave, uctVreme, kolicinaEnergije);

            Assert.AreEqual(potrosnja.NazivDrzave, nazivDrzave);
            Assert.AreEqual(potrosnja.SifraDrzave, sifraDrzave);
            Assert.AreEqual(potrosnja.KolicinaEnergije, kolicinaEnergije);
        }

        [Test]
        [TestCase("", "SE", "01-01-2018 00:00", 1234)]
        [TestCase("Nemacka", "", "01-01-2018 00:00", 3344)]
        [TestCase("Spanija", "SP", "01-01-2018 00:00", -1)]
        [TestCase("srbija", "SE", "01-01-2018 00:00", 1000)]
        [TestCase("Srbija", "sE", "01-01-2018 00:00", 1000)]
        [TestCase("Svajcarska", "Sw", "01-01-2018 00:00", 2350)]
        [TestCase("Rumunija", "ro", "01-01-2018 00:00", 1300)]
        [TestCase("Francuska", "FRA", "01-01-2018 00:00", 123)]
        [ExpectedException(typeof(ArgumentException))]
        public void PotrosnjaLosiParametri(string nazivDrzave, string sifraDrzave, DateTime uctVreme, double kolicinaEnergije)
        {
            Potrosnja potrosnja = new Potrosnja(nazivDrzave, sifraDrzave, uctVreme, kolicinaEnergije);
        }

        [Test]
        [TestCase(null, "SE", "01-01-2018 00:00", 0)]
        [TestCase("Srbija", null, "01-01-2018 00:00", 0)]
        [TestCase("Srbija", "SE", null, 0)]
        [ExpectedException(typeof(ArgumentNullException))]
        public void PotrosnjaNullParametri(string nazivDrzave, string sifraDrzave, DateTime uctVreme, double kolicinaEnergije)
        {
            Potrosnja potrosnja = new Potrosnja(nazivDrzave, sifraDrzave, uctVreme, kolicinaEnergije);
        }
    }
}
