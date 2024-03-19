namespace OnlineStore.MultiTenant.Api.DesignPatterns.Factory.Method
{
    public class SquareGateway : IPaymentGateway
    {
        public TransactionResponse ProcessPayment(TransactionRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
