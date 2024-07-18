using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer.Contracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;

namespace DataLayer
{
    public class TblFoodRepository : ITblFoodRepository
    {
        private TarkhinehDbContext _context;
        private IMemoryCache _cache;
        public TblFoodRepository(TarkhinehDbContext context, IMemoryCache cache)
        {
            _context = context;
            _cache = cache;
        }
        public async Task<TblFood> CreateFood(TblFood food)
        {
            try
            {
                await _context.TblFood.AddAsync(food);
                await SaveDb();
                return food;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> DeleteFood(int id)
        {
            try
            {
                var entity = await FindFood(id);
                _context.Entry(entity).State = EntityState.Deleted;
                return true;

            }
            catch (Exception)
            {
                return false;
            }
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public async Task<TblFood> FindFood(int id)
        {
            try
            {
                var food = await _context.TblFood.FindAsync(id);
                return food;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IEnumerable<TblFood>> GetAllFoods()
        {
            var cacheKey = "FoodList";
            var cacheFoods = _cache.Get<IEnumerable<TblFood>>(cacheKey);
            if (cacheFoods != null)
            {
                return cacheFoods;
            }
            else
            {
                var foods = await _context.TblFood.ToListAsync();
                var cacheOptions = new MemoryCacheEntryOptions()
                    .SetSlidingExpiration(TimeSpan.FromSeconds(60));
                _cache.Set(cacheKey, foods, cacheOptions);
                return foods;
            }
        }

        public async Task<bool> SaveDb()
        {
            try
            {
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<TblFood> UpdateFood(TblFood food)
        {
            try
            {
                _context.Entry(food).State = EntityState.Modified;
                return food;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
