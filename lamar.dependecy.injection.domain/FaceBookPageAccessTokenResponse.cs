using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace lamar.dependecy.injection.domain
{
    public class FaceBookPageAccessTokenResponse
    {
        [JsonPropertyName("access_token")]
        public string AccessToken { get; set; }

        [JsonPropertyName("id")]
        public string PageId { get; set; }
    }
}
