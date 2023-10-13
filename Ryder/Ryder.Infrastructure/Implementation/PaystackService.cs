using PayStack.Net;
using Ryder.Infrastructure.Interface;


namespace Ryder.Infrastructure.Implementation
{
    public class PaystackService : IPaystackService
    {
        private readonly IPayStackApi _paystack;

        public PaystackService(IPayStackApi paystack)
        {
            _paystack = paystack;
        }

        public async Task<TransactionInitializeResponse> InitializePayment(TransactionInitializeRequest request)
        {
            return await Task.Run(() => _paystack.Transactions.Initialize(request));
        }

        public async Task<TransactionVerifyResponse> VerifyPayment(string reference)
        {
            return await Task.Run(() => _paystack.Transactions.Verify(reference));
        }

    }
}
