using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelEntity;

namespace DataAccessLayer
{
   public class ProductEntity
    {

        static string strConnString = ConfigurationManager.ConnectionStrings["DBconnection"].ConnectionString;

        SqlCommand sqlcmd = default(SqlCommand);

        SqlDataAdapter da = new SqlDataAdapter();
        SqlDataReader dr;
        SqlConnection sqlcon = new SqlConnection(strConnString);

        public int AddingNewProductDetails(OrderModel ParamOBJ)
        {
            int res = 0;
            try
            {
                sqlcmd = new SqlCommand("SP_AddOrUpdateProductDetails", sqlcon);
                sqlcmd.CommandType = CommandType.StoredProcedure;
                sqlcmd.Parameters.Add("@UserID", SqlDbType.Int).Value = ParamOBJ.UserID;
                sqlcmd.Parameters.Add("@ProductName", SqlDbType.VarChar,250).Value = ParamOBJ.ProductName;
                sqlcmd.Parameters.Add("@Weight", SqlDbType.Decimal).Value = ParamOBJ.Weight;
                sqlcmd.Parameters.Add("@Height", SqlDbType.Decimal).Value = ParamOBJ.Height;
                sqlcmd.Parameters.Add("@ImageName", SqlDbType.VarChar,250).Value = ParamOBJ.ImageName;
                sqlcmd.Parameters.Add("@SKU", SqlDbType.VarChar,500).Value = ParamOBJ.SKU;
                sqlcmd.Parameters.Add("@Barcode", SqlDbType.NVarChar,500).Value = ParamOBJ.Barcode;
                sqlcmd.Parameters.Add("@Mode", SqlDbType.Int).Value = 1; //1 FOR Adding
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

        public int UpdateProductDetails(OrderModel ParamOBJ)
        {
            int res = 0;
            try
            {
                sqlcmd = new SqlCommand("SP_AddOrUpdateProductDetails", sqlcon);
                sqlcmd.CommandType = CommandType.StoredProcedure;
                sqlcmd.Parameters.Add("@UserID", SqlDbType.Int).Value = ParamOBJ.UserID;
                sqlcmd.Parameters.Add("@ProductID", SqlDbType.Int).Value = ParamOBJ.ProductID;
                sqlcmd.Parameters.Add("@ProductName", SqlDbType.VarChar, 250).Value = ParamOBJ.ProductName;
                sqlcmd.Parameters.Add("@Weight", SqlDbType.Decimal).Value = ParamOBJ.Weight;
                sqlcmd.Parameters.Add("@Height", SqlDbType.Decimal).Value = ParamOBJ.Height;
                sqlcmd.Parameters.Add("@ImageName", SqlDbType.VarChar, 250).Value = ParamOBJ.ImageName;
                sqlcmd.Parameters.Add("@SKU", SqlDbType.VarChar, 500).Value = ParamOBJ.SKU;
                sqlcmd.Parameters.Add("@Barcode", SqlDbType.NVarChar, 500).Value = ParamOBJ.Barcode;
                sqlcmd.Parameters.Add("@Mode", SqlDbType.Int).Value = 2; //2 FOR Update
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
    }
}
