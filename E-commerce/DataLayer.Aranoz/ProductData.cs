using Aranoz.Model;
using Aranoz.Model.Model;
using Aranoz.Utility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Aranoz
{
   public class ProductData
    {
        public List<ProductModel> GetAllProduct()
        {
            List<ProductModel> allProducts = new List<ProductModel>();

            using (SqlConnection connection=new SqlConnection(ConnectionStringProvider.Connection))
            {
                SqlCommand command = connection.CreateCommand();
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.CommandText = "spGetProducts";
                SqlDataAdapter sqlData = new SqlDataAdapter(command);
                DataTable dbProducts = new DataTable();

                connection.Open();
                sqlData.Fill(dbProducts);
                connection.Close();


                foreach(DataRow dr in dbProducts.Rows)
                {
                    allProducts.Add(new ProductModel
                    {
                        ProdutID=Convert.ToInt32(dr["ProductID"]),
                        ProductName=dr["ProductName"].ToString(),
                        ProductDetails = dr["ProductDetails"].ToString(),
                        ProductPrice=Convert.ToDouble(dr["ProductPrice"]),
                        ProductImage= dr["ProductImage"].ToString(),

                    });
                }

                return allProducts;

            }
        }



        public List<ProductModel> GetSpecificProduct(int Id)
        {
            List<ProductModel> products = new List<ProductModel>();

            using (SqlConnection connection = new SqlConnection(ConnectionStringProvider.Connection))
            {
               using(SqlCommand command=new SqlCommand("spGetSpecificProducts", connection))
                {
                    command.CommandType=CommandType.StoredProcedure;
                    command.Parameters.Add("@Id", SqlDbType.Int).Value = Id;

                    try
                    {
                        connection.Open();
                        SqlDataReader productList = command.ExecuteReader();
                        foreach(var items in productList)
                        {
                            ProductModel singleProduct = new ProductModel();
                            singleProduct.ProdutID = (int)productList["ProductID"];
                            singleProduct.ProductName = (string)productList["ProductName"];
                            singleProduct.ProductPrice = (double)productList["ProductPrice"];
                            singleProduct.ProductImage = (string)productList["ProductImage"];
                            singleProduct.ProductDetails = (string)productList["ProductDetails"];
                            singleProduct.CategoryId = (int)productList["CategoryId"];
                            products.Add(singleProduct);
                        }
                        return products;
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("Exception : " + ex.Message);
                    }

                    finally
                    {
                        connection.Close();
                    }
                }
            }

            return products;
        }


        //retriving the cart items from db 

        public List<ProductModel> CartItem(List<SessionIdModel> productsId)
        {

            List<ProductModel> cartProducts = new List<ProductModel>();

            using(SqlConnection connection=new SqlConnection(ConnectionStringProvider.Connection))
            {
             
                    using(SqlCommand command=new SqlCommand("spCartProduct", connection))
                    {
                    var dt = new DataTable();
                    dt.Columns.Add("Id", typeof(int));
                    foreach(var id in productsId)
                    {
                        dt.Rows.Add(id.Id);
                    }
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.Add("@PId", SqlDbType.Structured).Value = dt;
                        try
                        {
                            connection.Open();
                            SqlDataReader cartItem= command.ExecuteReader();
                        foreach(var items in cartItem)
                        {
                            ProductModel cartProduct = new ProductModel();
                            cartProduct.ProdutID = (int)cartItem["ProductID"];
                            cartProduct.ProductName = (string)cartItem["ProductName"];
                            cartProduct.ProductPrice = (double)cartItem["ProductPrice"];
                            cartProduct.ProductImage = (string)cartItem["ProductImage"];
                            cartProduct.ProductDetails = (string)cartItem["ProductDetails"];
                            cartProduct.CategoryId = (int)cartItem["CategoryId"];

                            cartProducts.Add(cartProduct);

                        }
                        return cartProducts;
                        }
                        catch(Exception ex)
                        {
                        throw new Exception("Exception:" + ex.Message);
                        }
                        finally
                        {
                            connection.Close();
                        }

                    }
              
            }

            return cartProducts;
        }
    }
}
