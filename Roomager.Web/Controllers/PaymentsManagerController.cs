using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Roomager.Data;
using Roomager.Services.PaymentsServices;
using Roomager.Web.Infrastructure;
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
        private PaymentCalculatorService calculatorService;
        private IMapper mapper;

        public PaymentsManagerController(IPaymentsRecordService recordService, IMapper mapper)
        {
            this.recordService = recordService;
            this.calculatorService = new PaymentCalculatorService();
            this.mapper = mapper;
        }

        [HttpGet]
        public IActionResult Index(int year)
        {
            int selectedYear = SelectRecordYear(year);

            PaymentsRecordViewModel viewModel = new PaymentsRecordViewModel
            {
                Records = mapper.Map<IEnumerable<PaymentsRecord>>(recordService.GetRecordsByYear(selectedYear)),
                PagingInfo = new PaymentsRecordPagingInfo
                {
                    PagingYears = recordService.GetRecordYears().ToList(),
                    CurrentPage = selectedYear
                }
            };

            TempData["selectedYear"] = selectedYear;

            return View(viewModel);
        }

        [HttpGet]
        public ViewResult CreateRecord()
        {
            PaymentsRecord record;

            if (TempData.ContainsKey("calculatedRecord") && TempData["calculatedRecord"] != null)
            {
                record = TempData.Get<PaymentsRecord>("calculatedRecord");
            }
            else
            {
                record = new PaymentsRecord();
            }

            return View(record);
        }

        [HttpPost]
        public IActionResult CreateRecord(PaymentsRecord record)
        {
            if (ModelState.IsValid)
            {
                PaymentsRecordDTO recordDTO = mapper.Map<PaymentsRecordDTO>(record);
                int rowsffected = recordService.CreateRecord(recordDTO);

                TempData["selectedYear"] = record.AddDate.Year;

                return RedirectToAction("Index");
            }

            return View(new PaymentsRecord());
        }
        
        [HttpPost]
        public IActionResult CalculatePayment(PaymentsRecord record)
        {
            var calculatedDTO = calculatorService.GetCalculatedRecord(mapper.Map<PaymentsRecordDTO>(record));

            var calculated = mapper.Map<PaymentsRecord>(calculatedDTO);

            TempData.Put<PaymentsRecord>("calculatedRecord", calculated);

            return RedirectToAction("CreateRecord", calculated);
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
        public IActionResult EditRecord(PaymentsRecord record)
        {
            if (ModelState.IsValid)
            {
                PaymentsRecordDTO editedRecordDto = mapper.Map<PaymentsRecordDTO>(record);
                int rowsAffected = recordService.EditRecord(editedRecordDto.RecordId, editedRecordDto);

                return RedirectToAction("Index");
            }

            return View();            
        }

        [HttpGet]
        public ViewResult DeleteRecord(int id)
        {
            PaymentsRecordDTO recordDto = recordService.GetRecord(id);
            PaymentsRecord record = mapper.Map<PaymentsRecord>(recordDto);

            return View(record);
        }

        [HttpPost, ActionName("DeleteRecord")]
        public IActionResult ConfirmDeleteRecord(int id)
        {
            int rowsAffected = recordService.DeleteRecord(id);

            return RedirectToAction("Index");
        }

        int SelectRecordYear(int year)
        {
            int selectedYear = 0;

            if (TempData["selectedYear"] != null && !recordService.GetRecordYears().Contains((int)TempData["selectedYear"]))
            {
                selectedYear = DateTime.Now.Year;
            }

            else if (TempData["selectedYear"] != null && (int)TempData["selectedYear"] != year && year == 0)
            {
                selectedYear = (int)TempData["selectedYear"];
            }

            else if (year == 0)
            {
                selectedYear = DateTime.Now.Year;
            }

            else
            {
                selectedYear = year;
            }

            return selectedYear;
        }
    }
}