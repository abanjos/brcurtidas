using System;
using System.Linq;
using AutoMapper;
using BRCurtidas.Data;
using BRCurtidas.Web.Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace BRCurtidas.Web.Api.Controllers
{
    [Route("api/[controller]")]
    public class ProductsController : Controller
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public ProductsController(DataContext context, IMapper mapper)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet]
        public IActionResult GetProductsByScopedServiceTypeId(GetProductsByScopedServiceTypeIdRequestModel request)
        {
            var products = _context.Products
            .Where(p => p.ScopedServiceType.Id == request.scopedServiceTypeId)
            .Where(p => p.Enabled == true)
            .Select(p => new GetProductsByScopedServiceTypeIdResponseModel {
                Id = p.Id,
                Title = p.Title,
                Description = p.Description,
                Price = p.Price
            });

            return Ok(products);
        }
    }
}