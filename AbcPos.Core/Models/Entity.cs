using System.Runtime.Serialization;

namespace AbcPos.Core.Models
{
    [DataContract(IsReference = true)]
    public class Entity : Notifiable
    {
        [DataMember]
        public int ID { get; set; }

        protected bool Equals(Entity other)
        {
            return ID == other.ID;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            var other = obj as Entity;
            return other != null && Equals(other);
        }

        public override int GetHashCode()
        {
            return ID;
        }
    }
}