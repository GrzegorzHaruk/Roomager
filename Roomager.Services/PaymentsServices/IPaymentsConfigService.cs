using Roomager.Data;
using System;

namespace Roomager.Services.PaymentsServices
{
    public interface IPaymentsConfigService
    {
        PaymentConfigDTO GetConfig(int id);
    }
}