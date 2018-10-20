using PaymentService.Domain.Models;

namespace PaymentService.Domain.Interfaces
{
    public interface IPaymentGateway
    {
        PaymentResponse ProcessPayment(Payment payment);
    }
}
