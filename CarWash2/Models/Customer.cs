using System.Text.Json.Serialization;

namespace CarWash2.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = "";
        public string LastName { get; set; } = "";
        public string Patronymic { get; set; } = "";
        public string Email { get; set; } = "";
        public bool Sex { get; set; }
        public bool IsSendNotify { get; set; }
        [JsonIgnore]
        public List<CustomerCar>? CustomerCars { get; set; }
    }
}
