using BRCurtidas.Web.UI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BRCurtidas.Web.UI.Services.ApiClient
{
    public interface IApiClientService
    {
        Task<IEnumerable<SocialNetwork>> GetSocialNetworksAsync();
    }
}
