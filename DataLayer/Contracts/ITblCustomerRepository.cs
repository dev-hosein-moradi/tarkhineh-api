using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Contracts
{
    public interface ITblCustomerRepository : IDisposable
    {
        Task<IEnumerable<TblCustomer>> GetAllCustomer();

        Task<TblCustomer> FindCustomer(int id);

        Task<TblCustomer> CreateCustomer(TblCustomer customer);

        Task<TblCustomer> UpdateCustomer(TblCustomer customer);

        Task<bool> DeleteCustomer(int id);

        Task<bool> SaveDb();
    }
}
