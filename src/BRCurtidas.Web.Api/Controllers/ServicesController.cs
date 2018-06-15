using System;
using System.Linq;
using AutoMapper;
using BRCurtidas.Data;
using BRCurtidas.Web.Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
            var services = _context.Products.Include(p => p.ScopedServiceType)
            .OrderByDescending(s => s.Orders.Count())
            .AsEnumerable();

            if (request.SocialNetwork.HasValue)
                services = services.Where(s => s.ScopedServiceType.SocialNetwork.Id == request.SocialNetwork.Value);

            if (request.Scope.HasValue)
                services = services.Where(s => s.ScopedServiceType.ServiceScope.Id == request.Scope.Value);

            var result = services
                .Skip(request.Offset ?? 0)
                .Take(request.Limit ?? 10)
                .Select(s => _mapper.Map<ServiceResponseModel>(s));

            return Ok(result);
        }

        [HttpGet("types")]
        public IActionResult GetTypes(ServiceTypesRequestModel request)
        {
            var types = _context.ScopedServiceTypes
                .Where(s => s.SocialNetwork.Id == request.SocialNetwork)
                .Select(s => new ServiceTypeResponseModel
                {
                    Name = s.Title,
                    Slug = s.Slug
                });

            return Ok(types);
        }
    }
}