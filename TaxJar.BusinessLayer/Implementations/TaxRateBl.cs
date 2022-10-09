using Bel.Common;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace TaxJar.BusinessLayer
{
    public class TaxRateBl : BaseBusinessLayer, ITaxRateBl
    {
        private string _baseTaxRateApiUrl;

        public TaxRateBl()
        {
            _baseTaxRateApiUrl = "/v2/rates";
        }

        public async Task<T> GetAsync<T>(TaxRateParameterViewModel parameters)
        {
            var ignoredParameters = new List<string>
            {
                "zip"
            };

            var requestUrlParameters = parameters.ToUrlParameter(ignoredParameters);
            var requestUrl = $"{_baseTaxRateApiUrl}/{parameters.zip}?{requestUrlParameters}";
            var data = await GetAsync<RateViewModel<T>>(requestUrl);
            return data.rate;
        }

        public void Dispose()
        {
            _client.Dispose();
        }
    }
}
