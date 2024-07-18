using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Contracts
{
    public interface ITblDeliveryRepository : IDisposable
    {
        Task<IEnumerable<TblDelivery>> GetAllDeliveries();

        Task<TblDelivery> FindDelivery(int id);

        Task<TblDelivery> CreateDelivery(TblDelivery delivery);

        Task<TblDelivery> UpdateDelivery(TblDelivery delivery);

        Task<bool> DeleteDelivery(int id);

        Task<bool> SaveDb();
    }
}
