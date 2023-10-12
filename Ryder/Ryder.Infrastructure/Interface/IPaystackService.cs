using PayStack.Net;

namespace Ryder.Infrastructure.Interface
{
    public interface IPaystackService
    {
       Task<TransactionInitializeResponse> InitializePayment(TransactionInitializeRequest request);
        Task<TransactionVerifyResponse> VerifyPayment(string reference);
    }
}
