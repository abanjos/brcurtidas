namespace BRCurtidas.Web.Api.Controllers
{
    internal class ScopedServiceTypeResponseModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Slug { get; set; }
        public string Description {get; set;}
        public string Image { get; set; }
        public int PaymentType { get; set; }
    }
}