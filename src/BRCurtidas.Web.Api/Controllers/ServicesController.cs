using System;
using System.Linq;
using AutoMapper;
using BRCurtidas.Data;
using BRCurtidas.Web.Api.Models;
using Microsoft.AspNetCore.Mvc;
using BRCurtidas.Common;

namespace BRCurtidas.Web.Api.Controllers
{
    [Route("api/[controller]")]
    public class ServicesController : Controller
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public ServicesController(DataContext context, IMapper mapper)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet]
        public IActionResult Get(ServicesRequestModel request)
        {
            var services = _context.Services.OrderByDescending(s => s.Orders.Count()).AsEnumerable();

            if (request.SocialNetwork.HasValue)
                services = services.Where(s => s.SocialNetwork == request.SocialNetwork);

            if (request.Scope.HasValue)
                services = services.Where(s => s.Scope == request.Scope);

            var result = services
                .Skip(request.Offset ?? 0)
                .Take(request.Limit ?? 10)
                .Select(s => _mapper.Map<ServiceResponseModel>(s));

            return Ok(result);
        }

        [HttpGet("types")]
        public IActionResult GetTypes(ServiceTypesRequestModel request)
        {
            var types = _context.Services
                    .Where(s => s.SocialNetwork == request.SocialNetwork)
                    .GroupBy(s => new Tuple<ServiceType, ServiceScope>(s.Type, s.Scope))
                    .Where(g => g.Count() > 0)
                    .Select(g => g.Key);

            var result = types.Select(type => new ServiceTypeResponseModel
            {
                ServiceTypeId = (int)type.Item1,
                ServiceScopeId = (int)type.Item2,
                Name = type.Item1.GetName() + " " + type.Item2.GetPluralizedName()
            });

            return Ok(result);
        }
    }
}