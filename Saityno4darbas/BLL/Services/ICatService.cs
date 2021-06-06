using System.Collections.Generic;
using System.Threading.Tasks;
using Saityno4darbas.DAL.Models;

namespace Saityno4darbas.BLL.Services
{
    public interface ICatService
    {
        Task<Cat> GetAsync(int id);
        
        Task<int> AddAsync(Cat cat);

        Task<IEnumerable<Cat>> Get();
        
        Task Update(Cat cat);

        Task Delete(int id);
    }
}