﻿using System.Linq;

namespace BRCurtidas.Data
{
    public static class DataContextInitializer
    {
        public static void Initialize(DataContext context)
        {
            context.Database.EnsureCreated();

            if (context.Services.Any())
                return;

            var services = new Service[]
            {
                new Service
                {
                    Scope = ServiceScope.International,
                    Description = "500 Seguidores",
                    SocialNetwork = SocialNetwork.Instagram,
                    PaymentType = PaymentType.Single,
                    Type = ServiceType.Followers,
                    Price = 13.9m
                },
                new Service
                {
                    Scope = ServiceScope.International,
                    Description = "1.000 Seguidores",
                    SocialNetwork = SocialNetwork.Instagram,
                    PaymentType = PaymentType.Single,
                    Type = ServiceType.Followers,
                    Price = 24.9m
                },
                new Service
                {
                    Scope = ServiceScope.International,
                    Description = "2.500 Seguidores",
                    SocialNetwork = SocialNetwork.Instagram,
                    PaymentType = PaymentType.Single,
                    Type = ServiceType.Followers,
                    Price = 44.9m
                }
            };

            context.Services.AddRange(services);
            context.SaveChanges();
        }
    }
}
