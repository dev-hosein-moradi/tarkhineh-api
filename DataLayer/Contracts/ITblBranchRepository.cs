using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Contracts
{
    public interface ITblBranchRepository : IDisposable
    {
        Task<IEnumerable<TblBranch>> GetAllBranches();

        Task<TblBranch> FindBranch(int id);

        Task<TblBranch> CreateBranch(TblBranch branch);

        Task<TblBranch> UpdateBranch(TblBranch branch);

        Task<bool> DeleteBranch(int id);

        Task<bool> SaveDb();
    }
}
