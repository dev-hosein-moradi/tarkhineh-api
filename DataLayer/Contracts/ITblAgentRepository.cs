using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public interface ITblAgentRepository : IDisposable
    {
        Task<IEnumerable<TblAgent>> GetAllAgent();

        Task<TblAgent> FindAgent(int id);

        Task<TblAgent> CreateAgent(TblAgent agent);

        Task<TblAgent> UpdateAgent(TblAgent agent);

        Task<bool> DeleteAgent(int id);

        Task<bool> SaveDb();
    }
}
