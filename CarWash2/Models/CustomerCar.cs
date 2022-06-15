namespace CarWash2.Models
{
    public class CustomerCar
    {
        public int Id { get; set; }
        public Car? Car { get; set; }
        public Customer? Customer { get; set; }
        public int Year { get; set; }
        public string Plate { get; set; } = "";
        public string Image { get; set; } = "";


        public List<Order>? Orders { get; set; }
    }
}
