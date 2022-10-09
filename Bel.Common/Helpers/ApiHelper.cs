using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Bel.Common
{
    public static class ApiHelper
    {
        public static string ToUrlParameter(this object parameters)
        {
            string result = null;

            try
            {
                var serializedParameters = JsonConvert.SerializeObject(parameters, Formatting.None, new JsonSerializerSettings
                {
                    NullValueHandling = NullValueHandling.Ignore,
                    ContractResolver = new CamelCasePropertyNamesContractResolver()
                });

                var dictionaryParameters = JsonConvert.DeserializeObject<IDictionary<string, string>>(serializedParameters);
                var encodedParameters = dictionaryParameters.Select(x => HttpUtility.UrlEncode(x.Key) + "=" + HttpUtility.UrlEncode(x.Value));
                result = string.Join("&", result);
            }
            catch (Exception e)
            {

                throw;
            }

            return result;
        }

        public static string ToUrlParameter(this object parameters, List<string> ignoredParameters)
        {
            string result = null;

            try
            {
                var serializedParameters = JsonConvert.SerializeObject(parameters, Formatting.None, new JsonSerializerSettings
                {
                    NullValueHandling = NullValueHandling.Ignore,
                    ContractResolver = new CamelCasePropertyNamesContractResolver()
                });

                var dictionaryParameters = JsonConvert.DeserializeObject<IDictionary<string, string>>(serializedParameters);

                foreach (var parameter in ignoredParameters)
                {
                    dictionaryParameters.Remove(parameter);
                }

                var encodedParameters = dictionaryParameters.Select(x => HttpUtility.UrlEncode(x.Key) + "=" + HttpUtility.UrlEncode(x.Value));
                result = string.Join("&", result);
            }
            catch (Exception e)
            {

                throw;
            }

            return result;
        }

        public static ByteArrayContent ToContentParameter(this object parameters)
        {
            ByteArrayContent byteContent = null;

            try
            {
                var serializedParameters = JsonConvert.SerializeObject(parameters, Formatting.None, new JsonSerializerSettings
                {
                    NullValueHandling = NullValueHandling.Ignore,
                    ContractResolver = new CamelCasePropertyNamesContractResolver()
                });

                var buffer = Encoding.UTF8.GetBytes(serializedParameters);
                byteContent = new ByteArrayContent(buffer);
                byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            }
            catch (Exception e)
            {

                throw;
            }

            return byteContent;
        }
    }
}
