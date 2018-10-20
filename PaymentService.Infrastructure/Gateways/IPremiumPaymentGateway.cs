using PaymentService.Domain.Interfaces;
using PaymentService.Domain.Models;
using System;

namespace PaymentService.Infrastructure.Gateways
{
    public class IPremiumPaymentGateway : IPaymentGateway
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
