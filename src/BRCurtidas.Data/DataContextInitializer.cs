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
                    Image = "/images/instagram-logo.png",
                    Description = "Neste plano você ganhará curtidas BRASILEIRAS reais e ativas durante todo o mês em cada foto que postar após a assinatura de forma automática. É uma plano ideal para quem trabalha com visibilidade no Instagram como artistas, músicos, lojas físicas ou virtuais que estão constantemente atualizando seu perfil para melhorar o alcance de suas vendas ou trabalho. As curtidas entram de forma natural."
                },

                new ScopedServiceType {                 
                    ServiceScope = serviceScopes.ElementAt(1), //nacional
                    ServiceType = serviceTypes.ElementAt(0), //curtidas
                    SocialNetwork = socialNetworks.ElementAt(0), //instagram
                    PaymentType = paymentTypes.ElementAt(0),//avulso
                    Title = "Curtidas Brasileiras",
                    Slug = "curtidas-brasileiras",
                    Image = "/images/instagram-logo.png",
                    Description = "Por que comprar curtidas? Curtidas nas fotos ajuda na visibilidade dos seus posts e do seu Instagram. Os sistemas de buscas utilizam também como parâmetro a movimentação de curtidas, ou seja, aumentar seu número de curtidas irá melhorar seu ranking nesses sistemas de busca melhorando a movimentação do seu perfil. As curtidas tem a entrega rápida, mas você pode definir conosco a melhor forma que deseja recebê-las. Nesta opção você escolhe a quantidade que deseja, o pedido mínimo é 50 e o máximo 5 mil."
                },

                new ScopedServiceType {                 
                    ServiceScope = serviceScopes.ElementAt(1), //nacional
                    ServiceType = serviceTypes.ElementAt(1), //seguidores
                    SocialNetwork = socialNetworks.ElementAt(0), //instagram
                    PaymentType = paymentTypes.ElementAt(0),//avulso
                    Title = "Seguidores Brasileiros",
                    Slug = "seguidores-brasileiros",
                    Image = "/images/instagram-logo.png",
                    Description = "Ao clicar em “comprar”, você estará recebendo seguidores derivados de perfis Brasileiros REAIS e ATIVOS no Instagram sem precisar seguir ninguém de volta. As vantagens de serem BRASILEIROS está na credibilidade/confiabilidade sobre o retorno do alcance que seu perfil irá produzir tempo depois que o serviço for ativado. Este serviço é ideal para quem deseja expandir a carreira pela internet, ou para quem apenas deseja ter um perfil influente para conquistar ainda mais seguidores de forma natural."
                },

                new ScopedServiceType {                 
                    ServiceScope = serviceScopes.ElementAt(1), //nacional
                    ServiceType = serviceTypes.ElementAt(1), //seguidores
                    SocialNetwork = socialNetworks.ElementAt(0), //instagram
                    PaymentType = paymentTypes.ElementAt(0),//avulso
                    Title = "Plano Seguidores Brasileiros",
                    Slug = "plano-seguidores-brasileiros",
                    Image = "/images/instagram-logo.png",
                    Description = "Neste plano você ganhará SEGUIDORES BRASILEIROS reais e ativos durante todo o mês, recebendo aos poucos de forma natural. É um plano ideal para quem quer sempre estar recebendo novos seguidores em sua página, aumenta o alcance da sua rede no INSTAGRAM. Tenha muito mais visibilidade com este plano."                }
            };


            context.ScopedServiceTypes.AddRange(scopedServiceTypes);

            var products = new Product[]
            {
                //curtidas automáticas
                new Product
                {
                    ScopedServiceType = scopedServiceTypes.ElementAt(0),
                    Description = 
                    "<ul style=\"list-style: none\"><li>- Entrega automática</li><li>- Sigilo Total</li><li>- Legal e livre de riscos</li><li>- Não precisamos da senha</li><li>- Plano Mensal</li></ul>",
                    Title = "<p><span style=\"color: #cc0033\">50</span><br> Curtidas Automáticas Brasileiras</p>",
                    Price = 34.90m,
                    Enabled = true            
                },
                new Product
                {
                    ScopedServiceType = scopedServiceTypes.ElementAt(0),
                    Description = 
                    "<ul style=\"list-style: none\"><li>- Entrega automática</li><li>- Sigilo Total</li><li>- Legal e livre de riscos</li><li>- Não precisamos da senha</li><li>- Plano Mensal</li></ul>",
                    Title = "<p><span style=\"color: #cc0033\">50</span><br> Curtidas Automáticas Brasileiras</p>",
                    Price = 34.90m,
                    Enabled = true            
                },


                //curtidas brasileiras
                new Product
                {
                    ScopedServiceType = scopedServiceTypes.ElementAt(1),
                    Description = 
                    "<ul style=\"list-style: none\"><li>- Entrega Rápida</li><li>- Sigilo Total</li><li>- Legal e livre de riscos</li><li>- Não precisamos da senha</li><li>- Escolha a quantidade</li></ul>",
                    Title = "<p>Curtidas Brasileiras</p>",
                    Price = 0.04m,
                    Enabled = true            
                },

                //seguidores brasileiros
                new Product
                {
                    ScopedServiceType = scopedServiceTypes.ElementAt(2),
                    Description = 
                    "<ul style=\"list-style: none\"><li>- Entrega Rápida</li><li>- Sigilo Total</li><li>- Legal e livre de riscos</li><li>- Não precisamos da senha</li><li>- Reais e Ativos</li></ul>",
                    Title = "<p>Seguidores Brasileiras</p>",
                    Price = 29.90m,
                    Enabled = true            
                },
                new Product
                {
                    ScopedServiceType = scopedServiceTypes.ElementAt(2),
                    Description = 
                    "<ul style=\"list-style: none\"><li>- Entrega Rápida</li><li>- Sigilo Total</li><li>- Legal e livre de riscos</li><li>- Não precisamos da senha</li><li>- Reais e Ativos</li></ul>",
                    Title = "<p>Seguidores Brasileiras</p>",
                    Price = 43.90m,
                    Enabled = true            
                },
                //plano seguidores brasileiros
                new Product
                {
                    ScopedServiceType = scopedServiceTypes.ElementAt(2),
                    Description = 
                    "<ul style=\"list-style: none\"><li>- Entrega Diária</li><li>- Sigilo Total</li><li>- Legal e livre de riscos</li><li>- Não precisamos da senha</li><li>- Plano Mensal</li></ul>",
                    Title = "<p>Plano Seguidores Brasileiras</p>",
                    Price = 84.90m,
                    Enabled = true            
                },
                new Product
                {
                    ScopedServiceType = scopedServiceTypes.ElementAt(2),
                    Description = 
                    "<ul style=\"list-style: none\"><li>- Entrega Diária</li><li>- Sigilo Total</li><li>- Legal e livre de riscos</li><li>- Não precisamos da senha</li><li>- Plano Mensal</li></ul>",
                    Title = "<p>Plano Seguidores Brasileiras</p>",
                    Price = 164.90m,
                    Enabled = true            
                }

                //curtidas post facebook
                //curtidas page facebook
            };

            context.Products.AddRange(products);
            context.SaveChanges();
        }
    }
}
