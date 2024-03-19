namespace OnlineStore.MultiTenant.Api.DesignPatterns.Factory.Abstract
{
    public interface IPaymentProcessor {
        Task ProcessPayment();
    }
}
