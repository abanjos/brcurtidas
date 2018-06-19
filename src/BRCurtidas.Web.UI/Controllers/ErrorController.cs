using Microsoft.AspNetCore.Mvc;

namespace BRCurtidas.Web.UI.Controllers
{   
    [Route("error")]
    public class ErrorController : Controller
    {
        [Route("500")]
        public IActionResult AppError()
        {            
            return View();
        }
    }
}