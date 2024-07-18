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
    public class OrdersController : ControllerBase
    {
        private readonly ITblOrderRepository _tblOrderRepository;

        public OrdersController(ITblOrderRepository tblOrderRepository)
        {
            _tblOrderRepository = tblOrderRepository;
        }

        // GET: api/Orders
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TblOrder>>> GetOrder()
        {
            try
            {
                IEnumerable<TblOrder> carts = await _tblOrderRepository.GetAllOrders();
                if (carts == null)
                {
                    return NotFound();
                }
                return Ok(carts);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        // GET: api/Orders/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TblOrder>> GetOrder(int id)
        {
            var order = await _tblOrderRepository.FindOrder(id);
            try
            {
                if (order == null)
                {
                    return NotFound();
                }
                return Ok(order);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        // PUT: api/Orders/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrder(int id, TblOrder order)
        {
            if (id != order.OrderId)
            {
                return BadRequest();
            }

            order.CreatedDate = DateTime.Now.ToLocalTime().ToString();
            await _tblOrderRepository.UpdateOrder(order);

            try
            {
                await _tblOrderRepository.SaveDb();
                return Ok(order);
            }

            catch (DbUpdateConcurrencyException)
            {
                var itemExist = await OrderExists(id);
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

        // POST: api/Orders
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TblOrder>> PostOrder(TblOrder order)
        {
            order.CreatedDate = DateTime.Now.ToLocalTime().ToString();
            try
            {
                var newOrder = await _tblOrderRepository.CreateOrder(order);
                if (newOrder != null)
                {
                    await _tblOrderRepository.SaveDb();
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

        // DELETE: api/Orders/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTblOrder(int id)
        {
            var entity = await _tblOrderRepository.FindOrder(id);
            try
            {
                if (entity == null)
                {
                    return NotFound();
                }

                await _tblOrderRepository.DeleteOrder(id);
                await _tblOrderRepository.SaveDb();
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        private async Task<bool> OrderExists(int id)
        {
            var entity = await _tblOrderRepository.FindOrder(id);
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
