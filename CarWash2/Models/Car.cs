namespace CarWash2.Models
{
    public class Car
    {
        public int Id { get; set; }
        public Brand? Brand { get; set; }
        public string Model { get; set; } = "";


        public List<CustomerCar>? CustomerCar { get; set; }

    }
}
