using lamar.dependecy.injection.domain;
using System.Threading.Tasks;

namespace lamar.dependecy.injection.infrastructor
{
    public interface IFaceBookPageAccessTokenProxy
    {
        Task<FaceBookPageAccessTokenResponse> GetFaceBookPageAccessToken();
    }
}