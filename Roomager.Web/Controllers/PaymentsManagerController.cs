using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Roomager.Web.Controllers
{
    public class PaymentsManagerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public ViewResult CreateRecord()
        {
            return View();
        }

        public ViewResult RecordDetails()
        {
            return View();
        }

        public ViewResult EditRecord()
        {
            return View();
        }

        public ViewResult DeleteRecord()
        {
            return View();
        }
    }
}
