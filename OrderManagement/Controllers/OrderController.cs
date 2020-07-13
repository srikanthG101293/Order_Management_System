using BusinessLayer;
using ModelEntity;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Http;

namespace OrderManagement.Controllers
{
    public class OrderController : ApiController
    {

   
            OrderBusiness objbiz = new OrderBusiness();

            /*This Method is Used to get Orders Based on Role*/
            [HttpGet]
            public HttpResponseMessage GetAllOrders(int id)
            {
                try
                {
                    List<OrderModel> PrdList = new List<OrderModel>();
                    PrdList = objbiz.GetAllOrders(id);
                    var response = new HttpResponseMessage(HttpStatusCode.OK);
                    response.Content = new StringContent(JsonConvert.SerializeObject(PrdList));
                    response.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                    return response;
                }
                catch
                {
                    return new HttpResponseMessage(HttpStatusCode.BadRequest);
                }
            }



            /*This Method is Used to Delete Orders*/

            [HttpDelete]
            public HttpResponseMessage DeleteOrder(OrderModel ParamObj)
            {
                int result = 0;
                try
                {
                    result = objbiz.DeleteOrder(ParamObj);

                    var response = new HttpResponseMessage(HttpStatusCode.OK);
                    if (result == 1)
                    {
                        response.Content = new StringContent("Order Deleted Succesfully..!!!");
                    }
                    response.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                    return response;
                }
                catch
                {
                    return new HttpResponseMessage(HttpStatusCode.BadRequest);
                }
            }
            /*This Method is Used to Update Order*/
            [HttpPut]
            public HttpResponseMessage UpdateOrder(OrderModel ParamObj)
            {
                int result = 0;
                try
                {
                    result = objbiz.UpdateOrder(ParamObj);

                    var response = new HttpResponseMessage(HttpStatusCode.OK);
                    if (result == 1)
                    {
                        response.Content = new StringContent("Order Updated Succesfully..!!!");
                    }
                    response.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                    return response;
                }
                catch
                {
                    return new HttpResponseMessage(HttpStatusCode.BadRequest);
                }
            }

        /*This Method is Used to Add Orders */
        [HttpPost]
            public HttpResponseMessage AddOrder(OrderModel ParamObj)
            {
                int result = 0;
                try
                {
                    result = objbiz.AddOrder(ParamObj);

                    var response = new HttpResponseMessage(HttpStatusCode.OK);
                    if (result == 1)
                    {
                        response.Content = new StringContent("Order Added Succesfully..!!!");
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
