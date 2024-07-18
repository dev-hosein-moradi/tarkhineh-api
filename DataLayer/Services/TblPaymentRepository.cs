using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer.Contracts;
using Microsoft.EntityFrameworkCore;

namespace DataLayer
{
    public class TblPaymentRepository : ITblPaymentRepository
    {
        private TarkhinehDbContext _context;
        public TblPaymentRepository(TarkhinehDbContext context)
        {
            _context = context;
        }
        public async Task<TblPayment> CreatePayment(TblPayment payment)
        {
            try
            {
                await _context.TblPayment.AddAsync(payment);
                await SaveDb();
                return payment;

            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> DeletePayment(int id)
        {
            try
            {
                var entity = await FindPayment(id);
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

        public async Task<TblPayment> FindPayment(int id)
        {
            try
            {
                var payment = await _context.TblPayment.FindAsync(id);
                return payment;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IEnumerable<TblPayment>> GetAllPayments()
        {
            return await _context.TblPayment.ToListAsync();
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

        public async Task<TblPayment> UpdatePayment(TblPayment payment)
        {
            try
            {
                _context.Entry(payment).State = EntityState.Modified;
                return payment;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
