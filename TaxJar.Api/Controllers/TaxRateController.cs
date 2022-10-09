using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using TaxJar.BusinessLayer;

namespace TaxJar.Api.Controllers
{
    public class TaxRateController : ApiController
    {
        private ITaxRateBl _bl;

        public TaxRateController(ITaxRateBl bl)
        {
            _bl = bl;
        }

        [HttpGet]
        [RouteAttribute("api/taxrate/us")]
        public async Task<HttpResponseMessage> GetUsTaxRateAsync([FromUri] TaxRateParameterViewModel parameters)
        {
            if (!ModelState.IsValid)
                return Request.CreateResponse(HttpStatusCode.BadRequest);

            var data = await _bl.GetAsync<UsTaxRateViewModel>(parameters);

            if (data == null)
                return Request.CreateResponse(HttpStatusCode.NotFound);

            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        [HttpGet]
        [RouteAttribute("api/taxrate/ca")]
        public async Task<HttpResponseMessage> GetCaTaxRateAsync([FromUri] TaxRateParameterViewModel parameters)
        {
            if (!ModelState.IsValid)
                return Request.CreateResponse(HttpStatusCode.BadRequest);

            var data = await _bl.GetAsync<CaTaxRateViewModel>(parameters);

            if (data == null)
                return Request.CreateResponse(HttpStatusCode.NotFound);

            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        [HttpGet]
        [RouteAttribute("api/taxrate/au")]
        public async Task<HttpResponseMessage> GetAuTaxRateAsync([FromUri] TaxRateParameterViewModel parameters)
        {
            if (!ModelState.IsValid)
                return Request.CreateResponse(HttpStatusCode.BadRequest);

            var data = await _bl.GetAsync<AuTaxRateViewModel>(parameters);

            if (data == null)
                return Request.CreateResponse(HttpStatusCode.NotFound);

            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        [HttpGet]
        [RouteAttribute("api/taxrate/eu")]
        public async Task<HttpResponseMessage> GetEuTaxRateAsync([FromUri] TaxRateParameterViewModel parameters)
        {
            if (!ModelState.IsValid)
                return Request.CreateResponse(HttpStatusCode.BadRequest);

            var data = await _bl.GetAsync<AuTaxRateViewModel>(parameters);

            if (data == null)
                return Request.CreateResponse(HttpStatusCode.NotFound);

            return Request.CreateResponse(HttpStatusCode.OK, data);
        }
    }
}
