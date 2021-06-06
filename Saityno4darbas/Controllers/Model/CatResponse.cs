using System.Text.Json.Serialization;

namespace Saityno4darbas.Controllers.Model
{
    public class CatResponse
    {
            [JsonPropertyName("id")]
            public string id { get; set; }
            
            [JsonPropertyName("url")]
            public string Url { get; set; }
            
            [JsonPropertyName("width")]
            public int Width { get; set; }
            
            [JsonPropertyName("height")]
            public int Height { get; set; }
    }
}