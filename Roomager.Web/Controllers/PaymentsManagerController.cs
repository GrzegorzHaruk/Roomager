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
            PaymentsRecordViewModel viewModel = new PaymentsRecordViewModel(
                new PaymentsRecord(), 
                new PaymentsConfig {
                    EnergyPaymentConfig = new EnergyPaymentsConfig(),
                    WaterPaymentsConfig = new WaterPaymentsConfig(),
                    GasPaymentsConfig = new GasPaymentsConfig()
                });
            
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult CreateRecord(PaymentsRecordViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                // gets current number of records and assigns it to a new record Id
                var recordsNr = recordService.GetRecords().Max(x => x.RecordId);                
                viewModel.PaymentsRecord.RecordId = recordsNr + 1;
                viewModel.PaymentsConfig.Id = recordsNr + 1;

                PaymentsRecordDTO recordDTO = mapper.Map<PaymentsRecordDTO>(viewModel.PaymentsRecord);
                PaymentsConfigDTO configDTO = mapper.Map<PaymentsConfigDTO>(viewModel.PaymentsConfig);
                int rowsffected = recordService.CreateRecord(recordDTO);
                int rowsffected2 = configService.CreateConfig(configDTO);

                return RedirectToAction("Index");
            }

            return View(new PaymentsRecord());            
        }

        [HttpGet]
        public ViewResult RecordDetails(int id)
        {
            PaymentsRecordDTO recordDto = recordService.GetRecord(id);
            PaymentsRecord record = mapper.Map<PaymentsRecord>(recordDto);

            PaymentsConfigDTO configDTO = configService.GetConfig(id);
            PaymentsConfig config = mapper.Map<PaymentsConfig>(configDTO);

            PaymentsRecordViewModel viewModel = new PaymentsRecordViewModel(record, config);

            return View(viewModel);
        }

        [HttpGet]
        public ViewResult EditRecord(int id)
        {
            PaymentsRecordDTO recordDto = recordService.GetRecord(id);
            PaymentsRecord record = mapper.Map<PaymentsRecord>(recordDto);

            PaymentsConfigDTO configDTO = configService.GetConfig(id);
            PaymentsConfig config = mapper.Map<PaymentsConfig>(configDTO);

            PaymentsRecordViewModel viewModel = new PaymentsRecordViewModel(record, config);

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult EditRecord(PaymentsRecordViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                PaymentsRecordDTO editedRecordDto = mapper.Map<PaymentsRecordDTO>(viewModel.PaymentsRecord);
                PaymentsConfigDTO configDTO = mapper.Map<PaymentsConfigDTO>(viewModel.PaymentsConfig);

                recordService.EditRecord(editedRecordDto.RecordId, editedRecordDto);
                configService.EditConfig(configDTO);

                return RedirectToAction("Index");
            }

            return View(new PaymentsRecordViewModel());            
        }

        [HttpGet]
        public ViewResult DeleteRecord(int id)
        {
            PaymentsRecordDTO recordDto = recordService.GetRecord(id);
            PaymentsRecord record = mapper.Map<PaymentsRecord>(recordDto);

            PaymentsConfigDTO configDTO = configService.GetConfig(id);
            PaymentsConfig config = mapper.Map<PaymentsConfig>(configDTO);

            PaymentsRecordViewModel viewModel = new PaymentsRecordViewModel(record, config);

            return View(viewModel);
        }

        [HttpPost, ActionName("DeleteRecord")]
        public IActionResult ConfirmDeleteRecord(int id)
        {
            recordService.DeleteRecord(id);
            configService.DeleteConfig(id);

            return RedirectToAction("Index");
        }
    }
}