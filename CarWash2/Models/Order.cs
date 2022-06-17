namespace CarWash2.Models
{
    public class Order
    {
        public int Id { get; set; }

        public int ServiceId { get; set; }
        public Service? Service { get; set; }
        public int CustomerCarId { get; set; }
        public CustomerCar? CustomerCar { get; set; }
        public int EmployeeId { get; set; }
        public Employee? Employee { get; set; }
        public int Status { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndDate { get; set; }
    }
}
