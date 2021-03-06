using System.Text.Json.Serialization;

namespace CarWash2.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = "";
        public string LastName { get; set; } = "";
        public string Patronymic { get; set; } = "";
        public string Image { get; set; } = "";

        [JsonIgnore]
        public List<Order>? Orders { get; set; }
    }
}
