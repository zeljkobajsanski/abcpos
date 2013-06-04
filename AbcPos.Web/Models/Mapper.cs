using AbcPos.Core.Models;
using AutoMapper;
using Bootstrap.AutoMapper;

namespace AbcPos.Web.Models
{
    public class Mapper : IMapCreator
    {
        public void CreateMap(IProfileExpression mapper)
        {
            mapper.CreateMap<Core.Models.Artikal, Artikal>()
                  .ForMember(x => x.PdvStopa, expression => expression.MapFrom(x => x.Pdv.Stopa))
                  .ForMember(x => x.OznakaJediniceMere, expression => expression.MapFrom(x => x.JedinicaMere.Oznaka));
            mapper.CreateMap<Artikal, Core.Models.Artikal>();
            mapper.CreateMap<JedinicaMere, KeyValue>()
                .ForMember(x => x.Id, expression => expression.MapFrom(x => x.ID))
                .ForMember(x => x.Value, expression => expression.MapFrom(x => x.Oznaka));
            mapper.CreateMap<Pdv, KeyValue>()
                  .ForMember(x => x.Id, expression => expression.MapFrom(x => x.ID))
                  .ForMember(x => x.Value, expression => expression.MapFrom(x => x.Naziv));
        }

        public static Artikal Map(Core.Models.Artikal artikal)
        {
            return AutoMapper.Mapper.Map<Artikal>(artikal);
        }

        public static Core.Models.Artikal Map(Artikal artikal)
        {
            return AutoMapper.Mapper.Map<Core.Models.Artikal>(artikal);
        }

        public static KeyValue Map(JedinicaMere jedinicaMere)
        {
            return AutoMapper.Mapper.Map<KeyValue>(jedinicaMere);
        }

        public static KeyValue Map(Pdv pdv)
        {
            return AutoMapper.Mapper.Map<KeyValue>(pdv);
        }
    }
}