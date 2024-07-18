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
    public class CartsController : ControllerBase
    {
        private readonly ITblCartRepository _tblCartRepository;

        public CartsController(ITblCartRepository tblCartRepository)
        {
            _tblCartRepository = tblCartRepository;
        }

        // GET: api/Carts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TblCart>>> GetCart()
        {
            try
            {
                IEnumerable<TblCart> carts = await _tblCartRepository.GetAllCarts();
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

        // GET: api/Carts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TblCart>> GetCart(int id)
        {
            var cart = await _tblCartRepository.FindCart(id);
            try
            {
                if (cart == null)
                {
                    return NotFound();
                }
                return Ok(cart);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        // PUT: api/Carts/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCart(int id, TblCart cart)
        {
            if (id != cart.CartId)
            {
                return BadRequest();
            }

            cart.CreatedDate = DateTime.Now.ToLocalTime().ToString();
            await _tblCartRepository.UpdateCart(cart);

            try
            {
                await _tblCartRepository.SaveDb();
                return Ok(cart);
            }

            catch (DbUpdateConcurrencyException)
            {
                var itemExist = await CartExists(id);
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

        // POST: api/Carts
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TblCart>> PostCart(TblCart cart)
        {
            cart.CreatedDate = DateTime.Now.ToLocalTime().ToString();
            try
            {
                var newCart = await _tblCartRepository.CreateCart(cart);
                if (newCart != null)
                {
                    await _tblCartRepository.SaveDb();
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

        // DELETE: api/Carts/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCart(int id)
        {
            var entity = await _tblCartRepository.FindCart(id);
            try
            {
                if (entity == null)
                {
                    return NotFound();
                }

                await _tblCartRepository.DeleteCart(id);
                await _tblCartRepository.SaveDb();
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        private async Task<bool> CartExists(int id)
        {
            var entity = await _tblCartRepository.FindCart(id);
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
