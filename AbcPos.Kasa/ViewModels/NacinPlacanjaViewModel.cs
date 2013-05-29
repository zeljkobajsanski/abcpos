using System;
using System.Linq;
using AbcPos.Core.Models;
using AbcPos.Core.Repository;

namespace AbcPos.Kasa.ViewModels
{
    public class NacinPlacanjaViewModel
    {
        private readonly LocalRepository fRepository;
        private Racun m_Racun;

        public NacinPlacanjaViewModel(LocalRepository repository)
        {
            fRepository = repository;
        }

        public Racun Racun
        {
            get { return m_Racun; }
            set
            {
                m_Racun = value;
                Racun.Gotovina = Racun.IznosRacuna;
            }
        }

        public void Validiraj()
        {
            //Racun.ValidirajNacinPlacanja();
        }

        public void UplatiGotovinom()
        {
            Racun.UplatiGotovinom();
        }

        public void UplatiKarticom()
        {
            Racun.UplatiKarticom();
        }

        public void UplatiCekom()
        {
            Racun.UplatiCekom();
        }
    }
}