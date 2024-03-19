namespace OnlineStore.MultiTenant.Api.DesignPatterns.Factory.Abstract
{
    public interface IPaymentValidator 
    {
        Task ProcessPaymentValidation();
    }
}
