using System.Text.Json.Serialization;

namespace CarWash2.Models
{
    public class Service
    {
        public int Id { get; set; }
        public int ServiceCategoryId { get; set;}
        public ServiceCategory? ServiceCategory { get; set; }
        public string Name { get; set; } = "";
        public int Duration { get; set; }
        public int Price { get; set; }

        [JsonIgnore]
        public List<Order>? Orders { get; set; }

    }
}
