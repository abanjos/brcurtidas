using AutoMapper;
using BRCurtidas.Common;
using BRCurtidas.Data;
using BRCurtidas.Web.Api.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace BRCurtidas.Web.Api.Controllers
{
    [Route("api/[controller]")]
    public class SocialNetworksController : Controller
    {
        private readonly DataContext _dataContext;

        private readonly IMapper _mapper;
        public SocialNetworksController(DataContext dataContext, IMapper mapper) {
            _dataContext = dataContext;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var socialNetworks = _dataContext.SocialNetworks.Select(s => _mapper.Map<SocialNetworkResponseModel>(s));

            return Ok(socialNetworks);
        }
    }
}
