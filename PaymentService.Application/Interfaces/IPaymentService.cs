using PaymentService.Domain.Models;

namespace PaymentService.Application.Interfaces
{
    public interface IPaymentService
    {
        PaymentResponse ProcessPayment(Payment payment);
    }
}
