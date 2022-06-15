﻿namespace CarWash2.Models
{
    public class Brand
    {
        public int Id { get; set; }

        public string Name { get; set; } = "";

        public List<Car>? Cars { get; set; }
    }
}
