using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer.Contracts;
using Microsoft.EntityFrameworkCore;

namespace DataLayer
{
    public class TblCustomerRepository : ITblCustomerRepository
    {
        private TarkhinehDbContext _context;
        public TblCustomerRepository(TarkhinehDbContext context)
        {
            _context = context;
        }
        public async Task<TblCustomer> CreateCustomer(TblCustomer customer)
        {
            try
            {
                await _context.TblCustomer.AddAsync(customer);
                await SaveDb();
                return customer;

            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> DeleteCustomer(int id)
        {
            try
            {
                var entity = await FindCustomer(id);
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

        public async Task<TblCustomer> FindCustomer(int id)
        {
            try
            {
                var customer = await _context.TblCustomer.FindAsync(id);
                return customer;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IEnumerable<TblCustomer>> GetAllCustomer()
        {
            return await _context.TblCustomer.ToListAsync();
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

        public async Task<TblCustomer> UpdateCustomer(TblCustomer customer)
        {
            try
            {
                _context.Entry(customer).State = EntityState.Modified;
                return customer;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
