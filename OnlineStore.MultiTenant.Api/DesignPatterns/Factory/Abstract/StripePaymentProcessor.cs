namespace OnlineStore.MultiTenant.Api.DesignPatterns.Factory.Abstract
{
    public class StripePaymentProcessor : IPaymentProcessor
    {
        public Task ProcessPayment()
        {
            throw new NotImplementedException();
        }
    }
}
