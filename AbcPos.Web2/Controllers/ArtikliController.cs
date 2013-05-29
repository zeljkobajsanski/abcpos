using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using AbcPos.Core.Interfaces;
using AbcPos.Core.Models;
using AbcPos.Core.Repository;
using AbcPos.Web2.DTO;

namespace AbcPos.Web2.Controllers
{
    public class ArtikliController : ApiController
    {
        private readonly IRepository m_Repository;

        public ArtikliController() : this(new Repository())
        {
        }

        public ArtikliController(IRepository repository)
        {
            m_Repository = repository;
        }

        public IEnumerable<ArtikalDTO> Get(string sifra, string naziv)
        {
            var artikli = m_Repository.PretraziArtikle(sifra, naziv).Take(200).Select(x => new ArtikalDTO()
            {
                ID = x.ID,
                Sifra = x.Sifra,
                Naziv = x.Naziv,
                JM = x.JedinicaMere != null ? x.JedinicaMere.Oznaka : "-"
            });
            return artikli;
        }

    }
}
