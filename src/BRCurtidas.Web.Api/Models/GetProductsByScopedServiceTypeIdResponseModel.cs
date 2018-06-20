namespace BRCurtidas.Web.Api.Models
{
    internal class GetProductsByScopedServiceTypeIdResponseModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public decimal Price {get; set;}
    }
}