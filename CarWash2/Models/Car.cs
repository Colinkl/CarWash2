using System.Text.Json.Serialization;

namespace CarWash2.Models
{
    public class Car
    {
        public int Id { get; set; }
        public int BrandId { get; set; }
        public Brand? Brand { get; set; }
        public string Model { get; set; } = "";

        [JsonIgnore]
        public List<CustomerCar>? CustomerCar { get; set; }

    }
}
