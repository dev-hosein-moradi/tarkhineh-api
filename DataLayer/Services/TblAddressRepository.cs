using DataLayer.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class TblAddressRepository : ITblAddressRepository
    {
        private TarkhinehDbContext _context;
        public TblAddressRepository(TarkhinehDbContext context)
        {
            _context = context;
        }
        public async Task<TblAddress> CreateAddress(TblAddress address)
        {
            try
            {
                await _context.TblAddress.AddAsync(address);
               await SaveDb();
                return address;

            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> DeleteAddress(int id)
        {
            try
            {
                var entity = await FindAddress(id);
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

        public async Task<TblAddress> FindAddress(int id)
        {
            try
            {
                var address = await _context.TblAddress.FindAsync(id);
                return address;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IEnumerable<TblAddress>> GetAllAddress()
        {
            return await _context.TblAddress.ToListAsync();
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

        public async Task<TblAddress> UpdateAddress(TblAddress address)
        {
            try
            {
                _context.Entry(address).State = EntityState.Modified;
                return address;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
