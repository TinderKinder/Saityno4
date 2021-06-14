using System.Collections.Generic;
using ImagesDAL.Models;

namespace Saityno4darbas.BLL.DtoModels
{
    public class CatDto
    {
        public int Id { get; set; }
        
        public string CatId { get; set; }
            
        public string Url { get; set; }
            
        public int Width { get; set; }
            
        public int Height { get; set; }
        
        public List<LinkDto> Links { get; set; }
    }
}