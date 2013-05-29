using System.Collections.Generic;
using System.ComponentModel;
using AbcPos.Core.Interfaces;
using AbcPos.Core.Models;
using AbcPos.Core.Repository;
using System.Linq;

namespace AbcPos.Kasa.ViewModels
{
    public class PretragaArtikalaViewModel : Notifiable
    {
        private string m_Sifra;
        private string m_Naziv;
        private readonly ILocalRepository m_Repository;
      

        public PretragaArtikalaViewModel(ILocalRepository repository)
        {
            m_Repository = repository;
            Zalihe = new BindingList<Zaliha>();
            JediniceMere = m_Repository.JediniceMere().ToList();
        }

        public KonfiguracijaKase KonfiguracijaKase { get { return m_Repository.VratiKonfiguracijuKase(); } }

        public string Sifra
        {
            get { return m_Sifra; }
            set
            {
                if (m_Sifra != value)
                {
                    m_Sifra = value;
                    OnPropertyChanged("Sifra");
                }
            }
        }

        public string Naziv
        {
            get { return m_Naziv; }
            set
            {
                if (Naziv != value)
                {
                    m_Naziv = value;
                    OnPropertyChanged("Naziv");
                }
            }
        }

        public BindingList<Zaliha> Zalihe { get; set; }

        public List<JedinicaMere> JediniceMere { get; set; }

        public Artikal IzabraniArtikal { get; set; }

        public void Pretrazi()
        {
            var zalihe = m_Repository.PretraziArtikleIZalihu(Sifra, Naziv).Select(x => x.Zalihe.Single(y => y.RadnjaID == 1));
            Zalihe = new BindingList<Zaliha>();
            foreach (var zaliha in zalihe)
            {
                zaliha.Artikal.Cena = zaliha.ProdajnaCena;
                zaliha.Artikal.Zaliha = zaliha.TrenutnaZaliha;
                Zalihe.Add(zaliha);
            }
        }
    }
}