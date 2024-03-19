namespace OnlineStore.MultiTenant.Api.DesignPatterns.Factory.Method
{
    public interface IPaymentGateway
    {
        TransactionResponse ProcessPayment(TransactionRequest request);
    }
}
