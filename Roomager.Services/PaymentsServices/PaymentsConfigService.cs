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

        public PaymentsConfigDTO GetConfig(int id)
        {
            PaymentsConfigDTO config = paymentsConfigDAO.GetConfig(id);
            if (config != null)
            {
                return config;
            }

            return config;
        }

        public int CreateConfig(PaymentsConfigDTO config)
        {
            int rowsAffected = 0;

            if (config != null)
            {
                rowsAffected = paymentsConfigDAO.CreateConfig(config);
                return rowsAffected;
            }

            return rowsAffected;
        }
    }
}
