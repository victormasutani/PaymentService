using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PaymentService.Domain.Models
{
    /// <summary>Payment model</summary>
    public class Payment
    {
        /// <summary>Card</summary>
        [Required]
        public Card Card { get; set; }
        /// <summary>Payment amount</summary>
        [Required]
        public decimal Amount { get; set; }

        public IEnumerable<string> Validate()
        {
            var errors = new List<string>();
            if (Amount <= 0)
                errors.Add("Invalid Amount");

            errors.AddRange(Card.Validate());

            return errors;
        }
    }
}
