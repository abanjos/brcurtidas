using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using BRCurtidas.Web.UI.Models;
using BRCurtidas.Web.UI.Services.ApiClient;
using System.Threading.Tasks;
using System.Linq;
using System;
using BRCurtidas.Web.UI.Routes;
using Microsoft.AspNetCore.Authorization;

namespace BRCurtidas.Web.UI.Controllers {
    public class TermsController : Controller {
        private readonly IApiClientService _apiClientService;

        public TermsController(IApiClientService apiClientService)
        {
            _apiClientService = apiClientService;
        }


        [HttpGet("/termos-de-uso", Name=RouteNames.TermsPage)]
        public async Task<IActionResult> Index()
        {
            var socialNetworks = await _apiClientService.GetSocialNetworksAsync();

            return View(new TermsViewModel { SocialNetworks = socialNetworks.ToArray() });
        } 
    }
}