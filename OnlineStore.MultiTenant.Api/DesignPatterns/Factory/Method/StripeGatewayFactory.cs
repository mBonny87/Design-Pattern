namespace OnlineStore.MultiTenant.Api.DesignPatterns.Factory.Method
{
    public class StripeGatewayFactory : PaymentGatewayFactory {
        public override IPaymentGateway CreatePaymentGateway()
        {
            throw new NotImplementedException();
        }
    }
}
