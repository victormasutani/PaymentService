using PaymentService.Domain.Interfaces;
using PaymentService.Domain.Models;

namespace PaymentService.Infrastructure.Gateways
{
    public class IExpensivePaymentGateway : IPaymentGateway
    {
        public PaymentResponse ProcessPayment(Payment payment)
        {
            if (payment.Amount % 2 == 0)
                return new PaymentResponse
                {
                    Success = true
                };
            else
                return new PaymentResponse
                {
                    ErrorMessage = "Internal server error.",
                    Success = false
                };
        }
    }
}
