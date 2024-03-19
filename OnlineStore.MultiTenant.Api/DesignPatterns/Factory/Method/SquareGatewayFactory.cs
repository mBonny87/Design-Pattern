namespace OnlineStore.MultiTenant.Api.DesignPatterns.Factory.Method
{
    public class SquareGatewayFactory : PaymentGatewayFactory {
        public override IPaymentGateway CreatePaymentGateway()
        {
            throw new NotImplementedException();
        }
    }
}
