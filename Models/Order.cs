namespace Magazine.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
       
        public DateTime? OrderDate { get; set; }
        public List<OrderDetail> OrderDetails { get; set; }
    }
}
