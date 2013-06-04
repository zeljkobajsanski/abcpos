using AbcPos.BackOffice.Win.Models.Entities;
using AbcPos.BackOffice.Win.Models.Validation;
using AbcPos.BackOffice.Win.Services.BackendService;
using AutoMapper;
using Bootstrap.AutoMapper;
using FluentValidation.Results;

namespace AbcPos.BackOffice.Win.Models.Mappings
{
    public class Mapper : IMapCreator
    {
        public void CreateMap(IProfileExpression mapper)
        {
            mapper.CreateMap<ValidationFailure, ValidationError>();
            mapper.CreateMap<Services.BackendService.Artikal, Entities.Artikal>();
            mapper.CreateMap<Entities.Artikal, Services.BackendService.Artikal>();
            mapper.CreateMap<Services.BackendService.Artikal, Entities.Artikal>();
            mapper.CreateMap<KeyValue, JedinicaMere>()
                .ForMember(x => x.Oznaka, expression => expression.MapFrom(x => x.Value));
            mapper.CreateMap<KeyValue, Pdv>().ForMember(x => x.Oznaka, expression => expression.MapFrom(x => x.Value));
        }

        public static JedinicaMere Map(KeyValue keyValue)
        {
            return AutoMapper.Mapper.Map<JedinicaMere>(keyValue);
        }

        public static Entities.Artikal Map(Services.BackendService.Artikal artikal)
        {
            return AutoMapper.Mapper.Map<Entities.Artikal>(artikal);
        }

        public static Services.BackendService.Artikal Map(Entities.Artikal artikal)
        {
            return AutoMapper.Mapper.Map<Services.BackendService.Artikal>(artikal);
        }

        public static Pdv MapPdv(KeyValue keyValue)
        {
            return AutoMapper.Mapper.Map<Pdv>(keyValue);
        }


        public static ValidationError Map(ValidationFailure validationFailure)
        {
            return AutoMapper.Mapper.Map<ValidationError>(validationFailure);
        }
    }
}