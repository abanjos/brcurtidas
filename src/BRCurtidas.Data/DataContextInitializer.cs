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
                new ServiceScope { Name = "Internacional"}, //0
                new ServiceScope { Name = "Nacional" } //1
            };

             context.ServiceScopes.AddRange(serviceScopes);

            var serviceTypes = new ServiceType[] {
                new ServiceType { Name = "Curtidas" }, //0
                new ServiceType { Name = "Visualizações" }, //1
                new ServiceType { Name = "Seguidores" }, //2
                new ServiceType { Name = "Inscrições" } //3
            };

            context.ServiceTypes.AddRange(serviceTypes);

            var socialNetworks = new SocialNetwork[] {
                new SocialNetwork { Name = "Instagram"}, //0
                new SocialNetwork { Name = "YouTube"}, //1
                new SocialNetwork { Name = "Facebook"}, //2

            };

            context.SocialNetworks.AddRange(socialNetworks);

            var paymentTypes = new PaymentType[] {
                new PaymentType { Name = "Package" }, //0
                new PaymentType { Name = "Recurrent" }, //1
                new PaymentType { Name = "Single" }, //2
            };

            context.PaymentTypes.AddRange(paymentTypes);

            var scopedServiceTypes = new ScopedServiceType[] {

                //instagram
                new ScopedServiceType {     //0            
                    ServiceScope = serviceScopes.ElementAt(1), //nacional
                    ServiceType = serviceTypes.ElementAt(0), //curtidas
                    SocialNetwork = socialNetworks.ElementAt(0), //instagram
                    PaymentType = paymentTypes.ElementAt(1),//plano
                    Title = "Curtidas Automáticas Brasileiras",
                    Slug = "curtidas-automaticas-brasileiras",
                    Image = "/images/instagram-logo.png",
                    Description = "Neste plano você ganhará curtidas BRASILEIRAS reais e ativas durante todo o mês em cada foto que postar após a assinatura de forma automática. É uma plano ideal para quem trabalha com visibilidade no Instagram como artistas, músicos, lojas físicas ou virtuais que estão constantemente atualizando seu perfil para melhorar o alcance de suas vendas ou trabalho. As curtidas entram de forma natural."
                },

                new ScopedServiceType {   //1            
                    ServiceScope = serviceScopes.ElementAt(1), //nacional
                    ServiceType = serviceTypes.ElementAt(0), //curtidas
                    SocialNetwork = socialNetworks.ElementAt(0), //instagram
                    PaymentType = paymentTypes.ElementAt(2),//avulso
                    Title = "Curtidas Brasileiras",
                    Slug = "curtidas-brasileiras",
                    Image = "/images/instagram-logo.png",
                    Description = "Por que comprar curtidas? Curtidas nas fotos ajuda na visibilidade dos seus posts e do seu Instagram. Os sistemas de buscas utilizam também como parâmetro a movimentação de curtidas, ou seja, aumentar seu número de curtidas irá melhorar seu ranking nesses sistemas de busca melhorando a movimentação do seu perfil. As curtidas tem a entrega rápida, mas você pode definir conosco a melhor forma que deseja recebê-las. Nesta opção você escolhe a quantidade que deseja, o pedido mínimo é 50 e o máximo 5 mil."
                },

                new ScopedServiceType {   //2              
                    ServiceScope = serviceScopes.ElementAt(1), //nacional
                    ServiceType = serviceTypes.ElementAt(2), //seguidores
                    SocialNetwork = socialNetworks.ElementAt(0), //instagram
                    PaymentType = paymentTypes.ElementAt(0),//avulso
                    Title = "Seguidores Brasileiros",
                    Slug = "seguidores-brasileiros",
                    Image = "/images/instagram-logo.png",
                    Description = "Ao clicar em “comprar”, você estará recebendo seguidores derivados de perfis Brasileiros REAIS e ATIVOS no Instagram sem precisar seguir ninguém de volta. As vantagens de serem BRASILEIROS está na credibilidade/confiabilidade sobre o retorno do alcance que seu perfil irá produzir tempo depois que o serviço for ativado. Este serviço é ideal para quem deseja expandir a carreira pela internet, ou para quem apenas deseja ter um perfil influente para conquistar ainda mais seguidores de forma natural."
                },

                new ScopedServiceType {    //3             
                    ServiceScope = serviceScopes.ElementAt(1), //nacional
                    ServiceType = serviceTypes.ElementAt(2), //seguidores
                    SocialNetwork = socialNetworks.ElementAt(0), //instagram
                    PaymentType = paymentTypes.ElementAt(1),//avulso
                    Title = "Plano Seguidores Brasileiros",
                    Slug = "plano-seguidores-brasileiros",
                    Image = "/images/instagram-logo.png",
                    Description = "Neste plano você ganhará SEGUIDORES BRASILEIROS reais e ativos durante todo o mês, recebendo aos poucos de forma natural. É um plano ideal para quem quer sempre estar recebendo novos seguidores em sua página, aumenta o alcance da sua rede no INSTAGRAM. Tenha muito mais visibilidade com este plano."                
                    },    

                    new ScopedServiceType {  //4              
                    ServiceScope = serviceScopes.ElementAt(0), //nacional
                    ServiceType = serviceTypes.ElementAt(1), //views
                    SocialNetwork = socialNetworks.ElementAt(0), //instagram
                    PaymentType = paymentTypes.ElementAt(0),//avulso
                    Title = "Visualizações",
                    Slug = "visualizacoes",
                    Image = "/images/instagram-logo.png",
                    Description = "Não deixe suas visualizações de fora da popularidade do perfil. Aumente-as conosco para acelerar o engajamento do perfil. Com mais visualizações o seu perfil será mais valorizado nas buscas dentro e fora do instagram, assim como as curtidas. Você pode customizar a entrega conosco.",
                    },

                    
                    //facebook
                    new ScopedServiceType {  //5           
                    ServiceScope = serviceScopes.ElementAt(1), //nacional
                    ServiceType = serviceTypes.ElementAt(0), //curtidas
                    SocialNetwork = socialNetworks.ElementAt(2), //facebook
                    PaymentType = paymentTypes.ElementAt(2),//avulso
                    Title = "Curtidas Brasileiras em Post",
                    Slug = "curtidas-brasileiras-facebook",
                    Image = "/images/facebook-logo.png",
                    Description = "Ao clicar em “comprar”, você estará recebendo curtidas de perfis Brasileiros, basta inserir o link do post/foto que você deseja receber as curtidas, não se esqueça de manter o seu perfil público para receber as curtidas.",
                    },

                    new ScopedServiceType {   //6            
                    ServiceScope = serviceScopes.ElementAt(1), //nacional
                    ServiceType = serviceTypes.ElementAt(0), //curtidas
                    SocialNetwork = socialNetworks.ElementAt(2), //facebook
                    PaymentType = paymentTypes.ElementAt(1),//avulso
                    Title = "Curtidas Automáticas Brasileiras em Post",
                    Slug = "curtidas-automaticas-brasileiras-facebook",
                    Image = "/images/facebook-logo.png",
                    Description = "Ao clicar em “comprar”, você estará recebendo curtidas automáticas. Basta inserir o link do perfil e receberá curtidas de forma gradativa por um periodo de 30 dias. Não se esqueça de manter o seu perfil público para receber as curtidas.",
                    },

                    new ScopedServiceType {  //   7       
                    ServiceScope = serviceScopes.ElementAt(0), //nacional
                    ServiceType = serviceTypes.ElementAt(0), //curtidas
                    SocialNetwork = socialNetworks.ElementAt(2), //facebook
                    PaymentType = paymentTypes.ElementAt(0),//avulso
                    Title = "Curtidas Página",
                    Slug = "curtidas-fanpage-facebook",
                    Image = "/images/facebook-logo.png",
                    Description = "Ao clicar em “comprar”, você estará recebendo curtidas na página, basta inserir o link do Perfil que você deseja e não se esqueça de manter o seu perfil público para receber as curtidas. Objetivo principal das curtidas em página é incrementar o marketing passivo da página auxiliando no seu crescimento natural. Páginas com mais curtidas tendem a influenciar outras pessoas a curtir a página!",
                    },

                    //youtube
                    new ScopedServiceType {   //8           
                    ServiceScope = serviceScopes.ElementAt(0), //nacional
                    ServiceType = serviceTypes.ElementAt(1), //views
                    SocialNetwork = socialNetworks.ElementAt(1), //facebook
                    PaymentType = paymentTypes.ElementAt(0),//avulso
                    Title = "Visualizações em Vídeo no Youtube",
                    Slug = "visualizacao-video-youtube",
                    Image = "/images/youtube-logo.png",
                    Description = "Ao clicar em “comprar”, você estará recebendo visualizações no link descrito no formulário abaixo. Não se esqueça de deixar o seu vídeo público para receber as visualizações.",
                    },

                    new ScopedServiceType {   //9            
                    ServiceScope = serviceScopes.ElementAt(0), 
                    ServiceType = serviceTypes.ElementAt(0), //views
                    SocialNetwork = socialNetworks.ElementAt(1), //facebook
                    PaymentType = paymentTypes.ElementAt(0),//avulso
                    Title = "Likes em Vídeo no Youtube",
                    Slug = "likes-video-youtube",
                    Image = "/images/youtube-logo.png",
                    Description = "Ao clicar em “comprar”, você estará recebendo likes no link descrito no formulário abaixo. Não se esqueça de deixar o seu vídeo público para receber os likes.",
                    },


            };


            context.ScopedServiceTypes.AddRange(scopedServiceTypes);

            var products = new Product[]
            {
                //curtidas automáticas instagram
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
                    Title = "<p><span style=\"color: #cc0033\">100</span><br> Curtidas Automáticas Brasileiras</p>",
                    Price = 64.90m,
                    Enabled = true            
                },
                new Product
                {
                    ScopedServiceType = scopedServiceTypes.ElementAt(0),
                    Description = 
                    "<ul style=\"list-style: none\"><li>- Entrega automática</li><li>- Sigilo Total</li><li>- Legal e livre de riscos</li><li>- Não precisamos da senha</li><li>- Plano Mensal</li></ul>",
                    Title = "<p><span style=\"color: #cc0033\">200</span><br> Curtidas Automáticas Brasileiras</p>",
                    Price = 99.90m,
                    Enabled = true            
                },
                new Product
                {
                    ScopedServiceType = scopedServiceTypes.ElementAt(0),
                    Description = 
                    "<ul style=\"list-style: none\"><li>- Entrega automática</li><li>- Sigilo Total</li><li>- Legal e livre de riscos</li><li>- Não precisamos da senha</li><li>- Plano Mensal</li></ul>",
                    Title = "<p><span style=\"color: #cc0033\">300</span><br> Curtidas Automáticas Brasileiras</p>",
                    Price = 149.90m,
                    Enabled = true            
                },
                new Product
                {
                    ScopedServiceType = scopedServiceTypes.ElementAt(0),
                    Description = 
                    "<ul style=\"list-style: none\"><li>- Entrega automática</li><li>- Sigilo Total</li><li>- Legal e livre de riscos</li><li>- Não precisamos da senha</li><li>- Plano Mensal</li></ul>",
                    Title = "<p><span style=\"color: #cc0033\">500</span><br> Curtidas Automáticas Brasileiras</p>",
                    Price = 249.90m,
                    Enabled = true            
                },
                new Product
                {
                    ScopedServiceType = scopedServiceTypes.ElementAt(0),
                    Description = 
                    "<ul style=\"list-style: none\"><li>- Entrega automática</li><li>- Sigilo Total</li><li>- Legal e livre de riscos</li><li>- Não precisamos da senha</li><li>- Plano Mensal</li></ul>",
                    Title = "<p><span style=\"color: #cc0033\">700</span><br> Curtidas Automáticas Brasileiras</p>",
                    Price = 349.90m,
                    Enabled = true            
                },
                new Product
                {
                    ScopedServiceType = scopedServiceTypes.ElementAt(0),
                    Description = 
                    "<ul style=\"list-style: none\"><li>- Entrega automática</li><li>- Sigilo Total</li><li>- Legal e livre de riscos</li><li>- Não precisamos da senha</li><li>- Plano Mensal</li></ul>",
                    Title = "<p><span style=\"color: #cc0033\">900</span><br> Curtidas Automáticas Brasileiras</p>",
                    Price = 449.90m,
                    Enabled = true            
                },
                new Product
                {
                    ScopedServiceType = scopedServiceTypes.ElementAt(0),
                    Description = 
                    "<ul style=\"list-style: none\"><li>- Entrega automática</li><li>- Sigilo Total</li><li>- Legal e livre de riscos</li><li>- Não precisamos da senha</li><li>- Plano Mensal</li></ul>",
                    Title = "<p><span style=\"color: #cc0033\">1000</span><br> Curtidas Automáticas Brasileiras</p>",
                    Price = 499.90m,
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
                    Title = "<p><span style=\"color: #cc0033\">500</span><br> Seguidores Brasileiros</p>",
                    Price = 29.90m,
                    Enabled = true            
                },
                new Product
                {
                    ScopedServiceType = scopedServiceTypes.ElementAt(2),
                    Description = 
                    "<ul style=\"list-style: none\"><li>- Entrega Rápida</li><li>- Sigilo Total</li><li>- Legal e livre de riscos</li><li>- Não precisamos da senha</li><li>- Reais e Ativos</li></ul>",
                    Title = "<p><span style=\"color: #cc0033\">1000</span><br> Seguidores Brasileiros</p>",
                    Price = 43.90m,
                    Enabled = true            
                },
                new Product
                {
                    ScopedServiceType = scopedServiceTypes.ElementAt(2),
                    Description = 
                    "<ul style=\"list-style: none\"><li>- Entrega Rápida</li><li>- Sigilo Total</li><li>- Legal e livre de riscos</li><li>- Não precisamos da senha</li><li>- Reais e Ativos</li></ul>",
                    Title = "<p><span style=\"color: #cc0033\">2500</span><br> Seguidores Brasileiros</p>",
                    Price = 84.90m,
                    Enabled = true            
                },
                new Product
                {
                    ScopedServiceType = scopedServiceTypes.ElementAt(2),
                    Description = 
                    "<ul style=\"list-style: none\"><li>- Entrega Rápida</li><li>- Sigilo Total</li><li>- Legal e livre de riscos</li><li>- Não precisamos da senha</li><li>- Reais e Ativos</li></ul>",
                    Title = "<p><span style=\"color: #cc0033\">5000</span><br> Seguidores Brasileiros</p>",
                    Price = 164.90m,
                    Enabled = true            
                },
                new Product
                {
                    ScopedServiceType = scopedServiceTypes.ElementAt(2),
                    Description = 
                    "<ul style=\"list-style: none\"><li>- Entrega Rápida</li><li>- Sigilo Total</li><li>- Legal e livre de riscos</li><li>- Não precisamos da senha</li><li>- Reais e Ativos</li></ul>",
                    Title = "<p><span style=\"color: #cc0033\">10000</span><br> Seguidores Brasileiros</p>",
                    Price = 319.90m,
                    Enabled = true            
                },
                new Product
                {
                    ScopedServiceType = scopedServiceTypes.ElementAt(2),
                    Description = 
                    "<ul style=\"list-style: none\"><li>- Entrega Rápida</li><li>- Sigilo Total</li><li>- Legal e livre de riscos</li><li>- Não precisamos da senha</li><li>- Reais e Ativos</li></ul>",
                    Title = "<p><span style=\"color: #cc0033\">15000</span><br> Seguidores Brasileiros</p>",
                    Price = 479.90m,
                    Enabled = true            
                },
                new Product
                {
                    ScopedServiceType = scopedServiceTypes.ElementAt(2),
                    Description = 
                    "<ul style=\"list-style: none\"><li>- Entrega Rápida</li><li>- Sigilo Total</li><li>- Legal e livre de riscos</li><li>- Não precisamos da senha</li><li>- Reais e Ativos</li></ul>",
                    Title = "<p><span style=\"color: #cc0033\">20000</span><br> Seguidores Brasileiros</p>",
                    Price = 319.90m,
                    Enabled = true            
                },
                new Product
                {
                    ScopedServiceType = scopedServiceTypes.ElementAt(2),
                    Description = 
                    "<ul style=\"list-style: none\"><li>- Entrega Rápida</li><li>- Sigilo Total</li><li>- Legal e livre de riscos</li><li>- Não precisamos da senha</li><li>- Reais e Ativos</li></ul>",
                    Title = "<p><span style=\"color: #cc0033\">30000</span><br> Seguidores Brasileiros</p>",
                    Price = 499.90m,
                    Enabled = true            
                },
                new Product
                {
                    ScopedServiceType = scopedServiceTypes.ElementAt(2),
                    Description = 
                    "<ul style=\"list-style: none\"><li>- Entrega Rápida</li><li>- Sigilo Total</li><li>- Legal e livre de riscos</li><li>- Não precisamos da senha</li><li>- Reais e Ativos</li></ul>",
                    Title = "<p><span style=\"color: #cc0033\">40000</span><br> Seguidores Brasileiros</p>",
                    Price = 639.90m,
                    Enabled = true            
                },
                new Product
                {
                    ScopedServiceType = scopedServiceTypes.ElementAt(2),
                    Description = 
                    "<ul style=\"list-style: none\"><li>- Entrega Rápida</li><li>- Sigilo Total</li><li>- Legal e livre de riscos</li><li>- Não precisamos da senha</li><li>- Reais e Ativos</li></ul>",
                    Title = "<p><span style=\"color: #cc0033\">1000</span><br> Seguidores Brasileiros</p>",
                    Price = 1519.90m,
                    Enabled = true            
                },


                //plano seguidores brasileiros
                new Product
                {
                    ScopedServiceType = scopedServiceTypes.ElementAt(3),
                    Description = 
                    "<ul style=\"list-style: none\"><li>- Entrega Diária</li><li>- Sigilo Total</li><li>- Legal e livre de riscos</li><li>- Não precisamos da senha</li><li>- Plano Mensal</li></ul>",
                    Title = "<p><span style=\"color: #cc0033\">3000</span><br> Plano Seguidores Brasileiros</p>",
                    Price = 94.90m,
                    Enabled = true            
                },
                new Product
                {
                    ScopedServiceType = scopedServiceTypes.ElementAt(3),
                    Description = 
                    "<ul style=\"list-style: none\"><li>- Entrega Diária</li><li>- Sigilo Total</li><li>- Legal e livre de riscos</li><li>- Não precisamos da senha</li><li>- Plano Mensal</li></ul>",
                    Title = "<p><span style=\"color: #cc0033\">5000</span><br> Plano Seguidores Brasileiros</p>",
                    Price = 164.90m,
                    Enabled = true            
                },
                 new Product
                {
                    ScopedServiceType = scopedServiceTypes.ElementAt(3),
                    Description = 
                    "<ul style=\"list-style: none\"><li>- Entrega Diária</li><li>- Sigilo Total</li><li>- Legal e livre de riscos</li><li>- Não precisamos da senha</li><li>- Plano Mensal</li></ul>",
                    Title = "<p><span style=\"color: #cc0033\">10000</span><br> Plano Seguidores Brasileiros</p>",
                    Price = 319.90m,
                    Enabled = true            
                },
                 new Product
                {
                    ScopedServiceType = scopedServiceTypes.ElementAt(3),
                    Description = 
                    "<ul style=\"list-style: none\"><li>- Entrega Diária</li><li>- Sigilo Total</li><li>- Legal e livre de riscos</li><li>- Não precisamos da senha</li><li>- Plano Mensal</li></ul>",
                    Title = "<p><span style=\"color: #cc0033\">20000</span><br> Plano Seguidores Brasileiros</p>",
                    Price = 619.90m,
                    Enabled = true            
                },
                 new Product
                {
                    ScopedServiceType = scopedServiceTypes.ElementAt(3),
                    Description = 
                    "<ul style=\"list-style: none\"><li>- Entrega Diária</li><li>- Sigilo Total</li><li>- Legal e livre de riscos</li><li>- Não precisamos da senha</li><li>- Plano Mensal</li></ul>",
                    Title = "<p><span style=\"color: #cc0033\">30000</span><br> Plano Seguidores Brasileiros</p>",
                    Price = 919.90m,
                    Enabled = true            
                },
                
                //visualizações instagram
                 new Product
                {
                    ScopedServiceType = scopedServiceTypes.ElementAt(4),
                    Description = 
                    "<ul style=\"list-style: none\"><li>- Entrega Rápida</li><li>- Sigilo Total</li><li>- Legal e livre de riscos</li><li>- Não precisamos da senha</li><li>- Reais</li></ul>",
                    Title = "<p><span style=\"color: #cc0033\">100</span><br> Visualizações Instagram</p>",
                    Price = 5.90m,
                    Enabled = true            
                },
                new Product
                {
                    ScopedServiceType = scopedServiceTypes.ElementAt(4),
                    Description = 
                    "<ul style=\"list-style: none\"><li>- Entrega Rápida</li><li>- Sigilo Total</li><li>- Legal e livre de riscos</li><li>- Não precisamos da senha</li><li>- Reais</li></ul>",
                    Title = "<p><span style=\"color: #cc0033\">500</span><br> Visualizações Instagram</p>",
                    Price = 27.90m,
                    Enabled = true            
                },
                new Product
                {
                    ScopedServiceType = scopedServiceTypes.ElementAt(4),
                    Description = 
                    "<ul style=\"list-style: none\"><li>- Entrega Rápida</li><li>- Sigilo Total</li><li>- Legal e livre de riscos</li><li>- Não precisamos da senha</li><li>- Reais</li></ul>",
                    Title = "<p><span style=\"color: #cc0033\">1000</span><br> Visualizações Instagram</p>",
                    Price = 49.90m,
                    Enabled = true            
                },
                new Product
                {
                    ScopedServiceType = scopedServiceTypes.ElementAt(4),
                    Description = 
                    "<ul style=\"list-style: none\"><li>- Entrega Rápida</li><li>- Sigilo Total</li><li>- Legal e livre de riscos</li><li>- Não precisamos da senha</li><li>- Reais</li></ul>",
                    Title = "<p><span style=\"color: #cc0033\">2500</span><br> Visualizações Instagram</p>",
                    Price = 99.90m,
                    Enabled = true            
                },
                new Product
                {
                    ScopedServiceType = scopedServiceTypes.ElementAt(4),
                    Description = 
                    "<ul style=\"list-style: none\"><li>- Entrega Rápida</li><li>- Sigilo Total</li><li>- Legal e livre de riscos</li><li>- Não precisamos da senha</li><li>- Reais</li></ul>",
                    Title = "<p><span style=\"color: #cc0033\">5000</span><br> Visualizações Instagram</p>",
                    Price = 189.90m,
                    Enabled = true            
                },

                //curtidas post facebook
                new Product
                {
                    ScopedServiceType = scopedServiceTypes.ElementAt(5),
                    Description = 
                    "<ul style=\"list-style: none\"><li>- Entrega Rápida</li><li>- Sigilo Total</li><li>- Legal e livre de riscos</li><li>- Não precisamos da senha</li><li>- Reais</li></ul>",
                    Title = "<p>Curtidas Brasileiras em Post Facebook</p>",
                    Price = 0.04m,
                    Enabled = true            
                },

                //curtidas automáticas post facebook
                new Product
                {
                    ScopedServiceType = scopedServiceTypes.ElementAt(6),
                    Description = 
                    "<ul style=\"list-style: none\"><li>- Entrega em post futuro</li><li>- Sigilo Total</li><li>- Legal e livre de riscos</li><li>- Não precisamos da senha</li><li>- Plano Mensal</li></ul>",
                    Title = "<p><span style=\"color: #cc0033\">100</span><br> Curtidas Automáticas Brasileiras em Post Facebook</p>",
                    Price = 88.90m,
                    Enabled = true            
                },
                new Product
                {
                    ScopedServiceType = scopedServiceTypes.ElementAt(6),
                    Description = 
                    "<ul style=\"list-style: none\"><li>- Entrega em post futuro</li><li>- Sigilo Total</li><li>- Legal e livre de riscos</li><li>- Não precisamos da senha</li><li>- Plano Mensal</li></ul>",
                    Title = "<p><span style=\"color: #cc0033\">250</span><br> Curtidas Automáticas Brasileiras em Post Facebook</p>",
                    Price = 179.90m,
                    Enabled = true            
                },
                new Product
                {
                    ScopedServiceType = scopedServiceTypes.ElementAt(6),
                    Description = 
                    "<ul style=\"list-style: none\"><li>- Entrega em post futuro</li><li>- Sigilo Total</li><li>- Legal e livre de riscos</li><li>- Não precisamos da senha</li><li>- Plano Mensal</li></ul>",
                    Title = "<p><span style=\"color: #cc0033\">500</span><br> Curtidas Automáticas Brasileiras em Post Facebook</p>",
                    Price = 319.90m,
                    Enabled = true            
                },
                new Product
                {
                    ScopedServiceType = scopedServiceTypes.ElementAt(6),
                    Description = 
                    "<ul style=\"list-style: none\"><li>- Entrega em post futuro</li><li>- Sigilo Total</li><li>- Legal e livre de riscos</li><li>- Não precisamos da senha</li><li>- Plano Mensal</li></ul>",
                    Title = "<p><span style=\"color: #cc0033\">1000</span><br> Curtidas Automáticas Brasileiras em Post Facebook</p>",
                    Price = 559.90m,
                    Enabled = true            
                },
                 new Product
                {
                    ScopedServiceType = scopedServiceTypes.ElementAt(6),
                    Description = 
                    "<ul style=\"list-style: none\"><li>- Entrega em post futuro</li><li>- Sigilo Total</li><li>- Legal e livre de riscos</li><li>- Não precisamos da senha</li><li>- Plano Mensal</li></ul>",
                    Title = "<p><span style=\"color: #cc0033\">2000</span><br> Curtidas Automáticas Brasileiras em Post Facebook</p>",
                    Price = 999.90m,
                    Enabled = true            
                },

                 new Product
                {
                    ScopedServiceType = scopedServiceTypes.ElementAt(7),
                    Description = 
                    "<ul style=\"list-style: none\"><li>- Entrega rápida</li><li>- Sigilo Total</li><li>- Legal e livre de riscos</li><li>- Não precisamos da senha</li></ul>",
                    Title = "<p><span style=\"color: #cc0033\">500</span><br> Curtidas em Fanpage Facebook</p>",
                    Price = 31.90m,
                    Enabled = true            
                },
                 new Product
                {
                    ScopedServiceType = scopedServiceTypes.ElementAt(7),
                    Description = 
                    "<ul style=\"list-style: none\"><li>- Entrega rápida</li><li>- Sigilo Total</li><li>- Legal e livre de riscos</li><li>- Não precisamos da senha</li></ul>",
                    Title = "<p><span style=\"color: #cc0033\">1000</span><br> Curtidas em Fanpage Facebook</p>",
                    Price = 59.90m,
                    Enabled = true            
                },
                 new Product
                {
                    ScopedServiceType = scopedServiceTypes.ElementAt(7),
                    Description = 
                    "<ul style=\"list-style: none\"><li>- Entrega rápida</li><li>- Sigilo Total</li><li>- Legal e livre de riscos</li><li>- Não precisamos da senha</li></ul>",
                    Title = "<p><span style=\"color: #cc0033\">2500</span><br> Curtidas em Fanpage Facebook</p>",
                    Price = 119.90m,
                    Enabled = true            
                },
                 new Product
                {
                    ScopedServiceType = scopedServiceTypes.ElementAt(7),
                    Description = 
                    "<ul style=\"list-style: none\"><li>- Entrega rápida</li><li>- Sigilo Total</li><li>- Legal e livre de riscos</li><li>- Não precisamos da senha</li></ul>",
                    Title = "<p><span style=\"color: #cc0033\">5000</span><br> Curtidas em Fanpage Facebook</p>",
                    Price = 219.90m,
                    Enabled = true            
                },
                 new Product
                {
                    ScopedServiceType = scopedServiceTypes.ElementAt(7),
                    Description = 
                    "<ul style=\"list-style: none\"><li>- Entrega rápida</li><li>- Sigilo Total</li><li>- Legal e livre de riscos</li><li>- Não precisamos da senha</li></ul>",
                    Title = "<p><span style=\"color: #cc0033\">10000</span><br> Curtidas em Fanpage Facebook</p>",
                    Price = 299.90m,
                    Enabled = true            
                },
                 new Product
                {
                    ScopedServiceType = scopedServiceTypes.ElementAt(7),
                    Description = 
                    "<ul style=\"list-style: none\"><li>- Entrega rápida</li><li>- Sigilo Total</li><li>- Legal e livre de riscos</li><li>- Não precisamos da senha</li></ul>",
                    Title = "<p><span style=\"color: #cc0033\">20000</span><br> Curtidas em Fanpage Facebook</p>",
                    Price = 399.90m,
                    Enabled = true            
                },
                 new Product
                {
                    ScopedServiceType = scopedServiceTypes.ElementAt(7),
                    Description = 
                    "<ul style=\"list-style: none\"><li>- Entrega rápida</li><li>- Sigilo Total</li><li>- Legal e livre de riscos</li><li>- Não precisamos da senha</li></ul>",
                    Title = "<p><span style=\"color: #cc0033\">40000</span><br> Curtidas em Fanpage Facebook</p>",
                    Price = 699.90m,
                    Enabled = true            
                },
                 new Product
                {
                    ScopedServiceType = scopedServiceTypes.ElementAt(7),
                    Description = 
                    "<ul style=\"list-style: none\"><li>- Entrega rápida</li><li>- Sigilo Total</li><li>- Legal e livre de riscos</li><li>- Não precisamos da senha</li></ul>",
                    Title = "<p><span style=\"color: #cc0033\">50000</span><br> Curtidas em Fanpage Facebook</p>",
                    Price = 999.90m,
                    Enabled = true            
                },

                //youtube
                 new Product
                {
                    ScopedServiceType = scopedServiceTypes.ElementAt(8),
                    Description = 
                    "<ul style=\"list-style: none\"><li>- Entrega rápida</li><li>- Sigilo Total</li><li>- Legal e livre de riscos</li><li>- Não precisamos da senha</li></ul>",
                    Title = "<p><span style=\"color: #cc0033\">2500</span><br> Visualizações em Vídeo YouTube</p>",
                    Price = 28.90m,
                    Enabled = true            
                },
                 new Product
                {
                    ScopedServiceType = scopedServiceTypes.ElementAt(8),
                    Description = 
                    "<ul style=\"list-style: none\"><li>- Entrega rápida</li><li>- Sigilo Total</li><li>- Legal e livre de riscos</li><li>- Não precisamos da senha</li></ul>",
                    Title = "<p><span style=\"color: #cc0033\">5900</span><br> Visualizações em Vídeo YouTube</p>",
                    Price = 48.90m,
                    Enabled = true            
                },
                 new Product
                {
                    ScopedServiceType = scopedServiceTypes.ElementAt(8),
                    Description = 
                    "<ul style=\"list-style: none\"><li>- Entrega rápida</li><li>- Sigilo Total</li><li>- Legal e livre de riscos</li><li>- Não precisamos da senha</li></ul>",
                    Title = "<p><span style=\"color: #cc0033\">10000</span><br> Visualizações em Vídeo YouTube</p>",
                    Price = 88.90m,
                    Enabled = true            
                },
                 new Product
                {
                    ScopedServiceType = scopedServiceTypes.ElementAt(8),
                    Description = 
                    "<ul style=\"list-style: none\"><li>- Entrega rápida</li><li>- Sigilo Total</li><li>- Legal e livre de riscos</li><li>- Não precisamos da senha</li></ul>",
                    Title = "<p><span style=\"color: #cc0033\">25000</span><br> Visualizações em Vídeo YouTube</p>",
                    Price = 198.90m,
                    Enabled = true            
                },
                 new Product
                {
                    ScopedServiceType = scopedServiceTypes.ElementAt(8),
                    Description = 
                    "<ul style=\"list-style: none\"><li>- Entrega rápida</li><li>- Sigilo Total</li><li>- Legal e livre de riscos</li><li>- Não precisamos da senha</li></ul>",
                    Title = "<p><span style=\"color: #cc0033\">50000</span><br> Visualizações em Vídeo YouTube</p>",
                    Price = 388.90m,
                    Enabled = true            
                },
                 new Product
                {
                    ScopedServiceType = scopedServiceTypes.ElementAt(8),
                    Description = 
                    "<ul style=\"list-style: none\"><li>- Entrega rápida</li><li>- Sigilo Total</li><li>- Legal e livre de riscos</li><li>- Não precisamos da senha</li></ul>",
                    Title = "<p><span style=\"color: #cc0033\">100000</span><br> Visualizações em Vídeo YouTube</p>",
                    Price = 783.90m,
                    Enabled = true            
                },

                 new Product
                {
                    ScopedServiceType = scopedServiceTypes.ElementAt(9),
                    Description = 
                    "<ul style=\"list-style: none\"><li>- Entrega rápida</li><li>- Sigilo Total</li><li>- Legal e livre de riscos</li><li>- Não precisamos da senha</li></ul>",
                    Title = "<p><span style=\"color: #cc0033\">100</span><br> Likes em Video YouTube</p>",
                    Price = 23.90m,
                    Enabled = true            
                },
                 new Product
                {
                    ScopedServiceType = scopedServiceTypes.ElementAt(9),
                    Description = 
                    "<ul style=\"list-style: none\"><li>- Entrega rápida</li><li>- Sigilo Total</li><li>- Legal e livre de riscos</li><li>- Não precisamos da senha</li></ul>",
                    Title = "<p><span style=\"color: #cc0033\">200</span><br> Likes em Video YouTube</p>",
                    Price = 48.90m,
                    Enabled = true            
                },
                 new Product
                {
                    ScopedServiceType = scopedServiceTypes.ElementAt(9),
                    Description = 
                    "<ul style=\"list-style: none\"><li>- Entrega rápida</li><li>- Sigilo Total</li><li>- Legal e livre de riscos</li><li>- Não precisamos da senha</li></ul>",
                    Title = "<p><span style=\"color: #cc0033\">400</span><br> Likes em Video YouTube</p>",
                    Price = 98.90m,
                    Enabled = true            
                },
                new Product
                {
                    ScopedServiceType = scopedServiceTypes.ElementAt(9),
                    Description = 
                    "<ul style=\"list-style: none\"><li>- Entrega rápida</li><li>- Sigilo Total</li><li>- Legal e livre de riscos</li><li>- Não precisamos da senha</li></ul>",
                    Title = "<p><span style=\"color: #cc0033\">800</span><br> Likes em Video YouTube</p>",
                    Price = 188.90m,
                    Enabled = true            
                }

            };

            context.Products.AddRange(products);
            context.SaveChanges();
        }
    }
}
