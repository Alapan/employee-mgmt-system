using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagementSystem.HR
{
    class Address
    {
        private string streetName;
        private string zipCode;
        private string city;

        public string StreetName
        {
            get
            {
                return streetName;
            }
            set
            {
                streetName = value;
            }
        }

        public string ZipCode
        {
            get
            {
                return zipCode;
            }

            set
            {
                zipCode = value;
            }
        }

        public string City
        {
            get
            {
                return city;
            }

            set
            {
                city = value;
            }
        }

        public Address(string streetName, string zipCode, string city)
        {
            StreetName = streetName;
            ZipCode = zipCode;
            City = city;
            StreetName = streetName;
            ZipCode = zipCode;
            City = city;
        }
    }
}
