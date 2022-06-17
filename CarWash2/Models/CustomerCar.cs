using System.Text.Json.Serialization;

namespace CarWash2.Models
{
    public class CustomerCar
    {
        public int Id { get; set; }
        public int CarId { get; set; }
        public Car? Car { get; set; }
        public int CustomerId { get; set; }
        public Customer? Customer { get; set; }
        public int Year { get; set; }
        public string Plate { get; set; } = "";
        public string Image { get; set; } = "";

        [JsonIgnore]
        public List<Order>? Orders { get; set; }
    }
}
