using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer.Contracts;
using Microsoft.EntityFrameworkCore;

namespace DataLayer
{
    public class TblDeliveryRepository : ITblDeliveryRepository
    {
        private TarkhinehDbContext _context;
        public TblDeliveryRepository(TarkhinehDbContext context)
        {
            _context = context;
        }
        public async Task<TblDelivery> CreateDelivery(TblDelivery delivery)
        {
            try
            {
                await _context.TblDelivery.AddAsync(delivery);
               await SaveDb();
                return delivery;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> DeleteDelivery(int id)
        {
            try
            {
                var entity = await FindDelivery(id);
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

        public async Task<TblDelivery> FindDelivery(int id)
        {
            try
            {
                var delivery = await _context.TblDelivery.FindAsync(id);
                return delivery;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IEnumerable<TblDelivery>> GetAllDeliveries()
        {
            return await _context.TblDelivery.ToListAsync();
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

        public async Task<TblDelivery> UpdateDelivery(TblDelivery delivery)
        {
            try
            {
                _context.Entry(delivery).State = EntityState.Modified;
                return delivery;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
