using OnlineStore.MultiTenant.Api.Models;

namespace OnlineStore.MultiTenant.Api.DesignPatterns.Strategies
{
    public class FooOnlineStoreStrategy : IOnlineStoreStrategy
    {
        public Task<Order> CreateOrderAsync(Order order)
        {
            throw new NotImplementedException();
        }
    }
}
