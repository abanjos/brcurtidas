﻿using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using BRCurtidas.Web.UI.Models;
using BRCurtidas.Web.UI.Services.ApiClient;
using System.Threading.Tasks;
using System.Linq;
using System;

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

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
