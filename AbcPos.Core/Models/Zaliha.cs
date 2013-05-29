using System;
using System.Runtime.Serialization;

namespace AbcPos.Core.Models
{
    [DataContract]
    public class Zaliha : Entity
    {
        [DataMember]
        public int RadnjaID { get; set; }
        
        public Radnja Radnja { get; set; }
        
        [DataMember]
        public int ArtikalID { get; set; }
        
        public Artikal Artikal { get; set; }
        
        [DataMember]
        public decimal NabavnaCena { get; set; }
        
        [DataMember]
        public decimal ProdajnaCena { get; set; }

        public decimal Ruc { get { return ProdajnaCena - NabavnaCena; } }
        
        public decimal ProcenatRuca
        {
            get
            {
                if (NabavnaCena == 0) return 100;
                return ProdajnaCena/NabavnaCena * 100;
            }
        }
        
        [DataMember]
        public decimal TrenutnaZaliha { get; set; }
        
        [DataMember]
        public decimal UkupnaZaliha { get; set; }

        public decimal? MinimalnaZaliha { get; set; }

        public decimal? MaximalnaZaliha { get; set; }
    }
}