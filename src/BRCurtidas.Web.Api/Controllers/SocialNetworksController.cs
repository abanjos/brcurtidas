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
        [HttpGet]
        public IActionResult Get()
        {
            var socialNetworks = EnumUtility.GetValues<SocialNetwork>();

            var response = socialNetworks.Select(socialNetwork => new SocialNetworkResponseModel
            {
                Id = (int)socialNetwork,
                Name = socialNetwork.ToString()
            });

            return Ok(response);
        }
    }
}
