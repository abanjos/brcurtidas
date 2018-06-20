using System;
using System.Linq;
using AutoMapper;
using BRCurtidas.Data;
using Microsoft.AspNetCore.Mvc;

namespace BRCurtidas.Web.Api.Controllers
{
    [Route("api/[controller]")]
    public class ScopedServiceTypesController : Controller
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public ScopedServiceTypesController(DataContext context, IMapper mapper)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet]
        public IActionResult GetScopedServiceType(ScopedServiceTypesRequestModel request)
        {
            var scopedServiceType = _context.ScopedServiceTypes
                .Where(s => s.Slug == request.slug)
                .Select(s => new ScopedServiceTypeResponseModel {
                    Id = s.Id,
                    Title = s.Title,
                    Slug = s.Slug,
                    Description = s.Description,
                    Image = s.Image,
                    PaymentType = s.PaymentType.Id

                }).Single();

            return Ok(scopedServiceType);
        }
    }
}