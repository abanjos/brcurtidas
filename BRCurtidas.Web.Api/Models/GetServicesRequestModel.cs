using BRCurtidas.Data;

namespace BRCurtidas.Web.Api.Models
{
    public class GetServicesRequestModel : PaginationModel
    {
        public SocialNetwork? SocialNetwork { get; set; }

        public ServiceCategory? ServiceCategory { get; set; }
    }
}
