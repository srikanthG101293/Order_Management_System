using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using ModelEntity;

namespace BusinessLayer
{
    public class ProductBusiness
    {
        ProductEntity ObjProd = new ProductEntity();
        public int AddingNewProductDetails(OrderModel ParamOBJ )
        {
            int RetVal = 0;

            RetVal = ObjProd.AddingNewProductDetails(ParamOBJ);
            return RetVal;
        }
        public int UpdateProduct(OrderModel ParamOBJ)
        {
            int RetVal = 0;

            RetVal = ObjProd.UpdateProductDetails(ParamOBJ);
            return RetVal;
        }
    }
}
