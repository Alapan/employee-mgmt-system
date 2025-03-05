using EmployeeManagementSystem.HR;


Console.WriteLine("********************************");
Console.WriteLine("** Employee Management System **");
Console.WriteLine("********************************");

List<Employee> employees = new List<Employee>();
int selectedChoice;

do
{
    Console.WriteLine("Enter a number from the list below:");
    Console.WriteLine("1: Register an employee");
    Console.WriteLine("2: View all employees");
    Console.WriteLine("3: Save employees");
    Console.WriteLine("4: Load employees");
    Console.WriteLine("5: View employee by ID");
    Console.WriteLine("9: Exit");

    selectedChoice = int.Parse(Console.ReadLine());

    switch (selectedChoice)
    {
        case 1:
            Utilities.registerEmployee(employees);
            break;
        case 2:
            Utilities.displayEmployees(employees);
            break;
        case 3:
            Utilities.saveEmployee(employees);
            break;
        case 4:
            Utilities.loadEmployees(employees);
            break;
        case 5:
            Utilities.loadEmployeeById(employees);
            break;
        case 9:
            break;
        default:
            Console.WriteLine("This is an invalid selection, try again!");
            break;
    } 
} while (selectedChoice != 9);
