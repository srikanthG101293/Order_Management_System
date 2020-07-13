using BusinessLayer;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Http;
using ModelEntity;

namespace OrderManagement.Controllers
{


    public class ProductController : ApiController
    {
        ProductBusiness objbiz = new ProductBusiness();
        /*Adding new Product details*/
        [HttpPost]
        public HttpResponseMessage AddProduct(OrderModel ParamOBJ )
        {
            int result = 0;
            try
            {
                result = objbiz.AddingNewProductDetails(ParamOBJ);
  
                var response = new HttpResponseMessage(HttpStatusCode.OK);
                if (result == 1)
                {
                    response.Content = new StringContent("Product Added Succesfully..!!!");
                }else
                {
                    response.Content = new StringContent("You don't have any access to add this product details");
                }
                response.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                return response;
            }
            catch
            {
                return new HttpResponseMessage(HttpStatusCode.BadRequest);
            }
        }
        /*Update Product details*/
        [HttpPut]
        public HttpResponseMessage UpdateProduct(OrderModel ParamOBJ)
        {
            int result = 0;
            try
            {
                result = objbiz.UpdateProduct(ParamOBJ);

                var response = new HttpResponseMessage(HttpStatusCode.OK);
                if (result == 1)
                {
                    response.Content = new StringContent("Product Updated Succesfully..!!!");
                }
                else
                {
                    response.Content = new StringContent("You don't have any access to update this product details");
                }
                response.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                return response;
            }
            catch
            {
                return new HttpResponseMessage(HttpStatusCode.BadRequest);
            }
        }
    }
}
