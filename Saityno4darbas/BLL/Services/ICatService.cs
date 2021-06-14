using System.Collections.Generic;
using System.Threading.Tasks;
using Saityno4darbas.DAL.Models;

namespace Saityno4darbas.BLL.Services
{
    public interface ICatService
    {
        Task<Cat> GetAsync(int id);
        
        Task<int> AddAsync(Cat cat);

        Task<List<Cat>> GetAsync();
        
        Task UpdateAsync(int id, Cat cat);

        Task DeleteAsync(int id);
    }
}