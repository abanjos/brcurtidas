namespace BRCurtidas.Data
{
    public class ScopedServiceType
    {
        public int Id { get; set; }

        public ServiceScope ServiceScope { get; set; }

        public ServiceType ServiceType { get; set; }

        public SocialNetwork SocialNetwork { get; set; }

        public string Description {get; set;}

        public string Title { get; set; }

        public PaymentType PaymentType { get; set; }

        public string Slug {get; set;}

    }
}