using System;
using System.Collections.Generic;
using System.ComponentModel;
using AbcPos.Core.Interfaces;
using AbcPos.Core.Models;

namespace AbcPos.Kasa.ViewModels
{
    public class PregledProdajeViewModel : Notifiable
    {
        private DateTime m_OdDana;
        private DateTime m_DoDana;
        private readonly ILocalRepository m_Repository;
        private KonfiguracijaKase m_KonfiguracijaKase;

        public PregledProdajeViewModel(ILocalRepository repository)
        {
            this.m_Repository = repository;
            m_KonfiguracijaKase = repository.VratiKonfiguracijuKase();
            OdDana = DateTime.Now.Date;
            DoDana = DateTime.Now.Date;
            Racuni = new BindingList<Racun>();
        }

        public KonfiguracijaKase Konfiguracija { get { return m_KonfiguracijaKase; } }

        public DateTime OdDana
        {
            get { return m_OdDana; }
            set
            {
                if (OdDana == value) return;
                m_OdDana = value;
                OnPropertyChanged("OdDana");
            }
        }

        public DateTime DoDana
        {
            get { return m_DoDana; }
            set
            {
                if (DoDana == value) return;
                m_DoDana = value;
                OnPropertyChanged("DoDana");
            }
        }

        public BindingList<Racun> Racuni { get; set; }

        public void Prikazi()
        {
            Racuni.Clear();
            using (var repo = IoC.Singleton().Get<ILocalRepository>())
            {
                var racuni = repo.VratiRacune(OdDana.Date, DoDana.Date, m_KonfiguracijaKase.ProdavnicaID);
                foreach (var racun in racuni)
                {
                    racun.PopuniStavke();
                    Racuni.Add(racun);
                }
            }
        }
    }
}