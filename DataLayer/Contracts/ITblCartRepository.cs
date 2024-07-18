using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Contracts
{
    public interface ITblCartRepository : IDisposable
    {
        Task<IEnumerable<TblCart>> GetAllCarts();

        Task<TblCart> FindCart(int id);

        Task<TblCart> CreateCart(TblCart cart);

        Task<TblCart> UpdateCart(TblCart cart);

        Task<bool> DeleteCart(int id);

        Task<bool> SaveDb();
    }
}
