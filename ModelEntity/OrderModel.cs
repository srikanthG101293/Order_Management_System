using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ModelEntity
{
	public class OrderModel
	{
        public int OrderID { get; set; }
        public int OrderStatusId { get; set; }      
        public int ProductID { get; set; }
        public int UserID { get; set; }
        public string UserName { get; set; }
        public string ProductName { get; set; }
        public string ShippingAddress { get; set; }
        public string OrderStatus { get; set; }
        public decimal Weight { get; set; }
        public decimal Height { get; set; }
        public string ImageName { get; set; }
        public string OrderedDate { get; set; }
        public string SKU { get; set; }
        public string Barcode { get; set; }

    }

}