using BRCurtidas.Data;

namespace BRCurtidas.Web.Api.Models
{
    public class ServicesRequestModel : PaginationModel
    {
        public int? SocialNetwork { get; set; }

        public int? Scope { get; set; }
    }
}
