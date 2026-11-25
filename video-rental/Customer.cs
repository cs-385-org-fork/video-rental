using System;

namespace video_rental
{
    internal class Customer
    {
        public int customerID;
        public string firstName;
        public string lastName;
        public string email;
        public string phoneNumber;
        public string address;
        public int CustomerID
        {
            get { return customerID; }
            set { customerID = value; }
        }
        public string FirstName
        {
            get { return firstName; }
            set { firstName = value; }
        }
        public string LastName
        {
            get { return lastName; }
            set { lastName = value; }
        }
        public string Email
        {
            get { return email; }
            set { email = value; }
        }
        public string PhoneNumber
        {
            get { return phoneNumber; }
            set { phoneNumber = value; }
        }
        public string Address
        {
            get { return address; }
            set { address = value; }
        }
    }
}