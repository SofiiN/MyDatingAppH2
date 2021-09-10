using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace MyDatingAppH2
{
    public class Profile
    {
        /* Properties */
        static DataSet CityList = new DataSet();

        public int profileID { get; set; }
        public string firstName { get; set; }
        public DateTimeOffset birthDate { get; set; }
        public int height { get; set; }
        public string location { get; set; }
        public string bio { get; set; }
        public int gender { get; set; }
        public DateTimeOffset interestAgeFrom { get; set; }
        public DateTimeOffset interestAgeTo { get; set; }
        public int interestGender { get; set; }
        public string interestLocation { get; set; }
        public static int accountID { get; set; }

        /* Methods */

        public void ValidateInfo(string BirthDate, int Location,
            string Bio, string AgeFrom, string AgeTo, int InterestLocation)
        {
            bool ready = BirthDateValidation(BirthDate);
            ready = BirthDateValidation(AgeFrom);
            ready = BirthDateValidation(AgeTo);
            ready = LocationValidation(Location);
            ready = LocationValidation(InterestLocation);

            ready = Bio.Length <= 500;

            if(ready)
            {
                Convert.ToDateTime(BirthDate);
            }
        }

        public bool BirthDateValidation(string BirthDate)
        {
            if (DateTime.TryParse(BirthDate, out DateTime result))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool LocationValidation(int PostalCode)
        {

            if (PostalCode.ToString().Length == 4)
            {
                return SQLCom.CheckLocation(PostalCode);
            }
            else
            {
                return false;
            }
        }

        public static object GetCities()
        {
            SqlConnection sqlCon = new SqlConnection(DataAccess.connection);

            try
            {
                if (sqlCon.State == System.Data.ConnectionState.Closed)
                    sqlCon.Open();

                string query = "SELECT city FROM cities";

                SqlDataAdapter dataAdp = new SqlDataAdapter(query, sqlCon);

                return dataAdp.Fill(CityList);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return "";
            }
            finally
            {
                sqlCon.Close();
            }
        }

        
    }
}
