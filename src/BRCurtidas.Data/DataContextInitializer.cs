using System.Linq;

namespace BRCurtidas.Data
{
    public static class DataContextInitializer
    {
        public static void Initialize(DataContext context)
        {
            context.Database.EnsureCreated();

            if (context.Products.Any())
                return;

            var serviceScopes = new ServiceScope[] {
                new ServiceScope { Name = "Internacional"},
                new ServiceScope { Name = "Nacional" }
            };

             context.ServiceScopes.AddRange(serviceScopes);

            var serviceTypes = new ServiceType[] {
                new ServiceType { Name = "Curtidas" },
                new ServiceType { Name = "Visualizações" },
                new ServiceType { Name = "Seguidores" },
                new ServiceType { Name = "Inscrições" }
            };

            context.ServiceTypes.AddRange(serviceTypes);

            var socialNetworks = new SocialNetwork[] {
                new SocialNetwork { Name = "Instagram"},
                new SocialNetwork { Name = "YouTube"},
                new SocialNetwork { Name = "Twitter"},
                new SocialNetwork { Name = "Facebook"}
            };

            context.SocialNetworks.AddRange(socialNetworks);

            var paymentTypes = new PaymentType[] {
                new PaymentType { Name = "Single" },
                new PaymentType { Name = "Recurrent" },
            };

            context.PaymentTypes.AddRange(paymentTypes);

            var scopedServiceTypes = new ScopedServiceType[] {
                new ScopedServiceType {                 
                    ServiceScope = serviceScopes.ElementAt(1), //nacional
                    ServiceType = serviceTypes.ElementAt(0), //curtidas
                    SocialNetwork = socialNetworks.ElementAt(0), //instagram
                    PaymentType = paymentTypes.ElementAt(1),//plano
                    Title = "Curtidas Automáticas Brasileiras",
                    Slug = "curtidas-automaticas-brasileiras",
                    Description = "Neste plano você ganhará curtidas BRASILEIRAS reais e ativas durante todo o mês em cada foto que postar após a assinatura de forma automática. É uma plano ideal para quem trabalha com visibilidade no Instagram como artistas, músicos, lojas físicas ou virtuais que estão constantemente atualizando seu perfil para melhorar o alcance de suas vendas ou trabalho. As curtidas entram de forma natural."
                }
            };


            context.ScopedServiceTypes.AddRange(scopedServiceTypes);

            var products = new Product[]
            {
                new Product
                {
                    ScopedServiceType = scopedServiceTypes.ElementAt(0),
                    Description = "Teste teste teste teste Teste teste teste teste Teste teste teste teste",
                    Title = "Teste teste",
                    Price = 10m,
                    Enabled = true            
                }
            };

            context.Products.AddRange(products);
            context.SaveChanges();
        }
    }
}
