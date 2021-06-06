using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
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
        //atnaujini duomenu bazeje
        public async Task Update(Cat cat)
        {
            this.context.Entry(cat).State = EntityState.Modified;
            await this.context.SaveChangesAsync();
            throw new System.NotImplementedException();
        }

        //istrina kates pagal Id
        public async Task Delete(int id)
        {
            var catToDelete = await context.Cats.FindAsync(id);

            context.Cats.Remove(catToDelete);
            
            await context.SaveChangesAsync();
        }
        
        //gauna kates pagal Id
        public async Task<Cat> GetAsync(int id)
        {
            return await context.Cats
                .AsNoTracking()
                .SingleOrDefaultAsync(x => x.Id == id);
        }

        //Ideda i duomenu baze
        public async Task<int> AddAsync(Cat cat)
        {
            await this.context.Cats.AddAsync(cat);

            await context.SaveChangesAsync();

            return cat.Id;
        }
        
        //gauna visas kates issaugotas duomenu bazeje
        public async Task<IEnumerable<Cat>> Get()
        {
            return await this.context.Cats.ToListAsync();
        }
    }
}