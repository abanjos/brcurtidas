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

        private static IEnumerable<Order> GenerateRandomOrders(Service service, int quantity)
        {
            var orderId = 0;

            var orderGenerator =
                new Faker<Order>()
                .StrictMode(true)
                .RuleFor(o => o.Id, _ => orderId++)
                .RuleFor(o => o.Created, _ => DateTime.Now)
                .RuleFor(o => o.Payment, (_, o) => GenerateRandomPayment(o))
                .RuleFor(o => o.Price, (_, o) => service.Price * o.Quantity)
                .RuleFor(o => o.Quantity, f => f.Random.Int(1))
                .RuleFor(o => o.Service, _ => service)
                .RuleFor(o => o.SocialNetworkProfile, f => f.Internet.Avatar())
                .RuleFor(o => o.User, _ => GenerateRandomUser());

            for (int i = 0; i < quantity; i++)
                yield return orderGenerator.Generate();
        }

        private static IEnumerable<Service> GenerateRandomServices(int quantity)
        {
            var serviceId = 0;

            var serviceGenerator =
                new Faker<Service>()
                .StrictMode(true)
                .RuleFor(s => s.Id, _ => serviceId++)
                .RuleFor(s => s.Orders, (f, s) => GenerateRandomOrders(s, f.Random.Int(1, 5)).ToList())
                .RuleFor(s => s.PaymentType, f => f.PickRandom<PaymentType>())
                .RuleFor(s => s.Category, f => f.PickRandom<ServiceCategory>())
                .RuleFor(s => s.Price, f => f.Random.Decimal(0, 50))
                .RuleFor(s => s.Enabled, f => f.Random.Bool())
                .RuleFor(s => s.Description, _ => $"Serviço #{serviceId}")
                .RuleFor(s => s.SocialNetwork, f => f.PickRandom<SocialNetwork>())
                .RuleFor(s => s.Type, f => f.PickRandom<ServiceType>());

            for (int i = 0; i < quantity; i++)
                yield return serviceGenerator.Generate();
        }

        private static DataContext GenerateFakeDataContext()
        {
            var context = Substitute.For<DataContext>();
            var services = Substitute.For<DbSet<Service>, IQueryable<Service>>() as IQueryable<Service>;
            var data = GenerateRandomServices(20).ToList().AsQueryable();

            services.Provider.Returns(data.Provider);
            services.Expression.Returns(data.Expression);
            services.ElementType.Returns(data.ElementType);
            services.GetEnumerator().Returns(data.GetEnumerator());

            context.Services.Returns(services);

            return context;
        }

        private static IMapper GenerateMapper()
        {
            AutoMapper.Mapper.Initialize(cfg => cfg.CreateMap<Service, GetServicesResponseModel>());

            return AutoMapper.Mapper.Instance;
        }

        public static DataContext DataContext = GenerateFakeDataContext();

        public static IMapper Mapper = GenerateMapper();
    }
}
