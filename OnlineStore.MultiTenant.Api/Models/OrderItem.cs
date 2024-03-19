﻿namespace OnlineStore.MultiTenant.Api.Models
{
    public class OrderItem
    {
        public Guid OrderItemId { get; set; }
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public decimal WeightInKg { get; set; }
    }

}
