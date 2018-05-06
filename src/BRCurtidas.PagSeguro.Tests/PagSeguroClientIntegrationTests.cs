using dotenv.net;
using FluentAssertions;
using System;
using Xunit;

namespace BRCurtidas.PagSeguro.Tests
{
    public class PagSeguroClientIntegrationTests
    {
        public PagSeguroClientIntegrationTests()
        {
            DotEnv.Config();
        }

        [Fact]
        public async void Should_Create_Checkout_Successfully()
        {
            var requestDate = DateTime.Today;
            var url = Environment.GetEnvironmentVariable("Url");
            var email = Environment.GetEnvironmentVariable("Email");
            var token = Environment.GetEnvironmentVariable("Token");

            var request = new CheckoutRequest
            {
                Currency = Currency.BRL,
                Receiver = new Receiver
                {
                    Email = email
                },
                RedirectUrl = "http://myurl.com",
                Reference = "REF123",
                Sender = new Sender
                {
                    Email = "sender@test.com.br",
                    Ip = "127.0.0.1",
                    Name = "BR Curtidas",
                    Phone = new Phone
                    {
                        AreaCode = "21",
                        Number = "980836100"
                    }
                }
            };

            request.Items.Add(new Item
            {
                Amount = 12.30m,
                Description = "Curtida Teste",
                Id = 1,
                Quantity = 2
            });

            request.Documents.Add(new Document
            {
                Type = DocumentType.Cpf,
                Value = "105.643.607-75"
            });

            var credentials = new PagSeguroCredentials(email, token);
            var client = new PagSeguroClient(url, credentials);
            var response = await client.CreateCheckoutAsync(request);

            response.Code.Should().NotBeNullOrWhiteSpace();
            response.Date.Should().BeOnOrAfter(requestDate);
        }
    }
}
