using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Roomager.Web.Models.PaymentsModels;

namespace Roomager.Web.Controllers
{
    public class PaymentsManagerController : Controller
    {
        public IActionResult Index()
        {
            List<PaymentsRecord> records = new List<PaymentsRecord>();
            records.Add(new PaymentsRecord());
            return View(records);
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
