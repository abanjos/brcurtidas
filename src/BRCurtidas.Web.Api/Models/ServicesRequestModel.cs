using BRCurtidas.Data;

namespace BRCurtidas.Web.Api.Models
{
    public class ServicesRequestModel : PaginationModel
    {
        public SocialNetwork? SocialNetwork { get; set; }

        public ServiceScope? Scope { get; set; }
    }
}
