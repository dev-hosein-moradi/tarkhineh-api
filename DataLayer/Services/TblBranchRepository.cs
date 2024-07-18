using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer.Contracts;
using Microsoft.EntityFrameworkCore;

namespace DataLayer
{
    public class TblBranchRepository : ITblBranchRepository
    {
        private TarkhinehDbContext _context;
        public TblBranchRepository(TarkhinehDbContext context)
        {
            _context = context;
        }
        public async Task<TblBranch> CreateBranch(TblBranch branch)
        {
            try
            {
                await _context.TblBranch.AddAsync(branch);
                await SaveDb();
                return branch;

            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> DeleteBranch(int id)
        {
            try
            {
                var entity = await FindBranch(id);
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

        public async Task<TblBranch> FindBranch(int id)
        {
            try
            {
                var branch = await _context.TblBranch.FindAsync(id);
                return branch;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IEnumerable<TblBranch>> GetAllBranches()
        {
            return await _context.TblBranch.ToListAsync();
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

        public async Task<TblBranch> UpdateBranch(TblBranch branch)
        {
            try
            {
                _context.Entry(branch).State = EntityState.Modified;
                return branch;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
