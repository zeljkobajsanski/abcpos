using System;
using System.ComponentModel;
using AbcPos.Core.Interfaces;
using AbcPos.Core.Models;
using AbcPos.Kasa.Models;
using AbcPos.Kasa.SyncService;
using AbcPos.Kasa.ViewModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using ISyncService = AbcPos.Kasa.Services.ISyncService;

namespace AbcPos.UnitTests.AbcPos.Kasa.ViewModels
{
    [TestClass]
    public class RacunViewModelFixtures
    {
        private readonly Mock<ILocalRepository> fRepository = new Mock<ILocalRepository>();

        private RacunViewModel fViewModel;
        private Mock<global::AbcPos.Kasa.Services.ISyncService> fSyncService;
        private KonfiguracijaKase fKonfiguracijaKase;

        [TestInitialize]
        public void TestInit()
        {
            fKonfiguracijaKase = new KonfiguracijaKase {ProdavnicaID = 1};
            fRepository.Setup(x => x.VratiKonfiguracijuKase()).Returns(fKonfiguracijaKase);
            fSyncService = new Mock<ISyncService>();
            fViewModel = new RacunViewModel(fRepository.Object, fSyncService.Object);
        }

        [TestMethod]
        public void DodajStavkuBezObziraNaZalihe()
        {
            // Arrange
            fKonfiguracijaKase.DozvoljeneNegativneZalihe = true;
            var zaliha = new Zaliha() {TrenutnaZaliha = 1};
            fRepository.Setup(x => x.VratiZalihuArtikla(1, fKonfiguracijaKase.ProdavnicaID)).Returns(zaliha);
            fViewModel.Artikal = new Artikal {ID = 1};
            fViewModel.Kolicina = 3;
         
            // Act
            fViewModel.PrihvatiKolicinu();

            // Assert
            Assert.AreEqual(-2, zaliha.TrenutnaZaliha);
            fRepository.Verify(x => x.SacuvajZalihu(zaliha)); 
            Assert.AreEqual(1, fViewModel.Racun.StavkeRacuna.Count);
            Assert.IsNull(fViewModel.Artikal);
            Assert.IsNull(fViewModel.StavkaRacuna);
        }

        [TestMethod][ExpectedException(typeof(Exception))]
        public void DodajStavkuKadaZalihaNijeDovoljna()
        {
            // Arrange
            fKonfiguracijaKase.DozvoljeneNegativneZalihe = false;
            var zaliha = new Zaliha() {TrenutnaZaliha = 1};
            fRepository.Setup(x => x.VratiZalihuArtikla(1, fKonfiguracijaKase.ProdavnicaID)).Returns(zaliha);
            fRepository.Setup(x => x.SacuvajZalihu(zaliha));
            fViewModel.Artikal = new Artikal { ID = 1 };
            fViewModel.Kolicina = 3;

            // Act
            fViewModel.PrihvatiKolicinu();
        }

        [TestMethod]
        public void DodajStavkuKadaJeZalihaDovoljna()
        {
            // Arrange
            fKonfiguracijaKase.DozvoljeneNegativneZalihe = false;
            var zaliha = new Zaliha() { TrenutnaZaliha = 3 };
            fRepository.Setup(x => x.VratiZalihuArtikla(1, fKonfiguracijaKase.ProdavnicaID)).Returns(zaliha);
            fViewModel.Artikal = new Artikal { ID = 1 };
            fViewModel.Kolicina = 3;

            // Act
            fViewModel.PrihvatiKolicinu();

            // Assert
            Assert.AreEqual(0, zaliha.TrenutnaZaliha);
            fRepository.Verify(x => x.SacuvajZalihu(zaliha));
            Assert.AreEqual(1, fViewModel.Racun.StavkeRacuna.Count);
            Assert.IsNull(fViewModel.Artikal);
            Assert.IsNull(fViewModel.StavkaRacuna);
        }

        [TestMethod]
        public void IzmeniKolicinuKadaJeZalihaDovoljna()
        {
            var zaliha = new Zaliha() { TrenutnaZaliha = 0 };
            fRepository.Setup(x => x.VratiZalihuArtikla(1, fKonfiguracijaKase.ProdavnicaID)).Returns(zaliha);
            var stavka = new StavkaRacuna(){Artikal = new Artikal(){ID = 1}, Kolicina = 4};
            fViewModel.StavkaRacuna = stavka;
            fViewModel.Kolicina = 3;

            // Act
            fViewModel.PrihvatiKolicinu();

            // Assert
            Assert.AreEqual(1, zaliha.TrenutnaZaliha);
            fRepository.Verify(x => x.SacuvajZalihu(zaliha));
            Assert.AreEqual(3, stavka.Kolicina);
            Assert.IsNull(fViewModel.Artikal);
            Assert.IsNull(fViewModel.StavkaRacuna);
        }

        [TestMethod][ExpectedException(typeof(Exception))]
        public void IzmeniKolicinuKadaZalihaNijeDovoljna()
        {
            var zaliha = new Zaliha() { TrenutnaZaliha = 2 };
            fRepository.Setup(x => x.VratiZalihuArtikla(1, fKonfiguracijaKase.ProdavnicaID)).Returns(zaliha);
            var stavka = new StavkaRacuna() { Artikal = new Artikal() { ID = 1 }, Kolicina = 3 };
            fViewModel.StavkaRacuna = stavka;
            fViewModel.Kolicina = 6;

            // Act
            fViewModel.PrihvatiKolicinu();
        }

        [TestMethod]
        public void PromeniArtikalStavke()
        {
            var zaliha = new Zaliha() { TrenutnaZaliha = 2 };
            var zalihaNovogArtikla = new Zaliha() { TrenutnaZaliha = 4 };
            fRepository.Setup(x => x.VratiZalihuArtikla(1, fKonfiguracijaKase.ProdavnicaID)).Returns(zaliha);
            fRepository.Setup(x => x.VratiZalihuArtikla(2, fKonfiguracijaKase.ProdavnicaID)).Returns(zalihaNovogArtikla);
            var stavka = new StavkaRacuna() { Artikal = new Artikal() { ID = 1 }, Kolicina = 3 };
            fViewModel.StavkaRacuna = stavka;
            fViewModel.Artikal = new Artikal {ID = 2};
            fViewModel.Kolicina = 3;

            // Act
            fViewModel.PrihvatiKolicinu();

            // Assert
            zaliha.TrenutnaZaliha = 5;
            zalihaNovogArtikla.TrenutnaZaliha = 1;
            fRepository.Verify(x => x.SacuvajZalihu(zaliha));
            fRepository.Verify(x => x.SacuvajZalihu(zalihaNovogArtikla));
            Assert.IsNull(fViewModel.Artikal);
            Assert.IsNull(fViewModel.StavkaRacuna);
        }

        [TestMethod]
        public void VratiZalihe()
        {
            // Arrange
            var zaliha1 = new Zaliha() {TrenutnaZaliha = 3};
            var zaliha2 = new Zaliha() {TrenutnaZaliha = 15};
            var racun = new Racun
                            {
                                StavkeRacuna = new BindingList<StavkaRacuna>()
                                                   {
                                                       new StavkaRacuna() {Artikal = new Artikal {ID = 1}, Kolicina = 4},
                                                       new StavkaRacuna() {Artikal = new Artikal {ID = 2}, Kolicina = 3},
                                                   }
                            };
            fViewModel.Racun = racun;
            fRepository.Setup(x => x.VratiZalihuArtikla(1, fKonfiguracijaKase.ProdavnicaID)).Returns(zaliha1);
            fRepository.Setup(x => x.VratiZalihuArtikla(2, fKonfiguracijaKase.ProdavnicaID)).Returns(zaliha2);
            
            // Act
            fViewModel.VratiZalihe();

            // Assert
            Assert.AreEqual(7, zaliha1.TrenutnaZaliha);
            Assert.AreEqual(18, zaliha2.TrenutnaZaliha);
            fRepository.Verify(x => x.Submit()); 
            
        }

        [TestMethod]
        public void UnesiNegativnuKolicinu()
        {
            fKonfiguracijaKase.DozvoljeneNegativneZalihe = false;
            var zaliha = new Zaliha() { TrenutnaZaliha = 1 };
            fRepository.Setup(x => x.VratiZalihuArtikla(1, fKonfiguracijaKase.ProdavnicaID)).Returns(zaliha);
            fRepository.Setup(x => x.SacuvajZalihu(zaliha));
            fViewModel.Artikal = new Artikal { ID = 1 };
            fViewModel.Kolicina = -3;

            // Act
            fViewModel.PrihvatiKolicinu();

            // Assert
            Assert.AreEqual(4, zaliha.TrenutnaZaliha);
            Assert.AreEqual(-3, fViewModel.Racun.StavkeRacuna[0].Kolicina);
        }
    }
}