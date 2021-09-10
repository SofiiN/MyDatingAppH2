using MyDatingAppH2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using MyDatingAppH2;

namespace MyDatingAppH2.ViewModels
{
    class ProfilePageViewModel : BindableBase
    {
        private Profile profile;
        private string email;
        private string firstName;
        private DateTimeOffset birthDate;
        private int height;
        //private string location;
        private string biography;
        //private int gender;
        private int minAge;
        private int maxAge;
        //private int interestGender;
        //private string interestLocation;

        public ProfilePageViewModel()
        {
            profile = new Profile();
        }

        public string Email
        {
            get { return this.email; }
            set
            {
                this.email = value;
                this.OnPropertyChanged();
            }
        }

        public string FirstName
        {
            // Lav tilsvarende til alle fælter i UI. Brug Text="{Binding FirstName, Mode=TwoWay}" til at binde.
            get { return this.firstName; }
            set
            {
                this.firstName = value;
                this.OnPropertyChanged();
            }
        }

        public DateTimeOffset BirthDate
        {
            get { return this.birthDate; }
            set
            {
                this.birthDate = value;
                this.OnPropertyChanged();
            }
        }
        public int Height
        {
            get { return this.height; }
            set
            {
                this.height = value;
                this.OnPropertyChanged();
            }
        }

        public string Biography
        {
            get { return this.biography; }
            set
            {
                this.biography = value;
                this.OnPropertyChanged();
            }
        }
        public int MinAge
        {
            get { return this.minAge; }
            set
            {
                this.minAge = value;
                this.OnPropertyChanged();
            }
        }
        public int MaxAge
        {
            get { return this.maxAge; }
            set
            {
                this.maxAge = value;
                this.OnPropertyChanged();
            }
        }
        //public string Location
        //{
        //    get { return this.location; }
        //    set
        //    {
        //        this.location = value;
        //        this.OnPropertyChanged();
        //    }
        //}


        public void HentData()
        {
            //Hent data fra sql database
            //Set alle propeties i profile.(firstname) variabler
        }


    }
}
