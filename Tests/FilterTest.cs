using Moq;
using NUnit.Framework;
using Server;
using Server.Klase;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
    [TestFixture]
    class FilterTest
    {
        [Test]
        public void ProveraFiltera()
        {
            Filter filter = new Filter();

            Assert.Throws<ArgumentNullException>(
               () =>
               {
                   filter.FiltriranjePodataka(null, DateTime.Now, DateTime.Now);
               });
            Assert.Throws<ArgumentNullException>(
               () =>
               {
                   filter.FiltriranjePodataka(new Drzava(), new DateTime(), DateTime.Now);
               });
            Assert.Throws<ArgumentNullException>(
               () =>
               {
                   filter.FiltriranjePodataka(new Drzava(), DateTime.Now, new DateTime());
               });
        }

        IDrzava _drzava;
        [SetUp]
        public void SetUp()
        {
            var moq = new Mock<IDrzava>();
            moq.Setup(o => o.NazivDrzave).Returns("Albanija");
            moq.Setup(o => o.SifraDrzave).Returns("AL");
            moq.Setup(o => o.NazivMernogMesta).Returns("Tirana");
            _drzava = moq.Object;
        }
        [Test]
        public void ProveraPovratneVrFiltera()
        {
            Filter filter = new Filter();
            //Drzava drzava = new Drzava(_drzava.NazivDrzave, _drzava.SifraDrzave, _drzava.NazivMernogMesta);

            Assert.IsNotNull(filter.FiltriranjePodataka(_drzava, DateTime.Parse("01-01-2018 00:00"), DateTime.Parse("02-01-2018 00:00")));
        }
    }
}
