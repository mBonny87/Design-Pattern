using OnlineStore.MultiTenant.Api.DesignPatterns.Strategies;

namespace OnlineStore.MultiTenant.Api.DesignPatterns.Factory
{
    public class OnlineStoreFactory
    {
        private readonly IServiceProvider _serviceProvider;

        public OnlineStoreFactory(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public IOnlineStoreStrategy CreateStrategy(string tenant)
        {
            switch (tenant)
            {
                case "Foo": return _serviceProvider.GetRequiredService<FooOnlineStoreStrategy>();
                case "Bar": return _serviceProvider.GetRequiredService<BarOnlineStoreStrategy>();
                default: return _serviceProvider.GetRequiredService<DefaultOnlineStoreStrategy>();
            }
        }
    }
}
