using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyStore.Models
{
    public class ProductModel
    {
        
        public int Productid { get; set; }
        
        public string Productname { get; set; }
        public int Supplierid { get; set; }
        public int Categoryid { get; set; }
      
        public decimal Unitprice { get; set; }
        public bool Discontinued { get; set; }
    }
}
