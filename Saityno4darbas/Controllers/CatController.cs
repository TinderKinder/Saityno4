using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Saityno4darbas.BLL.DtoModels;
using Saityno4darbas.BLL.Services;
using Saityno4darbas.Controllers.Model;
using Saityno4darbas.DAL.Models;

namespace Saityno4darbas.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CatController : ControllerBase
    {
        private readonly ICatService catService;
        private readonly IMapper mapper;
        
        public CatController(ICatService catService, IMapper mapper)
        {
            this.catService = catService;
            this.mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> AddAsync([FromBody] CatDto catDto)
        {
            var cat = await this.catService.AddAsync(this.mapper.Map<Cat>(catDto));

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            return Ok(cat);
        }
        
     /*   [HttpGet("{id:int}")]
        public async Task<IActionResult<CatId>> GetId(int id)
        {
            try
            {
                var result = await catService.GetId(id);

                if (result == null) return NotFound();

                return result;
            }
            catch (Exception)
            {
                return;
            }
        }
        */
    [HttpDelete("{id}")]
     public async Task<IActionResult> Delete(int id)
     {
         var catToDelete = await this.catService.GetAsync(id);

         if (catToDelete == null)
             return NotFound();

         await this.catService.Delete(catToDelete.Id);
         return NoContent();

     }
        
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var client = new HttpClient();
            
            var url = "https://api.thecatapi.com/v1/images/search";
            
            var cats = new List<CatResponse>();
            
            var response = await client.GetAsync(url);
            
            if (response.IsSuccessStatusCode)
            {
                cats = await JsonSerializer.DeserializeAsync<List<CatResponse>>(await response.Content.ReadAsStreamAsync());
            }

            return Ok(cats);
        }
    }
}