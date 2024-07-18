using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class TblAgentRepository : ITblAgentRepository
    {
        private TarkhinehDbContext _context;
        public TblAgentRepository(TarkhinehDbContext context)
        {
            _context = context;
        }

        public async Task<TblAgent> CreateAgent(TblAgent agent)
        {
            try
            {
                await _context.TblAgent.AddAsync(agent);
                await SaveDb();
                return agent;

            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> DeleteAgent(int id)
        {
            try
            {
                var entity = await FindAgent(id);
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

        public async Task<TblAgent> FindAgent(int id)
        {
            try
            {
                var agent = await _context.TblAgent.FindAsync(id);
                return agent;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IEnumerable<TblAgent>> GetAllAgent()
        {
            return await _context.TblAgent.ToListAsync();
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

        public async Task<TblAgent> UpdateAgent(TblAgent agent)
        {
            try
            {
                _context.Entry(agent).State = EntityState.Modified;
                return agent;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
