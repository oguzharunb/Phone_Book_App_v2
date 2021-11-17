using System;
using System.Collections.Generic;
using System.Text;

namespace Phone_Book_App_v2
{
    public class Person
    {
        public string firstName;
        public string lastName;
        public string phoneNumber;
        public string fullName;
        public GENDER gender;

        public Person(string firstname, string lastname, string phonenumber, GENDER gender)
        {
            this.firstName = firstname;
            this.lastName = lastname;
            this.phoneNumber = phonenumber;
            this.fullName = firstName + " " + lastName;
            this.gender = gender;
        }
    }

    public enum GENDER
    {
        Null,
        MALE,
        FEMALE
    }

}
