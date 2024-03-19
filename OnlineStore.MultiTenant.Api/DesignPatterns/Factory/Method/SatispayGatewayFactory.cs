namespace OnlineStore.MultiTenant.Api.DesignPatterns.Factory.Method
{
    public class SatispayGatewayFactory : PaymentGatewayFactory
    {
        public override IPaymentGateway CreatePaymentGateway()
        {
            throw new NotImplementedException();
        }
    }
}
