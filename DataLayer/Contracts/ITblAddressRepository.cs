using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Contracts
{
    public interface ITblAddressRepository : IDisposable
    {
        Task<IEnumerable<TblAddress>> GetAllAddress();

        Task<TblAddress> FindAddress(int id);

        Task<TblAddress> CreateAddress(TblAddress address);

        Task<TblAddress> UpdateAddress(TblAddress address);

        Task<bool> DeleteAddress(int id);

        Task<bool> SaveDb();
    }
}
