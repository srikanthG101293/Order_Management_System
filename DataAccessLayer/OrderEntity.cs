using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using ModelEntity;
using System.Net;
using System.Net.Mail;

namespace DataAccessLayer
{
    public class OrderEntity
    {
        static string strConnString = ConfigurationManager.ConnectionStrings["DBconnection"].ConnectionString;

        SqlCommand sqlcmd = default(SqlCommand);

        SqlDataAdapter da = new SqlDataAdapter();
        SqlDataReader dr;
        SqlConnection sqlcon = new SqlConnection(strConnString);
       

        public DataTable GetAllOrders(int UserId)
        {
            DataTable dt = new DataTable();
            
            string result = string.Empty;
            try
            {
                sqlcmd = new SqlCommand("SP_Get_OrderDetails", sqlcon);
                sqlcmd.CommandType = CommandType.StoredProcedure;
                sqlcmd.Parameters.Add("@UserID", SqlDbType.Int).Value = UserId;                
                da.SelectCommand = sqlcmd;
                da.Fill(dt);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

        public int DeleteOrder (OrderModel ParamObj)
        {
            int res = 0;
            try
            {

                sqlcmd = new SqlCommand("SP_SaveOrderDetails", sqlcon);
                sqlcmd.CommandType = CommandType.StoredProcedure;
                sqlcmd.Parameters.Add("@UserID", SqlDbType.Int).Value = ParamObj.UserID;
                sqlcmd.Parameters.Add("@OrderID", SqlDbType.Int).Value = ParamObj.OrderID;
                sqlcmd.Parameters.Add("@Mode", SqlDbType.Int).Value = 2; //2 FOR DELETE
                sqlcon.Open();
                res= sqlcmd.ExecuteNonQuery();
                sqlcon.Close();
            }
            catch (Exception  ex)
            {
                throw ex;
            }
            return res;
        }
        public int UpdateOrder(OrderModel ParamObj)
        {
            int res = 0;
            try
            {
                sqlcmd = new SqlCommand("SP_SaveOrderDetails", sqlcon);
                sqlcmd.CommandType = CommandType.StoredProcedure;
                sqlcmd.Parameters.Add("@UserID", SqlDbType.Int).Value = ParamObj.UserID;
                sqlcmd.Parameters.Add("@OrderID", SqlDbType.Int).Value = ParamObj.OrderID;
                sqlcmd.Parameters.Add("@ShippingAddress", SqlDbType.VarChar,250).Value = ParamObj.ShippingAddress;
                sqlcmd.Parameters.Add("@OrderStatus", SqlDbType.Int).Value = ParamObj.OrderStatusId;
                sqlcmd.Parameters.Add("@Mode", SqlDbType.Int).Value = 1; //1 FOR UPDATE
                sqlcon.Open();
                res = sqlcmd.ExecuteNonQuery();
                sqlcon.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return res;
        }
        public int AddOrder(OrderModel ParamObj)
        {
            int result = 0;
            DataSet ds= new DataSet();
            DataTable dt = new DataTable();
            try
            {
                sqlcmd = new SqlCommand("SP_SaveOrderDetails", sqlcon);
                sqlcmd.CommandType = CommandType.StoredProcedure;
                sqlcmd.Parameters.Add("@UserID", SqlDbType.Int).Value = ParamObj.UserID;
                sqlcmd.Parameters.Add("@OrderID", SqlDbType.Int).Value = ParamObj.OrderID;
                sqlcmd.Parameters.Add("@ShippingAddress", SqlDbType.VarChar, 250).Value = ParamObj.ShippingAddress;
                sqlcmd.Parameters.Add("@OrderStatus", SqlDbType.Int).Value = ParamObj.OrderStatusId;
                sqlcmd.Parameters.Add("@ProductID", SqlDbType.Int).Value = ParamObj.ProductID;
                sqlcmd.Parameters.Add("@Mode", SqlDbType.Int).Value = 3; //3 FOR Adding
                da.SelectCommand = sqlcmd;
                da.Fill(ds);
                dt = ds.Tables[0];

                /*Order status send to user start */
                Email(dt);
                /*Order status send to user end */

                if (dt.Rows.Count > 0)
                {
                    result = 1;
                }
    
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                sqlcon.Close();
                sqlcon.Dispose();
            }
            return result;
        }
        public static void Email(DataTable dt)
        {
            string htmlString=string.Empty;
            string EmailAddress = string.Empty;
            try
            {
                /*-----TO SEND ORDER DETIALS ----*/

                foreach (DataRow row in dt.Rows)
                {

                    string ShippingAddress = row["ShippingAddress"].ToString();
                    string ProductName = row["ProductName"].ToString();
                    string OrderStatus = row["OrderStatus"].ToString();
                    string UserName = row["UserName"].ToString();
                    EmailAddress = row["EmailAddress"].ToString();
                    string Orderdate = row["Orderdate"].ToString();
                    string PhoneNumber = row["PhoneNumber"].ToString();

                    htmlString += "<html><body>";
                    htmlString += "Hi " + UserName + " <br/>";

                    htmlString += "<h1><p> Your Order is Confirmed successfully </p></h1>";
                    htmlString += "<p> Ordered Item: " + ProductName + " </p>";
                    htmlString += "<p> Ordered Date: " + Orderdate + " </p><br>";
                    htmlString += "Thanks & Regards <br>";
                    htmlString += " Srikanth";
                    htmlString += "</body></html>";
                }

                MailMessage message = new MailMessage();
                SmtpClient smtp = new SmtpClient();
                message.From = new MailAddress("sreekarsree2693@gmail.com");
                message.To.Add(new MailAddress(EmailAddress));
                message.Subject = "Order Status";
                message.IsBodyHtml = true; //to make message body as html  
                message.Body = htmlString;
                smtp.Port = 587;
                smtp.Host = "smtp.gmail.com"; //for gmail host  
                smtp.EnableSsl = true;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new NetworkCredential("sreekarsree2693@gmail.com", "********");
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtp.Send(message);
            }
            catch (Exception ex)
            { throw ex;  }
        }

    }
}
