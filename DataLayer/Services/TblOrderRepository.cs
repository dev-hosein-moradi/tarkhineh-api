using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer.Contracts;
using Microsoft.EntityFrameworkCore;

namespace DataLayer
{
    public class TblOrderRepository : ITblOrderRepository
    {
        private TarkhinehDbContext _context;
        public TblOrderRepository(TarkhinehDbContext context)
        {
            _context = context;
        }
        public async Task<TblOrder> CreateOrder(TblOrder order)
        {
            try
            {
                await _context.TblOrder.AddAsync(order);
               await SaveDb();
                return order;

            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> DeleteOrder(int id)
        {
            try
            {
                var entity = await FindOrder(id);
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

        public async Task<TblOrder> FindOrder(int id)
        {
            try
            {
                var order = await _context.TblOrder.FindAsync(id);
                return order;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IEnumerable<TblOrder>> GetAllOrders()
        {
            return await _context.TblOrder.ToListAsync();
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

        public async Task<TblOrder> UpdateOrder(TblOrder order)
        {
            try
            {
                _context.Entry(order).State = EntityState.Modified;
                return order;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
