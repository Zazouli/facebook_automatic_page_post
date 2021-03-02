using lamar.dependecy.injection.infrastructor.Logger;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace lamar.dependecy.injection.infrastructor
{
    public class PostOnFaceBookPage : IPostOnFaceBookPage
    {
        private readonly IFaceBookPageAccessTokenProxy _faceBookPageAccessTokenProxy;
        private readonly ITopAnimeUpComingProxy _topAnimeUpComingProxy;
        private readonly ILogger _logger;

        public PostOnFaceBookPage(IFaceBookPageAccessTokenProxy faceBookPageAccessTokenProxy, ITopAnimeUpComingProxy topAnimeUpComingProxy, ILogger logger)
        {
            _faceBookPageAccessTokenProxy = faceBookPageAccessTokenProxy;
            _topAnimeUpComingProxy = topAnimeUpComingProxy;
            _logger = logger;

        }

        public async Task Run()
        {
            var facebookAccessToken = await _faceBookPageAccessTokenProxy.GetFaceBookPageAccessToken();
            var topUpComingAnimeList = await _topAnimeUpComingProxy.GetTopUpComingAnime();

            _logger.Info($"We are postin on facebook page Id: {facebookAccessToken.PageId}, first anime name : {topUpComingAnimeList[0].Title}");

            using (var httpClient = new HttpClient())
            {
                topUpComingAnimeList.ForEach(async anime =>
               {
                   
                   var post = new { message = $@"AnimeTitle:{anime.Title}{Environment.NewLine}AnimeDateOfRelease:{ anime.StartDate}{ Environment.NewLine}",
                   link = anime.Url,
                   access_token = facebookAccessToken.AccessToken
                   };
                   var json = JsonSerializer.Serialize(post);
                   Console.WriteLine(json);
                   var data = new StringContent(json, Encoding.UTF8, "application/json");
                   var response = await httpClient.PostAsync($"https://graph.facebook.com/{facebookAccessToken.PageId}/feed", data);
                   await Task.Delay(1000);
                   Console.WriteLine(response.Content.ReadAsStringAsync());
               }
                );
            }
        }
    }
}
