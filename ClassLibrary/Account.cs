using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Text;
using System.Text.RegularExpressions;

namespace MyDatingAppH2
{
    public class Account
    {
        /* Properties */

        public int accountID { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public string repeatPassword { get; set; }

        /* Methods */

        public static bool CreateAccount(string Email, string Password, string RepeatPassword)
        {

            //Validates if email is valid. Must include @ and a valid top level domain.

            var emailAddr = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");

            // Validates input email

            Email.ToLower();

            bool emailValid = emailAddr.IsMatch(Email);

            emailValid = SQLCom.CheckEmailExistence(Email);

            // Password must contain at least a number
            // Contain one upper case letter
            // Atleast 8 characters long

            var hasNumber = new Regex(@"[0-9]+");
            var hasUpperChar = new Regex(@"[A-Z]+");
            var hasMinimum8Chars = new Regex(@".{8,}");

            // Validates input password

            bool passwordValid = hasNumber.IsMatch(Password) && hasUpperChar.IsMatch(Password) && 
                hasMinimum8Chars.IsMatch(Password) && Password == RepeatPassword;

            if (emailValid && passwordValid)
            {
                InsertIntoDatabase(Email, Password);
                return true;
            }
            else
            {
                return false;
            }
        }

        private static void InsertIntoDatabase(string Email, string Password)
        {
            SQLCom.NewAccountInsert(Email, Password);
        }

        public static bool LogIn(string Email, string Password)
        {
            return SQLCom.CheckLoginInput(Email, Password);
        }

        public void ChangeEmail(string Email)
        {
            var emailAddr = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");

            // Validates input email

            bool emailValid = emailAddr.IsMatch(Email);

            emailValid = SQLCom.CheckEmailExistence(Email);

            if (emailValid)
            {
                SQLCom.EditEmail(Email);
                SQLCom.DeleteEmailFromDB(this.email);
            }
        }

        public void ChangePassword(string Password, string RepeatPassword)
        {
            var hasNumber = new Regex(@"[0-9]+");
            var hasUpperChar = new Regex(@"[A-Z]+");
            var hasMinimum8Chars = new Regex(@".{8,}");

            bool passwordIsValid = hasNumber.IsMatch(Password) && hasUpperChar.IsMatch(Password) &&
                    hasMinimum8Chars.IsMatch(Password) && Password == RepeatPassword;

            if (passwordIsValid) 
            {
                SQLCom.EditPassword(Password);
            }
            else
            {
                Console.WriteLine("Passwords does not match or does not meet requiments");
            }
        }

        public static ObservableCollection<Account> GetAccounts()
        {
            const string GetContactQuery = "select AccountID, Email from Account";

            var accounts = new ObservableCollection<Account>();
            try
            {
                using (SqlConnection conn = new SqlConnection(DataAccess.connection))
                {
                    conn.Open();
                    if (conn.State == System.Data.ConnectionState.Open)
                    {
                        using (SqlCommand cmd = conn.CreateCommand())
                        {
                            cmd.CommandText = GetContactQuery;
                            using (SqlDataReader reader = cmd.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    var account = new Account();
                                    account.accountID = reader.GetInt32(0);
                                    account.email = reader.GetString(1);
                                    accounts.Add(account);
                                }
                            }
                        }
                    }
                }
                return accounts;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return null;
        }
    }
}
