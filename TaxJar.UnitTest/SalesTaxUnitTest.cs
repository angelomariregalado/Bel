using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using TaxJar.BusinessLayer;

namespace TaxJar.UnitTest
{
    [TestClass]
    public class SalesTaxUnitTest
    {
        [TestMethod]
        public void TestGetUsSalesTaxAmountToCollect()
        {
            var _bl = new SalesTaxBl();
            var expected = new SalesTaxViewModel<UsJurisdiction, UsBreakdown>
            {
                amount_to_collect = 1.43F
            };

            var parameters = new SalesTaxParameterViewModel
            {
                from_country = "US",
                from_zip = "92093",
                from_state = "CA",
                from_city = "La Jolla",
                from_street = "9500 Gilman Drive",
                to_country = "US",
                to_zip = "90002",
                to_state = "Ca",
                to_city = "Los Angeles",
                to_street = "1335 E 103rd St",
                amount = 15,
                shipping = 1.5F,
                nexus_addresses = new List<NexusAddressViewModel>
                {
                    new NexusAddressViewModel
                    {
                        id = "Main Location",
                        country = "US",
                        zip = "92093",
                        state = "CA",
                        city = "La Jolla",
                        street = "9500 Gilman Drive"
                    }
                },
                line_items = new List<LineItemViewModel>
                {
                    new LineItemViewModel
                    {
                        id = "1",
                        quantity = 1,
                        product_tax_code = "20010",
                        unit_price = 15,
                        discount = 0
                    }
                }
            };

            var result = _bl.PostAsync<SalesTaxViewModel<UsJurisdiction, UsBreakdown>>(parameters).Result;
            
            Assert.AreEqual(expected.amount_to_collect, result.amount_to_collect);
        }
    }
}
