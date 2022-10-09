using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using TaxJar.BusinessLayer;

namespace TaxJar.Api.Controllers
{
    public class SalesTaxController : ApiController
    {
        private ISalesTaxBl _bl;

        public SalesTaxController(ISalesTaxBl bl)
        {
            _bl = bl;
        }

        [HttpPost]
        [RouteAttribute("api/salestax/us")]
        public async Task<HttpResponseMessage> GetUsSalesTax([FromBody] SalesTaxParameterViewModel parameters)
        {
            if (!ModelState.IsValid)
                return Request.CreateResponse(HttpStatusCode.BadRequest);

            var data = await _bl.PostAsync<SalesTaxViewModel<UsJurisdiction, UsBreakdown>>(parameters);

            if (data == null)
                return Request.CreateResponse(HttpStatusCode.NotFound);

            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        [HttpPost]
        [RouteAttribute("api/salestax/ca")]
        public async Task<HttpResponseMessage> GetCaSalesTax([FromBody] SalesTaxParameterViewModel parameters)
        {
            if (!ModelState.IsValid)
                return Request.CreateResponse(HttpStatusCode.BadRequest);

            var data = await _bl.PostAsync<SalesTaxViewModel<CaJurisdiction, CaBreakdown>>(parameters);

            if (data == null)
                return Request.CreateResponse(HttpStatusCode.NotFound);

            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        [HttpPost]
        [RouteAttribute("api/salestax/au")]
        public async Task<HttpResponseMessage> GetAuSalesTax([FromBody] SalesTaxParameterViewModel parameters)
        {
            if (!ModelState.IsValid)
                return Request.CreateResponse(HttpStatusCode.BadRequest);

            var data = await _bl.PostAsync<SalesTaxViewModel<AuJurisdiction, IntBreakdown>>(parameters);

            if (data == null)
                return Request.CreateResponse(HttpStatusCode.NotFound);

            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        [HttpPost]
        [RouteAttribute("api/salestax/eu")]
        public async Task<HttpResponseMessage> GetEuSalesTax([FromBody] SalesTaxParameterViewModel parameters)
        {
            if (!ModelState.IsValid)
                return Request.CreateResponse(HttpStatusCode.BadRequest);

            var data = await _bl.PostAsync<SalesTaxViewModel<EuJurisdiction, IntBreakdown>>(parameters);

            if (data == null)
                return Request.CreateResponse(HttpStatusCode.NotFound);

            return Request.CreateResponse(HttpStatusCode.OK, data);
        }
    }
}
