using OnlineStore.MultiTenant.Api.Models;

namespace OnlineStore.MultiTenant.Api.DesignPatterns.Strategies
{
    public interface IOnlineStoreStrategy
    {
        Task<Order> CreateOrderAsync(Order order);
    }
}
