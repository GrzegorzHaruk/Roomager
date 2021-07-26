using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Roomager.Data;
using Roomager.Services.PaymentsServices;
using Roomager.Web.Models.PaymentsModels;
using Roomager.Web.Viewmodels.PaymentsViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Roomager.Web.Controllers
{
    public class PaymentsManagerController : Controller
    {
        private IPaymentsRecordService recordService;
        private IPaymentsConfigService configService;
        private IMapper mapper;

        public PaymentsManagerController(IPaymentsRecordService recordService, IPaymentsConfigService configService, IMapper mapper)
        {
            this.recordService = recordService;
            this.configService = configService;
            this.mapper = mapper;
        }

        [HttpGet]
        public IActionResult Index(int pageSize = 12, int pageNr = 1)
        {
            IEnumerable<PaymentsRecordDTO> recordDTO = recordService.GetRecords(pageSize, pageNr);
            
            IEnumerable<PaymentsRecord> records = mapper.Map<IEnumerable<PaymentsRecord>>(recordDTO);

            return View(records);
        }

        [HttpGet]
        public ViewResult CreateRecord()
        {
            return View(new PaymentsRecord());
        }

        [HttpPost]
        public IActionResult CreateRecord(PaymentsRecord record)
        {
            if (ModelState.IsValid)
            {
                // gets current number of records and assigns it to a new record Id
                var recordsNr = recordService.GetRecords().Max(x => x.RecordId);
                record.RecordId = recordsNr + 1;

                PaymentsRecordDTO recordDTO = mapper.Map<PaymentsRecordDTO>(record);
                recordService.CreateRecord(recordDTO);

                return View("Index",
                    mapper.Map<IEnumerable<PaymentsRecord>>(recordService.GetRecords(12, 1)));
            }

            return View(new PaymentsRecord());
            
        }

        [HttpGet]
        public ViewResult RecordDetails(int id)
        {
            PaymentsRecordDTO recordDto = recordService.GetRecord(id);
            PaymentsRecord record = mapper.Map<PaymentsRecord>(recordDto);

            return View(record);
        }

        [HttpGet]
        public ViewResult EditRecord(int id)
        {
            PaymentsRecordDTO recordDto = recordService.GetRecord(id);
            PaymentsRecord record = mapper.Map<PaymentsRecord>(recordDto);
            return View(record);
        }

        [HttpPost]
        public ViewResult EditRecord(PaymentsRecord editedRecord)
        {
            if (ModelState.IsValid)
            {
                PaymentsRecordDTO editedRecordDto = mapper.Map<PaymentsRecordDTO>(editedRecord);

                recordService.EditRecord(editedRecordDto.RecordId, editedRecordDto);

                return View("Index",
                        mapper.Map<IEnumerable<PaymentsRecord>>(recordService.GetRecords(12, 1)));
            }

            return View(editedRecord);            
        }

        
        public ViewResult DeleteRecord(int id)
        {
            PaymentsRecordDTO recordDto = recordService.GetRecord(id);
            PaymentsRecord record = mapper.Map<PaymentsRecord>(recordDto);
            return View(record);
        }

        [HttpPost, ActionName("DeleteRecord")]
        public IActionResult ConfirmDeleteRecord(int id)
        {
            recordService.DeleteRecord(id);
            return View("Index",
                        mapper.Map<IEnumerable<PaymentsRecord>>(recordService.GetRecords(12, 1)));
        }
    }
}