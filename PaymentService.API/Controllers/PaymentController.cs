using Microsoft.AspNetCore.Mvc;
using PaymentService.Application.Interfaces;
using PaymentService.Domain.Models;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.Net;
using System.Linq;

namespace PaymentService.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentsController : ControllerBase
    {
        private readonly IPaymentService _paymentService;

        public PaymentsController(IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }

        /// <summary>
        /// Process new payment
        /// </summary>
        /// <param name="model">Payment Model</param>
        [SwaggerResponse((int)HttpStatusCode.InternalServerError, "Internal server error.")]
        [SwaggerResponse((int)HttpStatusCode.BadRequest, "Invalid request.", typeof(IEnumerable<string>))]
        [SwaggerResponse((int)HttpStatusCode.BadRequest, "Invalid request.", typeof(IEnumerable<string>))]
        [SwaggerResponse((int)HttpStatusCode.OK, "Payment successfully.", typeof(PaymentResponse))]
        [HttpPost("processPayment")]
        public IActionResult ProcessPayment([FromBody] Payment model)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage));

                var validation = model.Validate();

                if(validation.Any())
                    return BadRequest(validation);

                var response = _paymentService.ProcessPayment(model);

                if (response.Success)
                    return Ok();
                else
                    return StatusCode((int)HttpStatusCode.InternalServerError, response.ErrorMessage);
            }
            catch (Exception)
            {
                return new StatusCodeResult((int)HttpStatusCode.InternalServerError);
            }
        }
    }
}