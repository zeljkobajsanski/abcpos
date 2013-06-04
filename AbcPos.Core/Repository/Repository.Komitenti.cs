using System.Collections.Generic;
using System.Data;
using AbcPos.Core.Models;
using System.Linq;

namespace AbcPos.Core.Repository
{
    public partial class Repository
    {
         public IEnumerable<Dobavljac> Dobavljaci()
         {
             return DataContext.Komitenti.OfType<Dobavljac>().ToArray();
         }

        public IEnumerable<Dobavljac> VratiDobavljace(string filter, int beginIndex, int endIndex)
        {
            return
                DataContext.Komitenti.OfType<Dobavljac>()
                            .Where(x => x.Naziv.Contains(filter))
                            .OrderBy(x => x.Naziv)
                            .Skip(beginIndex)
                            .Take(endIndex - beginIndex + 1)
                            .ToArray();
        }

        public Dobavljac VratiDobavljaca(int id)
        {
            return DataContext.Komitenti.OfType<Dobavljac>().SingleOrDefault(x => x.ID == id);

        }


        public void SacuvajDobavljaca(Dobavljac dobavljac)
        {
            if (dobavljac.ID == 0)
            {
                DataContext.Komitenti.Add(dobavljac);
            }
            else
            {
                DataContext.Entry(dobavljac).State = EntityState.Modified;
            }
        }
    }
}