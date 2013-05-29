using System.ComponentModel.DataAnnotations;

namespace AbcPos.Core.Models
{
    public class JedinicaMere : Entity
    {
        [Required(ErrorMessage = "Oznaka JM nije uneta")]
        [StringLength(10, ErrorMessage = "JM je predugačka")]
        public string Oznaka { get; set; }
        public string Naziv { get; set; }
        public bool Default { get; set; }

        public override string ToString()
        {
            return Oznaka;
        }
    }
}