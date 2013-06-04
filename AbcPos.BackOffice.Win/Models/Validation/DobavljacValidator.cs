using System.Collections.Generic;
using System.Linq;
using AbcPos.BackOffice.Win.Models.Entities;
using AbcPos.BackOffice.Win.Models.Mappings;
using FluentValidation;

namespace AbcPos.BackOffice.Win.Models.Validation
{
    public class DobavljacValidator : AbstractValidator<Dobavljac>, IValidator
    {
        public DobavljacValidator()
        {
            RuleFor(x => x.Sifra).NotEmpty().WithMessage("Šifra nije uneta");
            RuleFor(x => x.Naziv).NotEmpty().WithMessage("Naziv nij unet");
        }

        public ValidationError[] Validate(Entity entity)
        {
            return base.Validate((Dobavljac)entity).Errors.Select(Mapper.Map).ToArray();
        }

        public bool IsValid(Entity entity)
        {
            return base.Validate((Dobavljac)entity).IsValid;
        }

        public IEnumerable<ValidationError> GetErrors(string propertyName, Entity entity)
        {
            return base.Validate((Dobavljac)entity)
                .Errors.Where(x => x.PropertyName == propertyName)
                .Select(Mapper.Map);
        }

        public string GetFirstError(string propertyName, Entity entity)
        {
            var error = base.Validate((Dobavljac)entity).Errors.FirstOrDefault(x => x.PropertyName == propertyName);
            return error != null ? error.ErrorMessage : null;
        }
    }
}