using lamar.dependecy.injection.domain;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace lamar.dependecy.injection.infrastructor
{
    public class TopAnimeUpComingProxy : ITopAnimeUpComingProxy
    {
        private static Uri baseAdress = new Uri("https://api.jikan.moe/v3/");

        public async Task<List<TopUpComingAnime>> GetTopUpComingAnime()
        {
            List<TopUpComingAnime> topAnimesUpComings;

            using (var httpclient = new HttpClient { BaseAddress = baseAdress })
            {
                using (var response = await httpclient.GetAsync("top/anime/1/upcoming"))
                {
                    var responseData = await response.Content.ReadAsStringAsync();
                    topAnimesUpComings = Deserializer.jsonDeserializer<AnimeListResponse>(responseData).Top;
                }
            }

            return topAnimesUpComings;
        }

    }
}
