using System.Collections.Generic;

namespace BRCurtidas.Web.UI.Services.ApiClient
{
    public class ScopedServiceType
    {
        public ICollection<Product> Products {get; set;}
        public int Id { get; set; }

        public string Description {get; set;}

        public string Title { get; set; }

        public string Slug {get; set;}

        public string Image { get; set; }

        public int PaymentType { get; set; }
    }


}