using System;
using System.Collections.Generic;
using System.Text;
using Roomager.DataAccess.DataAccessObjects;
using Roomager.Data;

namespace Roomager.Services.PaymentsServices
{
    public class PaymentsConfigService : IPaymentsConfigService
    {
        private IPaymentsConfigDAO paymentsConfigDAO;

        public PaymentsConfigService(IPaymentsConfigDAO paymentsConfigDAO)
        {
            this.paymentsConfigDAO = paymentsConfigDAO;
        }

        public PaymentConfigDTO GetConfig(int id)
        {
            PaymentConfigDTO config = paymentsConfigDAO.GetConfig(id);
            if (config != null)
            {
                return config;
            }

            return config;
        }
    }
}
