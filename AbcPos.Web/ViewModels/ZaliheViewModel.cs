using System.Collections.Generic;
using System.Linq;
using AbcPos.Core.Models;
using AbcPos.Core.Repository;

namespace AbcPos.Web.ViewModels
{
    public class ZaliheViewModel
    {
        private readonly Repository m_Repository = new Repository();

        public ZaliheViewModel()
        {
            Radnje = m_Repository.Radnje();
            Zalihe = Enumerable.Empty<Zaliha>();
        }

        public int? IdRadnje { get; set; }
        public int? IdZalihe { get; set; }
        public IEnumerable<Radnja> Radnje { get; set; }
        public IEnumerable<Zaliha> Zalihe { get; set; }
        public int[] IdZaliha { get; set; }

        public void Pretrazi()
        {
            Zalihe = IdRadnje.HasValue ? m_Repository.VratiZaliheArtikala(IdRadnje.Value, IdZalihe, IdZaliha) : Enumerable.Empty<Zaliha>();
        }

        public void SacuvajZalihu(Zaliha zaliha)
        {
            var update = m_Repository.VratiZalihu(zaliha.ID);
            update.ProdajnaCena = zaliha.ProdajnaCena;
            update.MinimalnaZaliha = zaliha.MinimalnaZaliha;
            update.MaximalnaZaliha = zaliha.MaximalnaZaliha;
            m_Repository.Submit();
        }
    }
}