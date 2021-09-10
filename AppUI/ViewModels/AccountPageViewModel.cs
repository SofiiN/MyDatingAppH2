using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyDatingAppH2.Models;
using MyDatingAppH2;


namespace MyDatingAppH2.ViewModels
{
    class AccountPageViewModel : BindableBase
    {
        private Account account;
        private string errorMessage;

        public string Email
        {
            get { return account.email; }
            set
            {
                account.email = value;
                this.OnPropertyChanged();
            }
        }

        public string Password
        {
            get { return account.password; }
            set
            {
                account.password = value;
                this.OnPropertyChanged();
            }
        }

        public string ErrorMessage
        {
            get { return this.errorMessage; }
            set
            {
                this.errorMessage = value;
                this.OnPropertyChanged();
            }
        }

        public AccountPageViewModel()
        {
            account = new Account();
        }

        public bool IsUserValid()
        {
            if (SQLCom.CheckLoginInput(account.email, account.password))
            {
                ErrorMessage = string.Empty;

                return true;
            }

            ErrorMessage = "Incorrect email or password";

            return false;
        }
    }
}
