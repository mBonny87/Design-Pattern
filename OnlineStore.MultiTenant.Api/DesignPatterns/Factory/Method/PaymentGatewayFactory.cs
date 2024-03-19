namespace OnlineStore.MultiTenant.Api.DesignPatterns.Factory.Method
{

    public abstract class PaymentGatewayFactory
    {
        public abstract IPaymentGateway CreatePaymentGateway();
    }
}
