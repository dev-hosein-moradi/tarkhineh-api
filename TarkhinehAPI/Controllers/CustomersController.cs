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
    public class CustomersController : ControllerBase
    {
        private readonly ITblCustomerRepository _tblCustomerRepository;

        public CustomersController(ITblCustomerRepository tblCustomerRepository)
        {
            _tblCustomerRepository = tblCustomerRepository;
        }

        // GET: api/Customers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TblCustomer>>> GetCustomer()
        {
            try
            {
                IEnumerable<TblCustomer> customers = await _tblCustomerRepository.GetAllCustomer();
                if (customers == null)
                {
                    return NotFound();
                }
                return Ok(customers);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        // GET: api/Customers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TblCustomer>> GetCustomer(int id)
        {
            var customer = await _tblCustomerRepository.FindCustomer(id);
            try
            {
                if (customer == null)
                {
                    return NotFound();
                }
                return Ok(customer);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        // PUT: api/Customers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCustomer(int id, TblCustomer customer)
        {
            if (id != customer.CustomerId)
            {
                return BadRequest();
            }

            customer.CreatedDate = DateTime.Now.ToLocalTime().ToString();
            await _tblCustomerRepository.UpdateCustomer(customer);

            try
            {
                await _tblCustomerRepository.SaveDb();
                return Ok(customer);
            }
            catch (DbUpdateConcurrencyException)
            {
                var itemExist = await CustomerExists(id);
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

        // POST: api/Customers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TblCustomer>> PostCustomer(TblCustomer customer)
        {
            customer.CreatedDate = DateTime.Now.ToLocalTime().ToString();
            try
            {
                var newCustomer = await _tblCustomerRepository.CreateCustomer(customer);
                if (newCustomer != null)
                {
                    await _tblCustomerRepository.SaveDb();
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

        // DELETE: api/Customers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTblCustomer(int id)
        {
            var entity = await _tblCustomerRepository.FindCustomer(id);
            try
            {
                if (entity == null)
                {
                    return NotFound();
                }

                await _tblCustomerRepository.DeleteCustomer(id);
                await _tblCustomerRepository.SaveDb();
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        private async Task<bool> CustomerExists(int id)
        {
            var entity = await _tblCustomerRepository.FindCustomer(id);
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
