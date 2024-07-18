using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DataLayer;
using DataLayer.Contracts;
using TarkhinehAPI.Models;

namespace TarkhinehAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FoodsController : ControllerBase
    {
        private readonly ITblFoodRepository _tblFoodRepository;

        public FoodsController(ITblFoodRepository tblFoodRepository)
        {
            _tblFoodRepository = tblFoodRepository;
        }

        // GET: api/Foods
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TblFood>>> GetFoods([FromQuery] FoodFiltringParam param)
        {
            try
            {
                IEnumerable<TblFood> foods = await _tblFoodRepository.GetAllFoods();
                if(foods == null)
                {
                    return NotFound();
                }
               
                var filteredResult = foods.Where(f => f.Reagion.Contains(param.Reagion) || f.Type.Contains(param.Type) || f.Tags.Contains(param.SortBy)).Distinct();
                return Ok(filteredResult);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        // GET: api/Foods/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TblFood>> FindFood(int id)
        {
            var food = await _tblFoodRepository.FindFood(id);
            try
            {
                if (food == null)
                {
                    return NotFound();
                }
                return Ok(food);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        // PUT: api/Foods/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFood(int id, TblFood food)
        {
            if (id != food.FoodId)
            {
                return BadRequest();
            }

            food.CreatedDate = DateTime.Now.ToLocalTime().ToString();
            await _tblFoodRepository.UpdateFood(food);

            try
            {
                await _tblFoodRepository.SaveDb();
                return Ok(food);
            }
            catch (DbUpdateConcurrencyException)
            {
                var itemExist = await FoodExists(id);
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

        // POST: api/Foods
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TblFood>> PostFood(TblFood food)
        {
            food.CreatedDate = DateTime.Now.ToLocalTime().ToString();
            try
            {
                var newFood = await _tblFoodRepository.CreateFood(food);
                if (newFood != null)
                {
                    await _tblFoodRepository.SaveDb();
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

        // DELETE: api/Foods/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFood(int id)
        {
            var entity = await _tblFoodRepository.FindFood(id);
            try
            {
                if (entity == null)
                {
                    return NotFound();
                }

                await _tblFoodRepository.DeleteFood(id);
                await _tblFoodRepository.SaveDb();
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        private async Task<bool> FoodExists(int id)
        {
            var entity = await _tblFoodRepository.FindFood(id);
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
