using System.Text.Json.Serialization;

namespace CarWash2.Models
{
    public class ServiceCategory
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";

        [JsonIgnore]
        public List<Service>? Services { get; set; }
    }
}
