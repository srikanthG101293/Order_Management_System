using DataAccessLayer;
using ModelEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace BusinessLayer
{
    public class OrderBusiness
    {
        OrderEntity objDAC = new OrderEntity();
        /// <summary>
        /// This Method is Used to get Orders Based on Role
        /// </summary>
        /// <param name="UserId"></param>
        /// <returns></returns>
        public List<OrderModel> GetAllOrders(int UserId)
        {
            DataTable dt = new DataTable();
            List<OrderModel> orderList = new List<OrderModel>();
            try
            {
                dt = objDAC.GetAllOrders(UserId);               
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    OrderModel order = new OrderModel();
                    order.OrderID = Convert.ToInt32(dt.Rows[i]["OrderID"]);
                    order.UserName = Convert.ToString(dt.Rows[i]["UserName"]);
                    order.ProductName = Convert.ToString(dt.Rows[i]["ProductName"]);
                    order.ShippingAddress = Convert.ToString(dt.Rows[i]["ShippingAddress"]);
                    order.Weight = Convert.ToInt32(dt.Rows[i]["Weight"]);
                    order.Height = Convert.ToInt32(dt.Rows[i]["Height"]);
                    order.OrderStatus = Convert.ToString(dt.Rows[i]["ImageName"]);
                    order.OrderedDate = Convert.ToString(dt.Rows[i]["OrderedDate"]);
                    orderList.Add(order);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return orderList;
        }

        public int DeleteOrder(OrderModel ParamOBJ)
        {
            int Result = 0;
            try
            {
                Result = objDAC.DeleteOrder(ParamOBJ);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return Result;
        }
        public int UpdateOrder(OrderModel ParamOBJ)
        {
            int Result = 0;
            try
            {
                Result = objDAC.UpdateOrder(ParamOBJ);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return Result;
        }

        public int AddOrder(OrderModel ParamOBJ)
        {
            int Result = 0; 
            try
            {
                Result = objDAC.AddOrder(ParamOBJ);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return Result;
        }
    }
}
