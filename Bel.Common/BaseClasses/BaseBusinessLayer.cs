using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Bel.Common
{
    public abstract class BaseBusinessLayer : IBaseBusinessLayer
    {
        public HttpClient _client;
        public string _baseApiAddress;
        public string _apiToken;

        public BaseBusinessLayer()
        {
            _baseApiAddress = "https://api.taxjar.com";
            _apiToken = "5da2f821eee4035db4771edab942a4cc";

            _client = new HttpClient();
            _client.BaseAddress = new Uri(_baseApiAddress);
            _client.DefaultRequestHeaders.Accept.Clear();
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _apiToken);
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public virtual async Task<T> GetAsync<T>(string requestUrl)
        {
            var data = default(T);

            try
            {
                var response = await _client.GetAsync(requestUrl);

                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    data = JsonConvert.DeserializeObject<T>(json);
                }
            }
            catch (Exception e)
            {

                throw;
            }

            return data;
        }

        public virtual async Task<T> PostAsync<T>(string requestUrl, object parameters)
        {
            var data = default(T);

            try
            {
                var requestUrlParameters = parameters.ToContentParameter();
                var response = await _client.PostAsync(requestUrl, requestUrlParameters);

                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    data = JsonConvert.DeserializeObject<T>(json);
                }
            }
            catch (Exception e)
            {

                throw;
            }

            return data;
        }

        public void Dispose()
        {

        }
    }
}
