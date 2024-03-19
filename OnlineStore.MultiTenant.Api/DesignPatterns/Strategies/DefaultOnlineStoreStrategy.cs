using OnlineStore.MultiTenant.Api.Models;

namespace OnlineStore.MultiTenant.Api.DesignPatterns.Strategies
{
    public class DefaultOnlineStoreStrategy : IOnlineStoreStrategy
    {
        public Task<Order> CreateOrderAsync(Order order)
        {
            throw new NotImplementedException();
        }
    }
}
