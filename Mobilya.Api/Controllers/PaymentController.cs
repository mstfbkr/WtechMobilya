using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Mobilya.Api.Helpers;
using Mobilya.Business.Abstract;
using Mobilya.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mobilya.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private IPaymentService _paymentService;

        public PaymentController(IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }
        

        [HttpPost("GetAll")]
        public async Task<Response<IEnumerable<Payment>>> GetAll()
        {
            var payments = await _paymentService.GetAllPayment();
            if (!payments.Any())
            {
                return new Response<IEnumerable<Payment>>().NoContent();
            }
            //List olsaydı .count parantez yazmamız dpğru değil.
            return new Response<IEnumerable<Payment>>().Ok(payments.Count(), payments);
        }


        [HttpPost]
        [Route("[action]")]
        public IActionResult Post([FromBody] Payment payment)
        {
            var createPayment = _paymentService.CreatePayment(payment);
            return Ok(createPayment);
        }


        [HttpDelete("{id}")]
        public IActionResult Delete(Payment payment)
        {
            _paymentService.DeletePayment(payment);
            return Ok("Product Deleted");
        }

        [HttpPut]
        public IActionResult Put([FromBody] Payment payment)
        {
            if (_paymentService.GetPaymentById(payment.PaymentId) != null)
            {
                return Ok(_paymentService.UpdatePayment(payment));
            }
            return NotFound();
        }


    }
}
