using System;

namespace RentCars
{
    public class RentalModel
    {
        public int Id { get; set; }
        public string CarName { get; set; }
        public string CustomerName { get; set; }
        public DateTime RentalDate { get; set; }
        public int Days { get; set; }
        public double TotalPrice { get; set; }
        public bool IsActive { get; set; }
    }
}