using System;
using System.Collections.Generic;
using System.IO;
using System.Configuration;
using System.Web.UI.WebControls;
using System.Web;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Data;
using MySql.Data.MySqlClient;
using MyAppServices.Models;



namespace MyAppServices.Models
{
    public class DataAccess
    {
        static string connectString = "SERVER=localhost;UID=root;DATABASE=MyAppData;";
        static MySqlDataReader read;

        //Register
        public string AddCust(Customer cust)
        {
            string x = "";
            using (MySqlConnection connect = new MySqlConnection())
            {
                connect.ConnectionString = connectString;
                string query = "INSERT INTO MyAppData.Cust(Firstname,Lastname,Mobile,Email,Password) " +
                    "VALUES('" + cust.Firstname + "','" + cust.Lastname + "','" + cust.Mobile + "','" + cust.Email + "','" + cust.password + "');";
                using (MySqlCommand comma = new MySqlCommand(query, connect))
                {
                    try
                    {
                        comma.Connection.Open();

                        comma.Parameters.AddWithValue("@Firstname", cust.Firstname);
                        comma.Parameters.AddWithValue("@Lastname", cust.Lastname);
                        comma.Parameters.AddWithValue("@Mobile", cust.Mobile);
                        comma.Parameters.AddWithValue("@Email", cust.Email);
                        comma.Parameters.AddWithValue("@Password", cust.password);
                        int y = comma.ExecuteNonQuery();

                        x = y.ToString();

                    }
                    catch (MySqlException ex)
                    {
                        ex.ToString();
                        comma.Connection.Close();
                    }
                }
                return null;
            }
        }


        //Login

        public Customer CustomerLogin(string email, string passwords)
        {
            string sql = "SELECT CustId,Firstname,Lastname,Mobile,Email,password FROM MyAppData.Cust WHERE Email='" + email + "'AND password='" + passwords + "';";

            using (MySqlConnection connect = new MySqlConnection())
            {
                connect.ConnectionString = connectString;
                MySqlCommand comma = new MySqlCommand(sql, connect);
                comma.Connection = connect;

                try
                {
                    comma.Connection.Open();
                    comma.Parameters.Add(new MySqlParameter("@Email", email));
                    comma.Parameters.Add(new MySqlParameter("@password", passwords));

                    read = comma.ExecuteReader();

                    while (read.Read())
                    {
                        return new Customer(Convert.ToInt32(read["CustId"]), Convert.ToString(read["Firstname"]), Convert.ToString(read["Lastname"]), Convert.ToString(read["Mobile"]), Convert.ToString(read["Email"]), Convert.ToString(read["password"]));
                    }
                    read.Close();
                }
                catch (MySqlException exception)
                {
                    comma.Connection.Close();
                    exception.ToString();
                }
                return null;
            }
        }


        //Update customer information
        public Customer CustomerUpdate(Customer cust, int id)
        {
            string sql = "UPDATE MyAppData.Cust SET Firstname='" + cust.Firstname + "',Lastname='" + cust.Lastname + "',Mobile='" + cust.Mobile + "' WHERE CustId=" + id + ";";
            using (MySqlConnection connect = new MySqlConnection())
            {
                connect.ConnectionString = connectString;
                using (MySqlCommand comma = new MySqlCommand(sql, connect))
                {

                    comma.Connection = connect;
                    try
                    {
                        comma.Connection.Open();

                        comma.Parameters.Add(new MySqlParameter("Firstname", cust.Firstname));
                        comma.Parameters.Add(new MySqlParameter("Lastname", cust.Lastname));
                        comma.Parameters.Add(new MySqlParameter("Mobile", cust.Mobile));
                        comma.Parameters.Add(new MySqlParameter("Email", cust.Email));
                        comma.Parameters.Add(new MySqlParameter("password", cust.password));


                        read = comma.ExecuteReader();
                        while (read.Read())
                        {
                            return cust = new Customer(Convert.ToString(read["Firstname"]),
                                                Convert.ToString(read["Lastname"]),
                                                Convert.ToString(read["Mobile"]),
                                                Convert.ToString(read["Email"]),
                                                Convert.ToString(read["password"])                                              
                                           );
                        }
                        read.Close();

                    }
                    catch (MySqlException exception)
                    {
                        exception.ToString();

                    }
                    finally
                    {
                        comma.Connection.Close();
                    }
                }
                return cust;
            }
        }


        //Get Restaurants
        public Restaurant[] GetRestaurant()
        {
            List<Restaurant> restaurants = new List<Restaurant>();

            using (MySqlConnection connect = new MySqlConnection())
            {
                connect.ConnectionString = connectString;

                string querys = "SELECT res_Id,Res_Name,Res_Location,Res_City,Image FROM MyAppData.Restaurants;";
                using (MySqlCommand comma = new MySqlCommand(querys, connect))
                {
                    try
                    {
                        comma.Connection.Open();
                        Restaurant res = new Restaurant();

                        read = comma.ExecuteReader();
                        while (read.Read())
                        {
                            res = new Restaurant(Convert.ToInt32(read["res_Id"]),
                                                Convert.ToString(read["Res_Name"]),
                                                Convert.ToString(read["Res_Location"]),
                                                Convert.ToString(read["Res_City"]),
                                                 (byte[])(read["Image"])

                                               );
                            restaurants.Add(res);

                        }
                        read.Close();
                        MySqlDataReader reader = comma.ExecuteReader(System.Data.CommandBehavior.SingleRow);
                        reader.Read();
                        reader.Close();
                    }
                    catch (MySqlException ex)
                    {
                        ex.ToString();
                    }
                    finally
                    {
                        comma.Connection.Close();
                    }
                }
                return restaurants.ToArray();
            }

        }

        //Make Payment
        public string payments(Payment pay)
        {
            string x = "";
            using (MySqlConnection connect = new MySqlConnection())
            {
                connect.ConnectionString = connectString;
                string query = "INSERT INTO MyAppData.Payment(CardName,CardNumber,Cvv,cust_Id) " +
                    "VALUES('" + pay.CardName + "','" + pay.CardNumber + "','" + pay.Cvv + "','" + pay.cust_Id + "');";
                using (MySqlCommand comma = new MySqlCommand(query, connect))
                {
                    try
                    {
                        comma.Connection.Open();

                        comma.Parameters.AddWithValue("@CardName", pay.CardName);
                        comma.Parameters.AddWithValue("@CardNumber", pay.CardNumber);
                        comma.Parameters.AddWithValue("@Cvv", pay.Cvv);
                        comma.Parameters.AddWithValue("@cust_Id", pay.cust_Id);
                        int y = comma.ExecuteNonQuery();

                        x = y.ToString();

                    }
                    catch (MySqlException ex)
                    {
                        ex.ToString();
                        comma.Connection.Close();
                    }
                }
                return null;
            }
        }

        //Place an Order

        public string Orders(Order ord)
        {
            string x = "";
            using (MySqlConnection connect = new MySqlConnection())
            {
                connect.ConnectionString = connectString;
                string query = "INSERT INTO MyAppData.Order(cust_id,totalAmount,quantity,address) " +
                    "VALUES('" + ord.cust_id + "','" + ord.totalAmount + "','" + ord.quantity + "','" + ord.address + "');";
                using (MySqlCommand comma = new MySqlCommand(query, connect))
                {
                    try
                    {
                        comma.Connection.Open();

                        comma.Parameters.AddWithValue("@cust_id", ord.cust_id);
                        comma.Parameters.AddWithValue("@totalAmount", ord.totalAmount);
                        comma.Parameters.AddWithValue("@quantity", ord.quantity);
                        comma.Parameters.AddWithValue("@address", ord.address);
                        int y = comma.ExecuteNonQuery();

                        x = y.ToString();

                    }
                    catch (MySqlException ex)
                    {
                        ex.ToString();
                        comma.Connection.Close();
                    }
                }
                return null;
            }
        }

        //Gettuing all the products from the database

        public Product[] GetProduct()
        {
            List<Product> restaurants = new List<Product>();

            using (MySqlConnection connect = new MySqlConnection())
            {
                connect.ConnectionString = connectString;

                string querys = "SELECT prodId,ProdName,ProdpPrice,Image FROM MyAppData.Products;";
                using (MySqlCommand comma = new MySqlCommand(querys, connect))
                {
                    try
                    {
                        comma.Connection.Open();
                        Product prod = new Product();

                        read = comma.ExecuteReader();
                        while (read.Read())
                        {
                            prod = new Product(Convert.ToInt32(read["prodId"]),
                                                Convert.ToString(read["ProdName"]),
                                                Convert.ToString(read["ProdpPrice"]),
                                                 (byte[])(read["Image"])

                                               );
                            restaurants.Add(prod);

                        }
                        read.Close();
                        MySqlDataReader reader = comma.ExecuteReader(System.Data.CommandBehavior.SingleRow);
                        reader.Read();
                        reader.Close();
                    }
                    catch (MySqlException ex)
                    {
                        ex.ToString();
                    }
                    finally
                    {
                        comma.Connection.Close();
                    }
                }
                return restaurants.ToArray();
            }

        }

    }
}
