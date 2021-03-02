using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace lamar.dependecy.injection.domain
{
    public class AnimeListResponse
    {
        [JsonPropertyName("top")]
        public List<TopUpComingAnime> Top { get; set; } = new List<TopUpComingAnime>();
        
    }
}
