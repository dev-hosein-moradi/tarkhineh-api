using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer.Contracts;
using Microsoft.EntityFrameworkCore;

namespace DataLayer
{
    public class TblCartRepository : ITblCartRepository
    {
        private TarkhinehDbContext _context;
        public TblCartRepository(TarkhinehDbContext context)
        {
            _context = context;
        }
        public async Task<TblCart> CreateCart(TblCart cart)
        {
            try
            {
                await _context.TblCart.AddAsync(cart);
                await SaveDb();
                return cart;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> DeleteCart(int id)
        {
            try
            {
                var entity = await FindCart(id);
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

        public async Task<TblCart> FindCart(int id)
        {
            try
            {
                var cart = await _context.TblCart.FindAsync(id);
                return cart;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IEnumerable<TblCart>> GetAllCarts()
        {
            return await _context.TblCart.ToListAsync();
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

        public async Task<TblCart> UpdateCart(TblCart cart)
        {
            try
            {
                _context.Entry(cart).State = EntityState.Modified;
                return cart;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
