using Microsoft.AspNetCore.Mvc;

namespace OnlineInventory.Web.Controllers
{
    public class BillController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
