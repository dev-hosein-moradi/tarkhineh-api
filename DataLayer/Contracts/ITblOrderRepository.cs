using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Contracts
{
    public interface ITblOrderRepository : IDisposable
    {
        Task<IEnumerable<TblOrder>> GetAllOrders();

        Task<TblOrder> FindOrder(int id);

        Task<TblOrder> CreateOrder(TblOrder order);

        Task<TblOrder> UpdateOrder(TblOrder order);

        Task<bool> DeleteOrder(int id);

        Task<bool> SaveDb();
    }
}
