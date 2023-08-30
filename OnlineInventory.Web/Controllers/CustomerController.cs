using Microsoft.AspNetCore.Mvc;

namespace OnlineInventory.Web.Controllers
{
    public class CustomerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
