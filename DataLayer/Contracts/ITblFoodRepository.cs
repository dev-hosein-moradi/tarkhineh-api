using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Contracts
{
    public interface ITblFoodRepository : IDisposable
    {
        Task<IEnumerable<TblFood>> GetAllFoods();

        Task<TblFood> FindFood(int id);

        Task<TblFood> CreateFood(TblFood food);

        Task<TblFood> UpdateFood(TblFood food);

        Task<bool> DeleteFood(int id);

        Task<bool> SaveDb();
    }
}
