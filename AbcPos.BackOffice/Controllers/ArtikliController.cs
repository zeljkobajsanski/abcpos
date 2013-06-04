using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AbcPos.Core.Models;
using AbcPos.Core.Repository;

namespace AbcPos.BackOffice.Controllers
{
    public class ArtikliController : ApiController
    {
        private readonly Repository m_Repository = new Repository();

        // GET api/artikli
        public IEnumerable<Models.Artikal> Get()
        {
            return m_Repository.Artikli().Select(x => new Models.Artikal
            {
                ID = x.ID, Naziv = x.Naziv, 
                Sifra = x.Sifra,
                JedinicaMereID = x.JedinicaMereID, 
                PdvID = x.PdvID, Barkod = x.Barkod
            });
        }

        // GET api/artikli/5
        public Models.Artikal Get(int id)
        {
            var artikal = m_Repository.VratiArtikal(id);
            var httpResponse = new HttpResponseMessage(HttpStatusCode.NotFound){ReasonPhrase = "Artikal ne postoji"};
            if (artikal == null) throw new HttpResponseException(httpResponse);
            return new Models.Artikal()
            {
                ID = artikal.ID,
                Sifra = artikal.Sifra,
                Naziv = artikal.Naziv,
                JedinicaMereID = artikal.JedinicaMereID,
                PdvID = artikal.PdvID,
                Barkod = artikal.Barkod
            };
        }

        // POST api/artikli
        public HttpResponseMessage Post(HttpRequestMessage request, Models.Artikal artikal)
        {
            if (!ModelState.IsValid)
            {
                return request.CreateErrorResponse(HttpStatusCode.BadRequest, "Podaci artikla nisu ispravni");
            }
            var noviArtikal = new Artikal()
            {
                Naziv = artikal.Naziv, 
                Sifra = artikal.Sifra, 
                Barkod = artikal.Barkod, 
                JedinicaMereID = artikal.JedinicaMereID, 
                PdvID = artikal.PdvID
            };
            m_Repository.SacuvajArtikal(noviArtikal);
            m_Repository.Submit();
            var response = request.CreateResponse(HttpStatusCode.Created, artikal);
            response.Headers.Location = new Uri(request.RequestUri, Url.Route("", new {id = noviArtikal.ID}));
            return response;
        }

        // PUT api/artikli/5
        public void Put(int id, Models.Artikal artikal)
        {

        }

        // DELETE api/artikli/5
        public void Delete(int id)
        {
        }
    }
}
