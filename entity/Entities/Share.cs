using Core.Entities;


namespace Entity.Entities
{
    public class Share :BaseEntity
    {

        public string Name { get; set; }
        public string Symbol { get; set; }
        public DateTime lastUpdate { get; set; } = DateTime.Now;

    }
}
