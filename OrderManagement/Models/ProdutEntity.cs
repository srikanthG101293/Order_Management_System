using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OrderManagement.Models
{
	public class ProdutEntity
	{
        public int OrderID { get; set; }
        public string UserName { get; set; }
        public string ProductName { get; set; }
        public string ShippingAddress { get; set; }
        public string OrderStatus { get; set; }
    }
}