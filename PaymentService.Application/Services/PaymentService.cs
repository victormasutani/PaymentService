using PaymentService.Application.Interfaces;
using PaymentService.Domain.Interfaces;
using PaymentService.Domain.Models;
using PaymentService.Infrastructure.Gateways;

namespace PaymentService.Application.Services
{
    public class PaymentService : IPaymentService
    {
        public PaymentResponse ProcessPayment(Payment payment)
        {
            PaymentResponse response = null;

            IPaymentGateway gateway;
            if (payment.Amount < 20)
            {
                gateway = new ICheapPaymentGateway();
                response = gateway.ProcessPayment(payment);
            }
            else if (payment.Amount > 20 && payment.Amount <= 500)
            {
                gateway = new IExpensivePaymentGateway();
                response = gateway.ProcessPayment(payment);
                if(!response.Success)
                {
                    gateway = new ICheapPaymentGateway();
                    response = gateway.ProcessPayment(payment);
                }
            }
            else
            {
                gateway = new IPremiumPaymentGateway();
                var retries = 3;
                while (retries > 0)
                {
                    response = gateway.ProcessPayment(payment);
                    if (response.Success)
                        return response;

                    retries--;
                }
                response.ErrorMessage += " Retried: 3 times.";
            }
            return response;
        }
    }
}
