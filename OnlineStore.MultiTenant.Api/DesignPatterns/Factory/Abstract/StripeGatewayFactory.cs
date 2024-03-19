namespace OnlineStore.MultiTenant.Api.DesignPatterns.Factory.Abstract
{
    public class StripeGatewayFactory : IPaymentGatewayFactory
    {
        public IPaymentProcessor CreatePaymentProcessor()
        {
            throw new NotImplementedException();
        }

        public IPaymentValidator CreatePaymentValidator()
        {
            throw new NotImplementedException();
        }

        public IRefundProcessor CreateRefundProcessor()
        {
            throw new NotImplementedException();
        }
    }
}
