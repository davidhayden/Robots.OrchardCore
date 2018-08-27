using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Robots.OrchardCore.Services;

namespace Robots.OrchardCore.Controllers {
    public class HomeController : Controller {
        private readonly IRobotsService _robotsService;

        public HomeController(IRobotsService robotsService) {
            _robotsService = robotsService;
        }

        public async Task<ActionResult> Index() {
            return Content(await _robotsService.FetchTextAsync(), "text/plain", Encoding.UTF8);
        }
    }
}