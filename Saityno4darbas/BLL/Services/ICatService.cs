using System.Threading.Tasks;
using Saityno4darbas.DAL.Models;

namespace Saityno4darbas.BLL.Services
{
    public interface ICatService
    {
        //add get by id interface
        
        Task<int> AddAsync(Cat cat);
    }
}