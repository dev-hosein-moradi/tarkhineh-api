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
    public class DeliveriesController : ControllerBase
    {
        private readonly ITblDeliveryRepository _tblDeliveryRepository;

        public DeliveriesController(ITblDeliveryRepository tblDeliveryRepository)
        {
            _tblDeliveryRepository = tblDeliveryRepository;
        }

        // GET: api/Deliveries
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TblDelivery>>> GetDelivery()
        {
            try
            {
                IEnumerable<TblDelivery> deliveries = await _tblDeliveryRepository.GetAllDeliveries();
                if (deliveries == null)
                {
                    return NotFound();
                }
                return Ok(deliveries);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        // GET: api/Deliveries/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TblDelivery>> GetDelivery(int id)
        {
            var delivery = await _tblDeliveryRepository.FindDelivery(id);
            try
            {
                if (delivery == null)
                {
                    return NotFound();
                }
                return Ok(delivery);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        // PUT: api/Deliveries/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDelivery(int id, TblDelivery delivery)
        {
            if (id != delivery.DeliveryId)
            {
                return BadRequest();
            }

            delivery.CreatedDate = DateTime.Now.ToLocalTime().ToString();
            await _tblDeliveryRepository.UpdateDelivery(delivery);

            try
            {
                await _tblDeliveryRepository.SaveDb();
                return Ok(delivery);
            }

            catch (DbUpdateConcurrencyException)
            {
                var itemExist = await DeliveryExists(id);
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

        // POST: api/Deliveries
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TblDelivery>> PostDelivery(TblDelivery delivery)
        {
            delivery.CreatedDate = DateTime.Now.ToLocalTime().ToString();
            try
            {
                var newDelivery = await _tblDeliveryRepository.CreateDelivery(delivery);
                if (newDelivery != null)
                {
                    await _tblDeliveryRepository.SaveDb();
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

        // DELETE: api/Deliveries/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDelivery(int id)
        {
            var entity = await _tblDeliveryRepository.FindDelivery(id);
            try
            {
                if (entity == null)
                {
                    return NotFound();
                }

                await _tblDeliveryRepository.DeleteDelivery(id);
                await _tblDeliveryRepository.SaveDb();
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        private async Task<bool> DeliveryExists(int id)
        {
            var entity = await _tblDeliveryRepository.FindDelivery(id);
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
