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
        private IMapper mapper;

        public PaymentsManagerController(IPaymentsRecordService recordService, IMapper mapper)
        {
            this.recordService = recordService;            
            this.mapper = mapper;
        }

        [HttpGet]
        public IActionResult Index(int year)
        {
            int selectedYear = SelectRecordYear(year);
            
            PaymentsRecordViewModel viewModel = new PaymentsRecordViewModel
            {
                Records = mapper.Map<IEnumerable<PaymentsRecord>>(recordService.GetRecordsByYear(selectedYear))
            };

            TempData["selectedYear"] = selectedYear;

            return View(viewModel);
        }

        [HttpGet]
        public ViewResult CreateRecord()
        {
            PaymentsRecordViewModel viewModel = new PaymentsRecordViewModel(new PaymentsRecord());            

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult CreateRecord(PaymentsRecordViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                AssignId(viewModel);

                PaymentsRecordDTO recordDTO = mapper.Map<PaymentsRecordDTO>(viewModel.PaymentsRecord);
                int rowsffected = recordService.CreateRecord(recordDTO);

                return RedirectToAction("Index");
            }

            return View(new PaymentsRecord());            
        }

        [HttpGet]
        public ViewResult RecordDetails(int id)
        {
            PaymentsRecordDTO recordDto = recordService.GetRecord(id);
            PaymentsRecord record = mapper.Map<PaymentsRecord>(recordDto);

            PaymentsRecordViewModel viewModel = new PaymentsRecordViewModel(record);

            return View(viewModel);
        }

        [HttpGet]
        public ViewResult EditRecord(int id)
        {
            PaymentsRecordDTO recordDto = recordService.GetRecord(id);
            PaymentsRecord record = mapper.Map<PaymentsRecord>(recordDto);

            PaymentsRecordViewModel viewModel = new PaymentsRecordViewModel(record);

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult EditRecord(PaymentsRecordViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                PaymentsRecordDTO editedRecordDto = mapper.Map<PaymentsRecordDTO>(viewModel.PaymentsRecord);
                int rows = recordService.EditRecord(editedRecordDto.RecordId, editedRecordDto);

                return RedirectToAction("Index");
            }

            return View(new PaymentsRecordViewModel());            
        }

        [HttpGet]
        public ViewResult DeleteRecord(int id)
        {
            PaymentsRecordDTO recordDto = recordService.GetRecord(id);
            PaymentsRecord record = mapper.Map<PaymentsRecord>(recordDto);

            PaymentsRecordViewModel viewModel = new PaymentsRecordViewModel(record);

            return View(viewModel);
        }

        [HttpPost, ActionName("DeleteRecord")]
        public IActionResult ConfirmDeleteRecord(int id)
        {
            recordService.DeleteRecord(id);

            return RedirectToAction("Index");
        }

        void AssignId(PaymentsRecordViewModel model)
        {
            PaymentsRecordViewModel newModel = model;
            int recordsNr = 0;
            // gets current number of records and assigns it to a new record Id

            if (recordService.GetRecords().Count() >= 1)
            {
                recordsNr = recordService.GetRecords().Max(x => x.RecordId);
                model.PaymentsRecord.RecordId = recordsNr + 1;
            }
            else
            {
                model.PaymentsRecord.RecordId = 1;
            }
        }

        int SelectRecordYear(int year)
        {
            int selectedYear = 0;

            if (TempData["selectedYear"] != null && (int)TempData["selectedYear"] != year && year == 0)
            {
                selectedYear = (int)TempData["selectedYear"];
            }

            else if (TempData["selectedYear"] != null && (int)TempData["selectedYear"] != year)
            {
                selectedYear = year;
            }

            else if (year == 0)
            {
                selectedYear = DateTime.Now.Year;
            }

            return selectedYear;
        }
    }
}