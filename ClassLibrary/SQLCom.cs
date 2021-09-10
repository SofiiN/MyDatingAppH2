using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;

namespace MyDatingAppH2
{
    public class SQLCom
    {
        public static void NewAccountInsert (string Email, string Password)
        {
            SqlConnection sqlCon = new SqlConnection(DataAccess.connection);

            try
            {
                if (sqlCon.State == System.Data.ConnectionState.Closed)
                    sqlCon.Open();

                string query = "INSERT INTO account (Email, Password) VALUES (@Email, @Password)";

                SqlCommand sqlCmd = new SqlCommand(query, sqlCon);

                sqlCmd.Parameters.AddWithValue("@Email", Email);
                sqlCmd.Parameters.AddWithValue("@Password", Password);

                sqlCmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                sqlCon.Close();
            }
        }

        public static void EditPassword(string Password)
        {
            SqlConnection sqlCon = new SqlConnection(DataAccess.connection);

            try
            {
                if (sqlCon.State == System.Data.ConnectionState.Closed)
                    sqlCon.Open();

                string query = "INSERT INTO account (Password) VALUES (@Password)";

                SqlCommand sqlCmd = new SqlCommand(query, sqlCon);

                sqlCmd.Parameters.AddWithValue("@Password", Password);

                sqlCmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                sqlCon.Close();
            }
        }

        public static void EditEmail(string Email)
        {
            SqlConnection sqlCon = new SqlConnection(DataAccess.connection);

            try
            {
                if (sqlCon.State == System.Data.ConnectionState.Closed)
                    sqlCon.Open();

                string query = "INSERT INTO account (Email) VALUES (@Email)";

                SqlCommand sqlCmd = new SqlCommand(query, sqlCon);

                sqlCmd.Parameters.AddWithValue("@Email", Email);

                sqlCmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                sqlCon.Close();
            }
        }

        public static bool CheckEmailExistence (string Email)
        {
            SqlConnection sqlCon = new SqlConnection(DataAccess.connection);

            if (sqlCon.State == System.Data.ConnectionState.Closed)
                sqlCon.Open();

            string query = "SELECT * FROM account WHERE Email = (@Email)";

            SqlCommand sqlCmd = new SqlCommand(query, sqlCon);

            sqlCmd.Parameters.AddWithValue("@Email", Email);

            int count = Convert.ToInt32(sqlCmd.ExecuteScalar());
            
            if(count == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static void DeleteEmailFromDB (string Email)
        {
            SqlConnection sqlCon = new SqlConnection(DataAccess.connection);

            try
            {
                if (sqlCon.State == System.Data.ConnectionState.Closed)
                    sqlCon.Open();

                string query = "DELETE FROM account WHERE Email = (@Email)";

                SqlCommand sqlCmd = new SqlCommand(query, sqlCon);

                sqlCmd.Parameters.AddWithValue("@Email", Email);

                sqlCmd.ExecuteNonQuery();

                Console.WriteLine("Email was deleted");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Email was not deleted");
                Console.WriteLine(ex.Message);
            }
            finally
            {
                sqlCon.Close();
            }
        }

        public static bool CheckLoginInput(string Email, string Password)
        {
            SqlConnection sqlCon = new SqlConnection(DataAccess.connection);

            try
            {
                if (sqlCon.State == System.Data.ConnectionState.Closed)
                    sqlCon.Open();

                string query = "SELECT CAST(COUNT(*) AS BIT) FROM account WHERE Email = @Email AND Password = @Password";

                SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                
                sqlCmd.Parameters.AddWithValue("@Email", Email);
                sqlCmd.Parameters.AddWithValue("@Password", Password);

                int loginExists = Convert.ToInt32(sqlCmd.ExecuteScalar());
                
                if(loginExists == 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
            finally
            {
                sqlCon.Close();
            }
        }


        public static bool CheckLocation(int PostalCode)
        {
            SqlConnection sqlCon = new SqlConnection(DataAccess.connection);

            try
            {
                if (sqlCon.State == System.Data.ConnectionState.Closed)
                    sqlCon.Open();

                string query = "SELECT PostalCode FROM cities WHERE Postalcode = @PostalCode";

                SqlCommand sqlCmd = new SqlCommand(query, sqlCon);

                sqlCmd.Parameters.AddWithValue("@PostalCode", PostalCode);

                int val = Convert.ToInt32(sqlCmd.ExecuteScalar());

                if (val == PostalCode)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
            finally
            {
                sqlCon.Close();
            }


        }

        public void GetData(string Email)
        {
            SqlConnection sqlCon = new SqlConnection(DataAccess.connection);

            try
            {
                if (sqlCon.State == System.Data.ConnectionState.Closed)
                    sqlCon.Open();

                string query = "select * from [profile] where [profile].AccountID = ";

                SqlCommand sqlCmd = new SqlCommand(query, sqlCon);

                sqlCmd.Parameters.AddWithValue("@Email", Email);

                sqlCmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                sqlCon.Close();
            }
        }
    }
}
