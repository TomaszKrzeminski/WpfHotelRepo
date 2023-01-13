using CoreModule.Models;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreModule.ViewModels
{
    public class AddUserModel:BindableBase
    {
        public AddUserModel()
        {

        }

        public AddUserModel(User user)
        {
            UserID = user.UserID;
            FirstName = user.FirstName;
            
            LastName = user.LastName;
           
            City = user.City;
           
            Street = user.Street;
            
            HouseNumber = user.HouseNumber;
           
            PostalCode = user.PostalCode;
           
            PersonalNumber = user.PersonalNumber;
        }

        private int userID;
        public int UserID
        {
            get { return userID; }
            set { SetProperty(ref userID, value); }
        }


        private string firstName;
        public string FirstName
        {
            get { return firstName; }
            set { SetProperty(ref firstName, value); }
        }

        private string lastName;

        public string LastName
        {
            get { return lastName; }
            set { lastName = value; }
        }

        private string city;
        public string City
        {
            get { return city; }
            set { SetProperty(ref city, value); }
        }
        private string street;
        public string Street
        {
            get { return street; }
            set { SetProperty(ref street, value); }
        }

        private string houseNumber;
        public string HouseNumber
        {
            get { return houseNumber; }
            set { SetProperty(ref houseNumber, value); }
        }
        private string postalCode;
        public string PostalCode
        {
            get { return postalCode; }
            set { SetProperty(ref postalCode, value); }
        }
        private string personalNumber;
        public string PersonalNumber
        {
            get { return personalNumber; }
            set { SetProperty(ref personalNumber, value);  }
        }
      
    }
}
