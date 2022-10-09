using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaxJar.BusinessLayer
{
    public class TaxRateParameterViewModel
    {
        public string country { get; set; }
        [Required]
        public string zip { get; set; }
        public string state { get; set; }
        public string city { get; set; }
        public string street { get; set; }
    }
}
