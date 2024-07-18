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
    public class AddressesController : ControllerBase
    {
        private readonly ITblAddressRepository _tblAddressRepository;

        public AddressesController(ITblAddressRepository tblAddressRepository)
        {
            _tblAddressRepository = tblAddressRepository;
        }

        // GET: api/Addresses
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TblAddress>>> GetAddress()
        {
            try
            {
                IEnumerable<TblAddress> addresses = await _tblAddressRepository.GetAllAddress();
                if (addresses == null)
                {
                    return NotFound();
                }
                return Ok(addresses);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        // GET: api/Addresses/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TblAddress>> GetAddress(int id)
        {
            var address = await _tblAddressRepository.FindAddress(id);
            try
            {
                if (address == null)
                {
                    return NotFound();
                }
                return Ok(address);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        // PUT: api/Addresses/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAddress(int id, TblAddress address)
        {
            if (id != address.AddressId)
            {
                return BadRequest();
            }

            address.CreatedDate = DateTime.Now.ToLocalTime().ToString();
            await _tblAddressRepository.UpdateAddress(address);

            try
            {
                await _tblAddressRepository.SaveDb();
                return Ok(address);
            }
            catch (DbUpdateConcurrencyException)
            {
                var itemExist = await AddressExists(id);
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

        // POST: api/Addresses
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TblAddress>> PostAddress(TblAddress address)
        {
            address.CreatedDate = DateTime.Now.ToLocalTime().ToString();
            try
            {
                var newFood = await _tblAddressRepository.CreateAddress(address);
                if (newFood != null)
                {
                    await _tblAddressRepository.SaveDb();
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

        // DELETE: api/Addresses/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAddress(int id)
        {
            var entity = await _tblAddressRepository.FindAddress(id);
            try
            {
                if (entity == null)
                {
                    return NotFound();
                }

                await _tblAddressRepository.DeleteAddress(id);
                await _tblAddressRepository.SaveDb();
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        private async Task<bool> AddressExists(int id)
        {
            var entity = await _tblAddressRepository.FindAddress(id);
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
