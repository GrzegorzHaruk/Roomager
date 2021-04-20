using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Roomager.Web.Controllers
{
    public class ManagerHomeController : Controller
    {
        public IActionResult ManagerHomePage()
        {
            return View();
        }
    }
}
