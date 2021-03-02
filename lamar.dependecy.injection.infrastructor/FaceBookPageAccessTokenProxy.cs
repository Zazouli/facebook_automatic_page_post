using lamar.dependecy.injection.domain;
using Microsoft.Extensions.Configuration;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace lamar.dependecy.injection.infrastructor
{
    public class FaceBookPageAccessTokenProxy : IFaceBookPageAccessTokenProxy
    {
        private string _facebookUserAccessToken;
        private string _pageId;
        public FaceBookPageAccessTokenProxy(IConfiguration configuration)
        {
            _facebookUserAccessToken = configuration["longLivedFaceBookUserAccessToken"];
            _pageId = configuration["pageId"];
        }

        public async Task<FaceBookPageAccessTokenResponse> GetFaceBookPageAccessToken()
        {
            FaceBookPageAccessTokenResponse faceBookPageAccessTokenResponse;
            using (var httpclient = new HttpClient())
            {
                using (var response = await httpclient.GetAsync($"https://graph.facebook.com/{_pageId}?fields=access_token&access_token={_facebookUserAccessToken}"))
                {
                    var responseData = await response.Content.ReadAsStringAsync();
                    faceBookPageAccessTokenResponse = Deserializer.jsonDeserializer<FaceBookPageAccessTokenResponse>(responseData);
                    
                }
            }
            return faceBookPageAccessTokenResponse;
        }
    }
}
