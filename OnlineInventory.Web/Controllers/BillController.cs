using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol;
using OnlineInventory.Models;
using OnlineInventory.Repository.BillTypeService;
using OnlineInventory.ViewModels.Bill;

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
