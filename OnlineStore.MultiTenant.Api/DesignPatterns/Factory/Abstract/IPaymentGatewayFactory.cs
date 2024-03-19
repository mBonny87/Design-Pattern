namespace OnlineStore.MultiTenant.Api.DesignPatterns.Factory.Abstract
{
    public interface IPaymentGatewayFactory
    {
        IPaymentProcessor CreatePaymentProcessor();
        IRefundProcessor CreateRefundProcessor();
        IPaymentValidator CreatePaymentValidator();
    }
}
