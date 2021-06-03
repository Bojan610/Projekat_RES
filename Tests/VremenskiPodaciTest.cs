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
    public class VremenskiPodaciTest
    {
        [Test]
        [TestCase("Beograd", 1, 12, 3, 2, "01-01-2018 00:00")]
        [TestCase("Tirana", 31, 2, 5, 1.9, "01-01-2018 00:00")]
        [TestCase("Rim", 21, 1, 4, 3, "01-01-2018 00:00")]
        public void VremenskiPodaciDobriParametri(string mernoMesto, double temperatura, double atmPritisak, double vlaznostVazduha, double brzinaVetra, DateTime datum)
        {
            VremenskiPodaci vremenskiPodaci = new VremenskiPodaci(mernoMesto, temperatura, atmPritisak, vlaznostVazduha, brzinaVetra, datum);

            Assert.AreEqual(vremenskiPodaci.MernoMesto, mernoMesto);
            Assert.AreEqual(vremenskiPodaci.Temperatura, temperatura);
            Assert.AreEqual(vremenskiPodaci.AtmPritisak, atmPritisak);
            Assert.AreEqual(vremenskiPodaci.VlaznostVazduha, vlaznostVazduha);
            Assert.AreEqual(vremenskiPodaci.BrzinaVetra, brzinaVetra);
            Assert.AreEqual(vremenskiPodaci.Datum, datum);
        }

        [Test]
        [TestCase("", 1, 12, 3, 2, "01-01-2018 00:00")]
        [TestCase("Tirana", 31, -2, 5, 1.9, "01-01-2018 00:00")]
        [TestCase("Rim", 21, 1, -4, 3, "01-01-2018 00:00")]
        [TestCase("Stokholm", -5, 4, 2, -3, "01-01-2018 00:00")]
        [TestCase("stokholm", -5, 4, 2, -3, "01-01-2018 00:00")]
        [ExpectedException(typeof(ArgumentException))]
        public void VremenskiPodaciLosiParametri(string mernoMesto, double temperatura, double atmPritisak, double vlaznostVazduha, double brzinaVetra, DateTime datum)
        {
            VremenskiPodaci vremenskiPodaci = new VremenskiPodaci(mernoMesto, temperatura, atmPritisak, vlaznostVazduha, brzinaVetra, datum);
        }

        [Test]
        [TestCase(null, 1, 12, 3, 2, "01-01-2018 00:00")]
        [TestCase(null, 31, 2, 5, 1.9, "01-01-2018 00:00")]
        [TestCase("Beograd", 21, 1, 4, 3, null)]
        [ExpectedException(typeof(ArgumentNullException))]
        public void VremenskiPodaciNullParametri(string mernoMesto, double temperatura, double atmPritisak, double vlaznostVazduha, double brzinaVetra, DateTime datum)
        {
            VremenskiPodaci vremenskiPodaci = new VremenskiPodaci(mernoMesto, temperatura, atmPritisak, vlaznostVazduha, brzinaVetra, datum);
        }
    }
}
