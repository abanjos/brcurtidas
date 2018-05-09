using BRCurtidas.Data;

namespace BRCurtidas.Web.Api.Models
{
    public class ServiceResponseModel
    {
        public long Id { get; set; }

        public ServiceScope Category { get; set; }

        public string Description { get; set; }

        public PaymentType PaymentType { get; set; }

        public decimal Price { get; set; }

        public SocialNetwork SocialNetwork { get; set; }

        public ServiceType Type { get; set; }
    }
}
