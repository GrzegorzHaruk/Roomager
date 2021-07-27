using Roomager.Data;
using System;

namespace Roomager.Services.PaymentsServices
{
    public interface IPaymentsConfigService
    {
        PaymentsConfigDTO GetConfig(int id);
        int CreateConfig(PaymentsConfigDTO config);
    }
}