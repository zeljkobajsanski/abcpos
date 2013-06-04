using System.Collections.Generic;
using AbcPos.BackOffice.Win.Models.Entities;
using AbcPos.BackOffice.Win.Models.Mappings;
using FluentValidation;
using System.Linq;

namespace AbcPos.BackOffice.Win.Models.Validation
{
    public class ArtikalValidator : AbstractValidator<Artikal>, IValidator
    {
        public ArtikalValidator()
        {
            RuleFor(x => x.Naziv).NotEmpty().WithMessage("Naziv nije unet");
            RuleFor(x => x.Naziv).Length(1, 255).WithMessage("Naziv je predugačak");
            RuleFor(x => x.Sifra).NotEmpty().WithMessage("Šifra nije uneta");
            RuleFor(x => x.Sifra).Length(1, 20).WithMessage("Šifra je predugačka");
            RuleFor(x => x.JedinicaMereID).NotNull().WithMessage("Unesite jedinicu mere");
            RuleFor(x => x.PdvID).NotNull().WithMessage("Unesite pdv");
        }

        public ValidationError[] Validate(Entity entity)
        {
            return base.Validate((Artikal)entity).Errors.Select(Mapper.Map).ToArray();
        }

        public bool IsValid(Entity entity)
        {
            return base.Validate((Artikal) entity).IsValid;
        }

        public IEnumerable<ValidationError> GetErrors(string propertyName, Entity entity)
        {
            return base.Validate((Artikal) entity)
                .Errors.Where(x => x.PropertyName == propertyName)
                .Select(Mapper.Map);
        }

        public string GetFirstError(string propertyName, Entity entity)
        {
            var error = base.Validate((Artikal) entity).Errors.FirstOrDefault(x => x.PropertyName == propertyName);
            return error != null ? error.ErrorMessage : null;
        }
    }
}