using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EvidencijaPotrosnjeIVremenskihParametara.Klase;

namespace Tests
{
    [TestFixture]
    public class DrzavaTest
    {
        [Test]
        [TestCase("Srbija", "SE", "Beograd")]
        [TestCase("Nemacka", "DE", "Berlin")]
        public void DrzavaDobriParametri(string nazivDrzave, string sifraDrzave, string nazivMernogMesta)
        {
            Drzava drzava = new Drzava(nazivDrzave, sifraDrzave, nazivMernogMesta);

            Assert.AreEqual(drzava.NazivDrzave, nazivDrzave);
            Assert.AreEqual(drzava.SifraDrzave, sifraDrzave);
            Assert.AreEqual(drzava.NazivMernogMesta, nazivMernogMesta);
        }

        [Test]
        [TestCase("", "SE", "Beograd")]
        [TestCase("Nemacka", "", "Berlin")]
        [TestCase("Spanija", "SP", "")]
        [TestCase("Spanija", "", "")]
        [TestCase("spanija", "SP", "Madrid")]
        [TestCase("spanija", "SP", "Madrid")]
        [TestCase("spanija", "SP", "Madrid")]
        [TestCase("spanija", "SP", "Madrid")]
        [TestCase("Spanija", "SPA", "madrid")]
        [ExpectedException(typeof(ArgumentException))]
        public void DrzavaLosiParametri(string nazivDrzave, string sifraDrzave, string nazivMernogMesta)
        {
            Drzava drzava = new Drzava(nazivDrzave, sifraDrzave, nazivMernogMesta);
        }

        [Test]
        [TestCase(null, "SE", "Beograd")]
        [TestCase("Nemacka", null, "Berlin")]
        [TestCase("Spanija", "SP", null)]
        [ExpectedException(typeof(ArgumentNullException))]
        public void DrzavaNullParametri(string nazivDrzave, string sifraDrzave, string nazivMernogMesta)
        {
            Drzava drzava = new Drzava(nazivDrzave, sifraDrzave, nazivMernogMesta);
        }
    }
}
