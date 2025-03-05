using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagementSystem.HR
{
    class Employee
    {
        private string firstName;
        private string lastName;
        private string email;
        private Address address;
        private double? hourlyRate;

        public string FirstName
        {
            get
            {
                return firstName;
            }

            set
            {
                firstName = value;
            }
        }

        public string LastName
        {
            get
            {
                return lastName;
            }

            set
            {
                lastName = value;
            }
        }

        public string Email
        {
            get
            {
                return email;
            }

            set
            {
                email = value;
            }
        }

        public Address Address
        {
            get
            {
                return address;
            }

            set
            {
                address = value;
            }
        }

        public double? HourlyRate
        {
            get
            {
                return hourlyRate;
            }

            set
            {
                if (hourlyRate < 0)
                {
                    hourlyRate = 0.0;
                }
                hourlyRate = value;
            }
        }

        public Employee(string firstName, string lastName, string email, string streetName, string zipCode, string city, double? hourlyRate)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Address = new Address(streetName, zipCode, city);
            HourlyRate = hourlyRate ?? 10;
        }

        public void displayEmployeeDetails()
        {
            Console.WriteLine($"First name: {FirstName}");
            Console.WriteLine($"Last name: {LastName}");
            Console.WriteLine($"Email:  {Email}");
            Console.WriteLine($"Address: {Address.StreetName}, {Address.ZipCode} {Address.City}");
            Console.WriteLine("\n");
        }

        public double calculateSalary(int numberOfHoursWorked)
        {
            double wage = (double)(numberOfHoursWorked * hourlyRate);
            return wage;
        }
    }
}
