namespace OnlineStore.MultiTenant.Api.Models
{
    public class Order
    {
        public Guid Id { get; set; }
        public Guid CustomerId { get; set; }
        public DateTime CreationDate { get; set; }
        public List<OrderItem> Items { get; set; }

        public decimal GetTotalWeight()
        {
            return Items.Sum(item => item.WeightInKg * item.Quantity);
        }
    }

}
