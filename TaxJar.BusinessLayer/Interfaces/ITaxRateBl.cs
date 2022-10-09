using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaxJar.BusinessLayer
{
    public interface ITaxRateBl : IDisposable
    {
        Task<T> GetAsync<T>(TaxRateParameterViewModel parameters);
    }
}
