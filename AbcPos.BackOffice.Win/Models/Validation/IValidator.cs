using System.Collections.Generic;
using AbcPos.BackOffice.Win.Models.Entities;

namespace AbcPos.BackOffice.Win.Models.Validation
{
    public interface IValidator
    {
        ValidationError[] Validate(Entity entity);
        bool IsValid(Entity entity);
        IEnumerable<ValidationError> GetErrors(string propertyName, Entity entity);
        string GetFirstError(string propertyName, Entity entity);
    }
}