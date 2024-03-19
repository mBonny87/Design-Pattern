namespace OnlineStore.MultiTenant.Api.DesignPatterns.Factory.Method
{
    public class StripeGateway : IPaymentGateway
    {
        public TransactionResponse ProcessPayment(TransactionRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
