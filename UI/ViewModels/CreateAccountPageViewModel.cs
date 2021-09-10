using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyDatingAppH2;
using MyDatingAppH2.Models;

namespace MyDatingAppH2.ViewModels
{
    class CreateAccountPageViewModel : BindableBase
    {
        private Account account;
        private string errorMessage;

        public CreateAccountPageViewModel()
        {
            account = new Account();
        }

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
        public string RepeatPassword
        {
            get { return account.repeatPassword; }
            set
            {
                account.repeatPassword = value;
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
        public bool CreateAccountValid()
        {
            if (Account.CreateAccount(account.email, account.password, account.repeatPassword))
            {
                ErrorMessage = string.Empty;

                return true;
            }

            ErrorMessage = "Something went wrong. Email or password does not meet criteria.";

            return false;
        }
    }
}
