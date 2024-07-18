using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DataLayer;
using DataLayer.Contracts;

namespace TarkhinehAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentsController : ControllerBase
    {
        private readonly ITblPaymentRepository _tblPaymentRepository;

        public PaymentsController(ITblPaymentRepository tblPaymentRepository)
        {
            _tblPaymentRepository = tblPaymentRepository;
        }

        // GET: api/Payments
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TblPayment>>> GetPayment()
        {
            try
            {
                IEnumerable<TblPayment> payments = await _tblPaymentRepository.GetAllPayments();
                if (payments == null)
                {
                    return NotFound();
                }
                return Ok(payments);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        // GET: api/Payments/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TblPayment>> GetPayment(int id)
        {
            var payment = await _tblPaymentRepository.FindPayment(id);
            try
            {
                if (payment == null)
                {
                    return NotFound();
                }
                return Ok(payment);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        // PUT: api/Payments/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPayment(int id, TblPayment payment)
        {
            if (id != payment.PaymentId)
            {
                return BadRequest();
            }

            payment.CreatedDate = DateTime.Now.ToLocalTime().ToString();
            await _tblPaymentRepository.UpdatePayment(payment);

            try
            {
                await _tblPaymentRepository.SaveDb();
                return Ok(payment);
            }

            catch (DbUpdateConcurrencyException)
            {
                var itemExist = await PaymentExists(id);
                if (!itemExist)
                {
                    return NotFound();
                }
                else
                {
                    return BadRequest();
                }
            }
        }

        // POST: api/Payments
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TblPayment>> PostPayment(TblPayment payment)
        {
            payment.CreatedDate = DateTime.Now.ToLocalTime().ToString();
            try
            {
                var newPayment = await _tblPaymentRepository.CreatePayment(payment);
                if (newPayment != null)
                {
                    await _tblPaymentRepository.SaveDb();
                    return Ok();
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        // DELETE: api/Payments/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePayment(int id)
        {
            var entity = await _tblPaymentRepository.FindPayment(id);
            try
            {
                if (entity == null)
                {
                    return NotFound();
                }

                await _tblPaymentRepository.DeletePayment(id);
                await _tblPaymentRepository.SaveDb();
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        private async Task<bool> PaymentExists(int id)
        {
            var entity = await _tblPaymentRepository.FindPayment(id);
            if (entity == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
