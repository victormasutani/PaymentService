using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using PaymentService.API.Controllers;
using PaymentService.Tests.Stubs;
using System.Collections.Generic;
using System.Linq;

namespace PaymentService.Tests
{
    [TestClass]
    public class PaymentServiceTest
    {
        [TestMethod]
        public void InvalidAmount()
        {
            var paymentServiceMock = new Mock<Application.Services.PaymentService>();

            var controller = new PaymentsController(paymentServiceMock.Object);

            var result = controller.ProcessPayment(PaymentStub.InvalidAmount);

            Assert.IsInstanceOfType(result, typeof(BadRequestObjectResult));
            Assert.IsTrue(((List<string>)((BadRequestObjectResult)result).Value).Any(e => e == "Invalid Amount"));
        }
        [TestMethod]
        public void InvalidAmountNegative()
        {
            var paymentServiceMock = new Mock<Application.Services.PaymentService>();

            var controller = new PaymentsController(paymentServiceMock.Object);

            var result = controller.ProcessPayment(PaymentStub.InvalidAmountNegative);

            Assert.IsInstanceOfType(result, typeof(BadRequestObjectResult));
            Assert.IsTrue(((List<string>)((BadRequestObjectResult)result).Value).Any(e => e == "Invalid Amount"));
        }

        [TestMethod]
        public void InvalidSecurityCode()
        {
            var paymentServiceMock = new Mock<Application.Services.PaymentService>();

            var controller = new PaymentsController(paymentServiceMock.Object);

            var result = controller.ProcessPayment(PaymentStub.InvalidSecurityCode);
            
            Assert.IsTrue(((List<string>)((BadRequestObjectResult)result).Value).Any(e => e == "SecurityCode maximum length is 3."));
        }

        [TestMethod]
        public void InvalidCreditCardNumber()
        {
            var paymentServiceMock = new Mock<Application.Services.PaymentService>();

            var controller = new PaymentsController(paymentServiceMock.Object);

            var result = controller.ProcessPayment(PaymentStub.InvalidCreditCardNumber);
            
            Assert.IsTrue(((List<string>)((BadRequestObjectResult)result).Value).Any(e => e == "Invalid CreditCardNumber"));
        }

        [TestMethod]
        public void InvalidDate()
        {
            var paymentServiceMock = new Mock<Application.Services.PaymentService>();

            var controller = new PaymentsController(paymentServiceMock.Object);

            var result = controller.ProcessPayment(PaymentStub.InvalidDate);

            Assert.IsTrue(((List<string>)((BadRequestObjectResult)result).Value).Any(e => e == "Invalid ExpirationDate"));
        }

        [TestMethod]
        public void Valid14()
        {
            var paymentServiceMock = new Mock<Application.Services.PaymentService>();

            var controller = new PaymentsController(paymentServiceMock.Object);

            var result = controller.ProcessPayment(PaymentStub.Valid14);

            Assert.IsInstanceOfType(result, typeof(OkResult));
        }

        [TestMethod]
        public void Valid50()
        {
            var paymentServiceMock = new Mock<Application.Services.PaymentService>();

            var controller = new PaymentsController(paymentServiceMock.Object);

            var result = controller.ProcessPayment(PaymentStub.Valid50);

            Assert.IsInstanceOfType(result, typeof(OkResult));
        }

        [TestMethod]
        public void Valid800()
        {
            var paymentServiceMock = new Mock<Application.Services.PaymentService>();

            var controller = new PaymentsController(paymentServiceMock.Object);

            var result = controller.ProcessPayment(PaymentStub.Valid800);

            Assert.IsInstanceOfType(result, typeof(OkResult));
        }

        [TestMethod]
        public void Invalid801()
        {
            var paymentServiceMock = new Mock<Application.Services.PaymentService>();

            var controller = new PaymentsController(paymentServiceMock.Object);

            var result = controller.ProcessPayment(PaymentStub.Invalid801);

            var objResult = (ObjectResult)result;
            Assert.AreEqual(objResult.StatusCode, 500);
            Assert.AreEqual(objResult.Value, "Internal server error. Retried: 3 times.");
        }
    }
}
