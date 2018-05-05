using System;
using System.Linq;
using AutoMapper;
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
        public IActionResult Get(GetServicesRequestModel request)
        {
            var services = _context.Services.OrderByDescending(s => s.Orders.Count()).AsEnumerable();

            if (request.SocialNetwork.HasValue)
                services = services.Where(s => s.SocialNetwork == request.SocialNetwork);

            if (request.ServiceCategory.HasValue)
                services = services.Where(s => s.Category == request.ServiceCategory);

            var result = services
                .Skip(request.Offset ?? 0)
                .Take(request.Limit ?? 10)
                .Select(s => _mapper.Map<GetServicesResponseModel>(s));

            return Ok(result);
        }
    }
}