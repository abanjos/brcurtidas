using System.Collections.Generic;
using Xunit;
using System.Linq;
using BRCurtidas.Web.Api.Controllers;
using BRCurtidas.Web.Api.Models;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;

namespace BRCurtidas.Web.Api.Tests.Controllers
{
    public class ServicesControllerUnitTests
    {
        [Fact]
        public void Call_Get_Without_Filter_Should_Return_10_Most_Selled_Services()
        {
            var controller = new ServicesController(Mocks.DataContext, Mocks.Mapper);

            var result = controller.Get(new ServicesRequestModel());

            result.Should().BeOfType<OkObjectResult>();

            var okResult = result as OkObjectResult;

            okResult.Value.Should().BeAssignableTo<IEnumerable<ServiceResponseModel>>();

            var expected =
                Mocks.DataContext.Services
                .OrderByDescending(s => s.Orders.Count())
                .Take(10)
                .Select(s => Mocks.Mapper.Map<ServiceResponseModel>(s));

            var actual = okResult.Value as IEnumerable<ServiceResponseModel>;

            actual.Should().BeEquivalentTo(expected);
        }
    }
}
