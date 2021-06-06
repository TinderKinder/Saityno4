using System.Threading.Tasks;
using Saityno4darbas.BLL.DtoModels;
using Saityno4darbas.DAL.Data;
using Saityno4darbas.DAL.Models;

namespace Saityno4darbas.BLL.Services
{
    public class CatService : ICatService
    {
        private readonly ApplicationDbContext context;
        
        public CatService(ApplicationDbContext context)
        {
            this.context = context;
        }

        // get by id

        public async Task<int> AddAsync(Cat cat)
        {
            // check if cat id exists
            
            //if cat exists throw new exeption bla blah bnlah exists
            await this.context.Cats.AddAsync(cat);

            await context.SaveChangesAsync();

            return cat.Id;
        }
    }
}