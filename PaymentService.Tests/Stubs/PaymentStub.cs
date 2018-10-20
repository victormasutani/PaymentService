using PaymentService.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PaymentService.Tests.Stubs
{
    public static class PaymentStub
    {

        public static Payment InvalidAmount = new Payment
        {
            Amount = 0,
            Card = new Card
            {
                CardHolder = "Holder",
                CreditCardNumber = "4481117490981356",
                ExpirationDate = new DateTime(2021, 07, 1),
                SecurityCode = "575"
            }
        };

        public static Payment InvalidAmountNegative = new Payment
        {
            Amount = -1,
            Card = new Card
            {
                CardHolder = "Holder",
                CreditCardNumber = "4481117490981356",
                ExpirationDate = new DateTime(2021, 07, 1),
                SecurityCode = "575"
            }
        };

        public static Payment InvalidSecurityCode = new Payment
        {
            Amount = 1,
            Card = new Card
            {
                CardHolder = "Holder",
                CreditCardNumber = "4481117490981356",
                ExpirationDate = new DateTime(2021, 07, 1),
                SecurityCode = "5753"
            }
        };

        public static Payment InvalidCreditCardNumber = new Payment
        {
            Amount = 1,
            Card = new Card
            {
                CardHolder = "Holder",
                CreditCardNumber = "648111749098131",
                ExpirationDate = new DateTime(2021, 07, 1),
                SecurityCode = "575"
            }
        };

        public static Payment InvalidDate = new Payment
        {
            Amount = 14,
            Card = new Card
            {
                CardHolder = "Holder",
                CreditCardNumber = "4481117490981356",
                ExpirationDate = new DateTime(2000, 07, 1),
                SecurityCode = "575"
            }
        };

        public static Payment Valid14 = new Payment
        {
            Amount = 14,
            Card = new Card
            {
                CardHolder = "Holder",
                CreditCardNumber = "4481117490981356",
                ExpirationDate = new DateTime(2021, 07, 1),
                SecurityCode = "575"
            }
        };

        public static Payment Valid50 = new Payment
        {
            Amount = 50,
            Card = new Card
            {
                CardHolder = "Holder",
                CreditCardNumber = "4481117490981356",
                ExpirationDate = new DateTime(2021, 07, 1),
                SecurityCode = "575"
            }
        };

        public static Payment Valid800 = new Payment
        {
            Amount = 800,
            Card = new Card
            {
                CardHolder = "Holder",
                CreditCardNumber = "4481117490981356",
                ExpirationDate = new DateTime(2021, 07, 1),
                SecurityCode = "575"
            }
        };

        public static Payment Invalid801 = new Payment
        {
            Amount = 801,
            Card = new Card
            {
                CardHolder = "Holder",
                CreditCardNumber = "4481117490981356",
                ExpirationDate = new DateTime(2021, 07, 1),
                SecurityCode = "575"
            }
        };
    }
}
