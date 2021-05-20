using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Roomager.Web.Models.PaymentsModels;
using Roomager.Services.PaymentsServices;
using Roomager.Data;
using AutoMapper;

namespace Roomager.Web.Controllers
{
    public class PaymentsManagerController : Controller
    {
        private IPaymentsRecordService recordService;
        private IMapper mapper;

        public PaymentsManagerController(IPaymentsRecordService recordService, IMapper mapper)
        {
            this.recordService = recordService;
            this.mapper = mapper;
        }

        public IActionResult Index(int pageSize = 12, int pageNr = 1)
        {            
            IEnumerable<PaymentsRecordDTO> recordDTO = recordService.GetRecords(pageSize, pageNr);
            
            IEnumerable<PaymentsRecord> records = mapper.Map<IEnumerable<PaymentsRecord>>(recordDTO);

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
