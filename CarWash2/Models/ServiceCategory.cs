namespace CarWash2.Models
{
    public class ServiceCategory
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";


        public List<Service>? Services { get; set; }
    }
}
