using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using BRCurtidas.Web.UI.Models;
using BRCurtidas.Web.UI.Services.ApiClient;
using System.Threading.Tasks;
using System.Linq;
using System;
using BRCurtidas.Web.UI.Routes;
using Microsoft.AspNetCore.Authorization;

namespace BRCurtidas.Web.UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly IApiClientService _apiClientService;

        public HomeController(IApiClientService apiClientService)
        {
            _apiClientService = apiClientService ?? throw new ArgumentNullException(nameof(apiClientService));
        }

        public async Task<IActionResult> Index()
        {
            var socialNetworks = await _apiClientService.GetSocialNetworksAsync();
            var model = new HomeViewModel { SocialNetworks = socialNetworks.ToArray() };

            return View(model);
        }

        [HttpGet("/comprar/{slug}", Name = RouteNames.GetProducts)]
        public async Task<IActionResult> GetProducts(string slug)
        {
            var socialNetworks = await _apiClientService.GetSocialNetworksAsync();
            var scopedServiceType = await _apiClientService.GetServiceWithProductsAsync(slug);
            var model = new GetProductsViewModel{ 
                ScopedServiceType = scopedServiceType,
                SocialNetworks = socialNetworks.ToArray()
                };

            return View(model);
        }
        
        [AllowAnonymous]
        public IActionResult Error()
        {
            return PartialView(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        [AllowAnonymous]
        [HttpGet("/Home/404")]
        public IActionResult Missing()
        {
            return PartialView();
        }
    }
}
