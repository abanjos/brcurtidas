using AutoMapper;
using Bogus;
using BRCurtidas.Data;
using BRCurtidas.Web.Api.Models;
using Microsoft.EntityFrameworkCore;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Linq;
using Bogus.Extensions.Brazil;

namespace BRCurtidas.Web.Api.Tests
{
    public static class Mocks
    {
        private static Payment GenerateRandomPayment(Order order)
        {
            var paymentId = 0;

            var paymentGenerator =
                new Faker<Payment>()
                .StrictMode(true)
                .RuleFor(p => p.Id, _ => paymentId++)
                .RuleFor(p => p.OrderId, _ => order.Id)
                .RuleFor(p => p.Order, _ => order)
                .RuleFor(p => p.PaymentMethod, f => f.PickRandom<PaymentMethod>())
                .RuleFor(p => p.PaymentStatus, f => f.PickRandom<PaymentStatus>())
                .RuleFor(p => p.Reference, _ => Guid.NewGuid().ToString());

            return paymentGenerator.Generate();
        }

        private static Account GenerateRandomAccount()
        {
            var accountId = 0;

            var accountGenerator =
                new Faker<Account>()
                .StrictMode(true)
                .RuleFor(a => a.Id, _ => accountId++)
                .RuleFor(a => a.PasswordHash, f => BCrypt.Net.BCrypt.HashPassword(f.Internet.Password()))
                .RuleFor(a => a.UserName, f => f.Internet.UserName());

            return accountGenerator.Generate();
        }

        private static Address GenerateRandomAddress()
        {
            var addressId = 0;

            var addressGenerator =
                new Faker<Address>()
                .StrictMode(true)
                .RuleFor(a => a.Id, _ => addressId++)
                .RuleFor(a => a.Line1, f => f.Address.StreetAddress())
                .RuleFor(a => a.Line2, f => f.Address.BuildingNumber())
                .RuleFor(a => a.PostalCode, f => f.Random.Replace("#####-###"));

            return addressGenerator.Generate();
        }

        private static User GenerateRandomUser()
        {
            var userId = 0;

            var userGenerator =
                new Faker<User>()
                .StrictMode(true)
                .RuleFor(u => u.Id, _ => userId++)
                .RuleFor(u => u.Account, _ => GenerateRandomAccount())
                .RuleFor(u => u.Address, _ => GenerateRandomAddress())
                .RuleFor(u => u.Cpf, f => f.Person.Cpf())
                .RuleFor(u => u.Email, f => f.Internet.Email())
                .RuleFor(u => u.Name, f => f.Name.FullName())
                .RuleFor(u => u.PhoneNumber, f => f.Random.Replace("(##) ####-####"));

            return userGenerator.Generate();
        }

        private static IEnumerable<Order> GenerateRandomOrders(Product product, int quantity)
        {
            var orderId = 0;

            var orderGenerator =
                new Faker<Order>()
                .StrictMode(true)
                .RuleFor(o => o.Id, _ => orderId++)
                .RuleFor(o => o.Created, _ => DateTime.Now)
                .RuleFor(o => o.Payment, (_, o) => GenerateRandomPayment(o))
                .RuleFor(o => o.Price, (_, o) => product.Price * o.Quantity)
                .RuleFor(o => o.Quantity, f => f.Random.Int(1))
                .RuleFor(o => o.Product, _ => product)
                .RuleFor(o => o.SocialNetworkProfile, f => f.Internet.Avatar())
                .RuleFor(o => o.User, _ => GenerateRandomUser());

            for (int i = 0; i < quantity; i++)
                yield return orderGenerator.Generate();
        }

        private static IEnumerable<Product> GenerateRandomProducts(int quantity)
        {
            var productId = 0;

            var serviceGenerator =
                new Faker<Product>()
                .StrictMode(true)
                .RuleFor(s => s.Id, _ => productId++)
                .RuleFor(s => s.Orders, (f, s) => GenerateRandomOrders(s, f.Random.Int(1, 5)).ToList())
                .RuleFor(s => s.Price, f => f.Random.Decimal(0, 50))
                .RuleFor(s => s.Enabled, f => f.Random.Bool())
                .RuleFor(s => s.Description, _ => $"Produto #{productId}")
                .RuleFor(s => s.ScopedServiceType, _ => GenerateRandomScopedServiceType())
                .RuleFor(s => s.Title, _ => $"Produto #{productId}");

            for (int i = 0; i < quantity; i++)
                yield return serviceGenerator.Generate();
        }

        private static ScopedServiceType GenerateRandomScopedServiceType()
        {
            var scopedServiceTypeId = 0;

            var scopedServiceTypeGenerator =
                new Faker<ScopedServiceType>()
                .StrictMode(true)
                .RuleFor(s => s.Id, _ => scopedServiceTypeId++)
                .RuleFor(s => s.ServiceScope, f =>
                {
                    var id = f.Random.Int();
                    return new ServiceScope { Id = id, Name = $"Escopo de serviço #{id}" };
                })
                .RuleFor(s => s.ServiceType, f =>
                {
                    var id = f.Random.Int();
                    return new ServiceType { Id = id, Name = $"Tipo de serviço #{id}" };
                })
                .RuleFor(s => s.SocialNetwork, f =>
                {
                    var id = f.Random.Int();
                    return new SocialNetwork { Id = id, Name = $"Rede social #{id}" };
                })
                .RuleFor(s => s.Title, _ => $"Tipo de serviço #{scopedServiceTypeId}")
                .RuleFor(s => s.Description, _ => $"Tipo de serviço #{scopedServiceTypeId}")
                .RuleFor(s => s.PaymentType, f =>
                    {
                        var id = f.Random.Int();
                        return new PaymentType { Id = id, Name = $"Meio de pagamento #{id}" };
                    })
                .RuleFor(s => s.Slug, _ => $"/service{scopedServiceTypeId}");

            return scopedServiceTypeGenerator.Generate();
        }

        private static DataContext GenerateFakeDataContext()
        {
            var context = Substitute.For<DataContext>();
            var products = Substitute.For<DbSet<Product>, IQueryable<Product>>() as IQueryable<Product>;
            var data = GenerateRandomProducts(20).ToList().AsQueryable();

            products.Provider.Returns(data.Provider);
            products.Expression.Returns(data.Expression);
            products.ElementType.Returns(data.ElementType);
            products.GetEnumerator().Returns(data.GetEnumerator());

            context.Products.Returns(products);

            return context;
        }

        private static IMapper GenerateMapper()
        {
            AutoMapper.Mapper.Initialize(cfg => cfg.CreateMap<Product, ServiceResponseModel>());

            return AutoMapper.Mapper.Instance;
        }

        public static DataContext DataContext = GenerateFakeDataContext();

        public static IMapper Mapper = GenerateMapper();
    }
}