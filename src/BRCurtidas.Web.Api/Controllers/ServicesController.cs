using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using BRCurtidas.Common;
using BRCurtidas.Data;
using BRCurtidas.Web.Api.Models;
using Microsoft.AspNetCore.Mvc;

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
            IEnumerable<ServiceType> types;

            if (request.SocialNetwork.HasValue)
            {
                types = _context.Services
                    .Where(s => s.SocialNetwork == request.SocialNetwork)
                    .GroupBy(s => s.Type)
                    .Where(g => g.Count() > 0)
                    .Select(g => g.Key);
            }
            else
            {
                types = EnumUtility.GetValues<ServiceType>();
            }

            var result = types.Select(type => new ServiceTypeResponseModel
            {
                Id = (int)type,
                Name = type.ToString()
            });

            return Ok(result);
        }
    }
}