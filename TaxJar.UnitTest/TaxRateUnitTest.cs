using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Threading.Tasks;
using TaxJar.BusinessLayer;

namespace TaxJar.UnitTest
{
    [TestClass]
    public class TaxRateUnitTest
    {
        [TestMethod]
        public void TestGetUsTaxRateStateRate1()
        {
            var _bl = new TaxRateBl();
            var expected = new UsTaxRateViewModel
            {
                city = "SANTA MONICA",
                city_rate = 0,
                combined_district_rate = 0.03F,
                combined_rate = 0.1025F,
                country = "US",
                country_rate = 0,
                county = "LOS ANGELES",
                county_rate = 0.01F,
                freight_taxable = false,
                state = "CA",
                state_rate = 0.0625F,
                zip = "90404"
            };

            var parameters = new TaxRateParameterViewModel
            {
                zip = "90404-3370"
            };

            var result = _bl.GetAsync<UsTaxRateViewModel>(parameters).Result;
            
            Assert.AreEqual(expected.state_rate, result.state_rate);
        }

        [TestMethod]
        public void TestGetUsTaxRateStateRate2()
        {
            var _bl = new TaxRateBl();
            var expected = new UsTaxRateViewModel
            {
                city = null,
                city_rate = 0.01F,
                combined_district_rate = 0,
                combined_rate = 0.07F,
                country = "US",
                country_rate = 0,
                county = "CHITTENDEN",
                county_rate = 0,
                freight_taxable = true,
                state = "VT",
                state_rate = 0.06F,
                zip = "05495-2086"
            };

            var parameters = new TaxRateParameterViewModel
            {
                zip = "05495-2086",
                street = "312 Hurricane Lane",
                city = "Williston",
                state = "VT",
                country = "US"
            };

            var result = _bl.GetAsync<UsTaxRateViewModel>(parameters).Result;

            Assert.AreEqual(expected.state_rate, result.state_rate);
        }

        [TestMethod]
        public void TestGetCaTaxRateStateRate1()
        {
            var _bl = new TaxRateBl();
            var expected = new CaTaxRateViewModel
            {
                city = "TORONTO",
                combined_rate = 0.075F,
                country = "US",
                freight_taxable = true,
                state = "KS",
                zip = "66777"
            };

            var parameters = new TaxRateParameterViewModel
            {
                zip = "66777",
                country = "CA"
            };

            var result = _bl.GetAsync<CaTaxRateViewModel>(parameters).Result;

            Assert.AreEqual(expected.combined_rate, result.combined_rate);
        }
    }
}
