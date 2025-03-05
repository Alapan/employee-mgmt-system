using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagementSystem.HR
{
    class Utilities
    {
        private static string directory = "C:\\Users\\Admin\\source\\repos\\EmployeeManagementSystem\\";
        private static string fileName = "employees.txt";

        public static void registerEmployee(List<Employee> employees) {
            Console.WriteLine("Enter the first name: ");
            string firstName = Console.ReadLine();
            Console.WriteLine("Enter the last name: ");
            string lastName = Console.ReadLine();
            Console.WriteLine("Enter the email: ");
            string emailAddress = Console.ReadLine();
            Console.WriteLine("Enter the street name: ");
            string streetName = Console.ReadLine();
            Console.WriteLine("Enter the zip code: ");
            string zipCode = Console.ReadLine();
            Console.WriteLine("Enter the city name: ");
            string city = Console.ReadLine();

            employees.Add(new Employee(firstName, lastName, emailAddress, streetName, zipCode, city, 20));
            Console.WriteLine("Added 1 employee");
        }

        public static void displayEmployees(List<Employee> employees) {
            Console.WriteLine("List of employees: ");
            foreach (Employee e in employees) {
                Console.WriteLine("First name: {0}", e.FirstName);
                Console.WriteLine("Last name: {0}", e.LastName);
                Console.WriteLine("Email: {0}", e.Email);
                Console.WriteLine($"Address: {e.Address.StreetName}, {e.Address.ZipCode} {e.Address.City}");
                Console.WriteLine("\n");
            }
        }

        public static void saveEmployee(List<Employee> employees) {
            try
            {
                string path = $"{directory}{fileName}";
                StringBuilder sb = new StringBuilder();
                foreach (Employee e in employees)
                {
                    sb.Append($"First name: {e.FirstName};");
                    sb.Append($"Last name: {e.LastName};");
                    sb.Append($"Email: {e.Email};");
                    sb.Append($"Address: {e.Address.StreetName}, {e.Address.ZipCode} {e.Address.City};");
                    sb.Append($"Hourly rate: {e.HourlyRate}");
                    sb.Append(Environment.NewLine);
                }
                File.WriteAllText(path, sb.ToString());
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Saved employees successfully!");
            }
            catch (Exception ex)
            {
                Console.BackgroundColor = ConsoleColor.Red;
                Console.WriteLine("Something went wrong when writing to the file!");
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
            }
            finally
            {
                Console.ResetColor();
            }
        }

        public static void loadEmployees(List<Employee> employees) {
            employees.Clear();
            string path = $"{directory}{fileName}";
            try
            {
                if (File.Exists(path))
                {
                    string[] employeesAsString = File.ReadAllLines(path);

                    for (int i = 0; i < employeesAsString.Length; i++)
                    {
                        string[] employeesSplits = employeesAsString[i].Split(";");
                        string firstName = employeesSplits[0].Substring(employeesSplits[0].IndexOf(":") + 1);
                        string lastName = employeesSplits[1].Substring(employeesSplits[1].IndexOf(":") + 1);
                        string email = employeesSplits[2].Substring(employeesSplits[2].IndexOf(":") + 1);
                        string address = employeesSplits[3].Substring(employeesSplits[3].IndexOf(":") + 1);
                        double hourlyRate = double.Parse(employeesSplits[4].Substring(employeesSplits[4].IndexOf(":") + 1));

                        string streetName = address.Split(",")[0];
                        string zipCode = address.Split(",")[1].Split(" ")[0];
                        string city = address.Split(",")[1].Split(" ")[1];

                        employees.Add(new Employee(firstName, lastName, email, streetName, zipCode, city, hourlyRate));
                    }

                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Loaded employees successfully!. Loaded employees:");
                    Console.ResetColor();
                    foreach (Employee employee in employees)
                    {
                        employee.displayEmployeeDetails();
                    }
                }
            }
            catch (FileNotFoundException fnfex)
            {   
                Console.BackgroundColor = ConsoleColor.Red;
                Console.WriteLine("File not found!");
                Console.WriteLine(fnfex.Message);
                Console.WriteLine(fnfex.StackTrace);
            }
            catch (IndexOutOfRangeException iex)
            {
                Console.BackgroundColor = ConsoleColor.Red;
                Console.WriteLine("When parsing the file, an index was not accessible!");
                Console.WriteLine(iex.Message);
                Console.WriteLine(iex.StackTrace);
            }
            catch (Exception ex)
            {
                Console.BackgroundColor = ConsoleColor.Red;
                Console.WriteLine("Something went wrong when loading the file!");
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
            }
            finally
            {
                Console.ResetColor();
            }

        }

        internal static void loadEmployeeById(List<Employee> employees)
        {
            try
            {
                Console.WriteLine("Enter the ID you want to view: ");
                int selectedId = int.Parse(Console.ReadLine());
                Employee employee = employees[selectedId];
                employee.displayEmployeeDetails();
            }
            catch (FormatException fex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("The entered ID is not in the right format!");
                Console.WriteLine(fex.Message);
                Console.WriteLine(fex.StackTrace);
            }
            catch (ArgumentOutOfRangeException aorex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("The ID entered is out of range!");
                Console.WriteLine(aorex.Message);
                Console.WriteLine(aorex.StackTrace);
            }
            catch (Exception ex)
            {
                Console.BackgroundColor = ConsoleColor.Red;
                Console.WriteLine("Error in loading employee details!");
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
            }
            finally
            {
                Console.ResetColor();
            }
        }
    }
}
