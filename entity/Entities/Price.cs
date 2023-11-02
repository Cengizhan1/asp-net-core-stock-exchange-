

using Core.Entities;

namespace Entity.Entities
{
    public class Price  :BaseEntity
    {
        public float open { get; set; }
        public float high { get; set; }
        public float low { get; set; }
        public float close { get; set; }
        public float volume { get; set; }
        public DateTime DateTime { get; set; }
    }
}
