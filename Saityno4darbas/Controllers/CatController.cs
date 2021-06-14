using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using AutoMapper;
using ImagesDAL.Models;
using Saityno4darbas.BLL.DtoModels;
using Saityno4darbas.BLL.Services;
using Saityno4darbas.Controllers.Model;
using Saityno4darbas.DAL.Models;
using Microsoft.AspNetCore.Mvc;

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

        //Ideda kates informacija i duomenu baze
        [HttpPost(Name = nameof(AddAsync))]
        public async Task<IActionResult> AddAsync([FromBody] CatDto catDto)
        {
            var cat = await this.catService.AddAsync(this.mapper.Map<Cat>(catDto));

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            return Ok(cat);
        }

        //Istrina issaugota informacija duomenu bazeje is API
        [HttpDelete("{id:int}", Name = nameof(DeleteAsync))]
        public async Task<IActionResult> DeleteAsync([FromRoute] int id)
        {
            await this.catService.DeleteAsync(id);
            
            return NoContent();
        }

        //gauna is interneto CatAPI informacija
        [HttpGet("CatsFromAPI", Name = nameof(Get))]
        public async Task<IActionResult> Get()
        {
            var client = new HttpClient();

            var url = "https://api.thecatapi.com/v1/images/search";

            var cats = new List<CatResponse>();

            var response = await client.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                cats = await JsonSerializer.DeserializeAsync<List<CatResponse>>(
                    await response.Content.ReadAsStreamAsync());
            }

            return Ok(cats);
        }

        //gauna is cat asmenines db visa informacija
        [HttpGet (Name = nameof(GetCats))]
        public async Task<IActionResult> GetCats()
        {
            var cats = await this.catService.GetAsync();

            var z = this.mapper.Map<List<CatDto>>(cats);
            foreach (var t in z)
            {
                t.Links = CreateLinks(t);
            }

            return Ok(z);
        }

        //negali nieko ideti nes isspausdina visus
        [HttpPut("{id:int}", Name = nameof(UpdateAsync))]
        public async Task<IActionResult> UpdateAsync([FromRoute]int id, [FromBody] CatDto catDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            
            await this.catService.UpdateAsync(id, this.mapper.Map<Cat>(catDto));

            return Ok();
        }
        
        private List<LinkDto> CreateLinks(CatDto catDto)
        {
            var list = new List<LinkDto>();
            
            var idObj = new { id = catDto.Id };

            list.Add(
                new LinkDto(this.Url.Link(nameof(GetCats), idObj), "self", "GET"));
            list.Add(
                new LinkDto(this.Url.Link(nameof(UpdateAsync), idObj), "update_cat", "PUT"));
            list.Add(
                new LinkDto(this.Url.Link(nameof(DeleteAsync), idObj), "delete_cat", "DELETE"));
            list.Add(
                new LinkDto(this.Url.Link(nameof(AddAsync), idObj), "update_cat", "POST"));
            return list;
        }
    }
}