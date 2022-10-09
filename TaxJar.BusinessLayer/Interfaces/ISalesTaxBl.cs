using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaxJar.BusinessLayer
{
    public interface ISalesTaxBl : IDisposable
    {
        Task<T> PostAsync<T>(object parameters);
    }
}
