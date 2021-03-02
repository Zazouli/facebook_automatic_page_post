using lamar.dependecy.injection.domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace lamar.dependecy.injection.infrastructor
{
    public interface ITopAnimeUpComingProxy
    {
        Task<List<TopUpComingAnime>> GetTopUpComingAnime();
    }
}