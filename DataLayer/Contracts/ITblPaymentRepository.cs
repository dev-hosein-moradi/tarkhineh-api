using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Contracts
{
    public interface ITblPaymentRepository : IDisposable
    {
        Task<IEnumerable<TblPayment>> GetAllPayments();

        Task<TblPayment> FindPayment(int id);

        Task<TblPayment> CreatePayment(TblPayment payment);

        Task<TblPayment> UpdatePayment(TblPayment payment);

        Task<bool> DeletePayment(int id);

        Task<bool> SaveDb();
    }
}
