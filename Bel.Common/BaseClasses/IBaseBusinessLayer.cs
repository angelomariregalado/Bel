using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bel.Common
{
    public interface IBaseBusinessLayer : IDisposable
    {
        Task<T> GetAsync<T>(string requestUrl);
        Task<T> PostAsync<T>(string requestUrl, object parameters);
    }
}
