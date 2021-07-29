using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Roomager.Data;
using Roomager.Services.PaymentsServices;
using Roomager.Web.Models.PaymentsModels;
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

                return RedirectToAction("Index");
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
        public IActionResult EditRecord(PaymentsRecord editedRecord)
        {
            if (ModelState.IsValid)
            {
                PaymentsRecordDTO editedRecordDto = mapper.Map<PaymentsRecordDTO>(editedRecord);

                recordService.EditRecord(editedRecordDto.RecordId, editedRecordDto);

                return RedirectToAction("Index");
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

            return RedirectToAction("Index");
        }

        private int SaveFakeConfig()
        {
            PaymentsConfigDTO configDTO = new PaymentsConfigDTO
            {
                Id = 6,
                EnergyPaymentConfig = new EnergyPaymentsConfigDTO
                {
                    ConfigId = 6
                },
                WaterPaymentConfig = new WaterPaymentsConfigDTO
                {
                    ConfigId = 6,
                    ColdWaterFee = 10,
                    HotWaterFee = 13
                },
                GasPaymentConfig = new GasPaymentsConfigDTO
                {
                    ConfigId = 6,
                    GasFee = 7
                }
            };

            return configService.CreateConfig(configDTO);
        }

        private PaymentsConfigDTO CreateFakeConfigObject(int id)
        {
            PaymentsConfigDTO configDTO = new PaymentsConfigDTO
            {
                Id = id,
                EnergyPaymentConfig = new EnergyPaymentsConfigDTO
                {
                    ConfigId = id,
                    CogenerationFee = 48888,
                    DistributionFee = 3888,
                    FixedSubscriptionFee = 88885
                },
                WaterPaymentConfig = new WaterPaymentsConfigDTO
                {
                    ConfigId = id,
                    ColdWaterFee = 10,
                    HotWaterFee = 13
                },
                GasPaymentConfig = new GasPaymentsConfigDTO
                {
                    ConfigId = id,
                    GasFee = 7
                }
            };

            return configDTO;
        }
    }
}