using Bel.Common;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaxJar.BusinessLayer
{
    public class SalesTaxBl : BaseBusinessLayer, ISalesTaxBl
    {
        private string _baseSalesTaxApiUrl;

        public SalesTaxBl()
        {
            _baseSalesTaxApiUrl = "/v2/taxes";
        }

        public async Task<T> PostAsync<T>(object parameters)
        {
            var requestUrl = $"{_baseSalesTaxApiUrl}";
            var data = await PostAsync<TaxViewModel<T>>(requestUrl, parameters);
            return data.tax;
        }

        public void Dispose()
        {
            _client.Dispose();
        }
    }
}
