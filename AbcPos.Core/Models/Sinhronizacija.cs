using System;

namespace AbcPos.Core.Models
{
    public class Sinhronizacija : Entity
    {
        private int m_BrojArtikala;
        private DateTime? m_PoslednjaSinhronizacija;
        private DateTime? m_UspesnaSinhronizacija;
        private int m_BrojRacuna;

        public int BrojArtikala
        {
            get { return m_BrojArtikala; }
            set
            {
                if (value == m_BrojArtikala)
                {
                    return;
                }
                m_BrojArtikala = value;
                OnPropertyChanged("BrojArtikala");
            }
        }

        public DateTime? PoslednjaSinhronizacija
        {
            get { return m_PoslednjaSinhronizacija; }
            set
            {
                if (value.Equals(m_PoslednjaSinhronizacija))
                {
                    return;
                }
                m_PoslednjaSinhronizacija = value;
                OnPropertyChanged("PoslednjaSinhronizacija");
            }
        }

        public DateTime? UspesnaSinhronizacija
        {
            get { return m_UspesnaSinhronizacija; }
            set
            {
                if (value.Equals(m_UspesnaSinhronizacija))
                {
                    return;
                }
                m_UspesnaSinhronizacija = value;
                OnPropertyChanged("UspesnaSinhronizacija");
            }
        }

        public int BrojRacuna
        {
            get { return m_BrojRacuna; }
            set
            {
                if (value == m_BrojRacuna)
                {
                    return;
                }
                m_BrojRacuna = value;
                OnPropertyChanged("BrojRacuna");
            }
        }

        public int RadnjaID { get; set; }
    }
}