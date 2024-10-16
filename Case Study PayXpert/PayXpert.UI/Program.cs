using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PayXpert.DataAccessLayer;
using System.Data.SqlClient;
using PayXpert.Entity;
using PayXpert.BusinessLayer;
using PayXpert.BusinessLayer.Repository;
using PayXpert.BusinessLayer.Service;
using PayXpert.Exception;
using System.Runtime.InteropServices.ComTypes;

namespace PayXpert.UI
{
    internal class Program
    {
        static void Main(string[] args)
        {

            //step 2- check Connection
            /*
            try
            {
                SqlConnection conn = DBUtil.getDBConnection();
                //conn.Open();
                Console.WriteLine("Database Connected SuccessFully");
                conn.Close();
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }*/

            bool exit = false;

            while (!exit)
            {
                Console.WriteLine("-----------PayXpert - Payroll Management System-------------");
                Console.WriteLine("");
                Console.WriteLine("Main Menu");
                Console.WriteLine("1. Employee Details");
                Console.WriteLine("2. Financial Record Details");
                Console.WriteLine("3. Payroll Details");
                Console.WriteLine("4. Tax Details");
                Console.WriteLine("5. EXIT");
                Console.WriteLine("");
                Console.Write("Enter your Choice: ");

                int ch = Convert.ToInt32(Console.ReadLine());

                switch (ch)
                {
                    case 1:
                        bool employeeExit = false;
                        while (!employeeExit)
                        {
                            Console.WriteLine("-- Employee Operations  --");
                            Console.WriteLine("1. Get All Details");
                            Console.WriteLine("2. Get Details By Employee Id");
                            Console.WriteLine("3. Add New Employee Details");
                            Console.WriteLine("4. Update Employee Details");
                            Console.WriteLine("5. Remove Employee Details");
                            Console.WriteLine("6. Go To Main Menu");
                            Console.Write("Choose An Option: ");

                            int c1 = Convert.ToInt32(Console.ReadLine());

                            EmployeeRepository employeeRepository = new EmployeeRepository();
                            EmployeeService employeeService = new EmployeeService(employeeRepository);
                            Employee employee = new Employee();

                            switch (c1)
                            {
                                case 1:
                                    try
                                    {
                                        List<Employee> employees = employeeService.GetAllEmployees();
                                        if (employees != null && employees.Count > 0)
                                        {
                                            foreach (Employee employe in employees)
                                            {
                                                Console.WriteLine("------------- Employee Details -------------");
                                                Console.WriteLine($"ID: {employe.EmployeeID}");
                                                Console.WriteLine($"Name: {employe.Firstname} {employee.Lastname}");
                                                Console.WriteLine($"DOB: {employe.DOB.ToShortDateString()}");
                                                Console.WriteLine($"Gender: {employe.Gender}");
                                                Console.WriteLine($"Email: {employe.Email}");
                                                Console.WriteLine($"PhoneNumber: {employe.PhoneNumber}");
                                                Console.WriteLine($"Address: {employe.Address}");
                                                Console.WriteLine($"Position: {employe.Position}");
                                                Console.WriteLine($"Joining Date: {employe.JoiningDate.ToShortDateString()}");
                                                //Console.WriteLine($"Termination Date: {(employe.Termination.HasValue ? employee.Termination.Value.ToShortDateString() : "N/A")}");
                                                Console.WriteLine("------------------------------------------\n");
                                            }
                                        }
                                        else
                                        {
                                            throw new EmployeeNotFoundException($"Employees not found.");
                                        }
                                    }
                                    catch (DataBaseConnectionException dbEx)
                                    {
                                        Console.WriteLine(dbEx.Message);
                                    }
                                    catch (EmployeeNotFoundException ex)
                                    {
                                        Console.WriteLine(ex.Message);
                                    }

                                    Console.ReadKey();
                                    break;
                                case 2:
                                    Console.Write("Enter Employee Id: ");
                                    int id = Convert.ToInt32(Console.ReadLine());
                                    try
                                    {
                                        Employee employe = employeeService.GetEmployeeById(id);
                                        if (employe != null)
                                        {
                                            // Process the employee object
                                            Console.WriteLine($"ID: {employe.EmployeeID}");
                                            Console.WriteLine($"Name: {employe.Firstname} {employee.Lastname}");
                                            Console.WriteLine($"DOB: {employe.DOB.ToShortDateString()}");
                                            Console.WriteLine($"Gender: {employe.Gender}");
                                            Console.WriteLine($"Email: {employe.Email}");
                                            Console.WriteLine($"PhoneNumber: {employe.PhoneNumber}");
                                            Console.WriteLine($"Address: {employe.Address}");
                                            Console.WriteLine($"Position: {employe.Position}");
                                            Console.WriteLine($"Joining Date: {employe.JoiningDate.ToShortDateString()}");
                                            Console.WriteLine($"Termination Date: {(employe.Termination.HasValue ? employee.Termination.Value.ToShortDateString() : "N/A")}");
                                        }
                                        else
                                        {
                                            throw new EmployeeNotFoundException($"Employee with ID {id} was not found.");
                                        }
                                    }
                                    catch (DataBaseConnectionException dbEx)
                                    {
                                        Console.WriteLine(dbEx.Message);
                                    }
                                    catch (EmployeeNotFoundException ex)
                                    {
                                        Console.WriteLine(ex.Message);
                                    }

                                    Console.ReadKey();
                                    break;
                                case 3:
                                    try
                                    {
                                        //employeeService.AddEmployee(employee);
                                        Console.WriteLine("---Adding Details----");
                                        //Console.Write("Enter EmployeeId : ");
                                        //employee.EmployeeID=Convert.ToInt32(Console.ReadLine());
                                        employee.EmployeeID = 0;
                                        Console.Write("Enter FirstName : ");
                                        employee.Firstname = (Console.ReadLine());
                                        if (string.IsNullOrWhiteSpace(employee.Firstname))
                                        {
                                            throw new InvalidInputException("First Name cannot be empty.");
                                        }
                                        Console.Write("Enter LastName : ");
                                        employee.Lastname = (Console.ReadLine());
                                        if (string.IsNullOrWhiteSpace(employee.Lastname))
                                        {
                                            throw new InvalidInputException("Last Name cannot be empty.");
                                        }
                                        Console.Write("Enter DOB : ");
                                        employee.DOB = Convert.ToDateTime(Console.ReadLine());
                                        if (employee.DOB > DateTime.Now)
                                        {
                                            throw new InvalidInputException("Date of Birth cannot be in the future.");
                                        }
                                        Console.Write("Enter Gender : ");
                                        employee.Gender = Console.ReadLine();
                                        if (string.IsNullOrWhiteSpace(employee.Gender))
                                        {
                                            throw new InvalidInputException("Gender cannot be empty.");
                                        }
                                        Console.Write("Enter Email : ");
                                        employee.Email = Console.ReadLine();
                                        if (!employeeRepository.IsValidEmail(employee.Email))
                                        {
                                            throw new InvalidInputException("Invalid email format.");
                                        }
                                        Console.Write("Enter Phone Number : ");
                                        employee.PhoneNumber = Console.ReadLine();
                                        if (!employeeRepository.IsValidPhoneNumber(employee.PhoneNumber))
                                        {
                                            throw new InvalidInputException("Invalid phone number.");
                                        }
                                        Console.Write("Enter Address : ");
                                        employee.Address = Console.ReadLine();
                                        if (string.IsNullOrWhiteSpace(employee.Address))
                                        {
                                            throw new InvalidInputException("Address cannot be empty.");
                                        }
                                        Console.Write("Enter Position : ");
                                        employee.Position = Console.ReadLine();
                                        if (string.IsNullOrWhiteSpace(employee.Position))
                                        {
                                            throw new InvalidInputException("Position cannot be empty.");
                                        }
                                        Console.Write("Enter Joining Date (MM/DD/YYYY): ");
                                        string joiningDateInput = Console.ReadLine();
                                        if (!DateTime.TryParse(joiningDateInput, out DateTime joiningDate))
                                        {
                                            throw new InvalidInputException("Invalid Joining Date.");
                                        }
                                        employee.JoiningDate = joiningDate;

                                        Console.Write("Enter Termination Date (MM/DD/YYYY): ");
                                        string terminationDateInput = Console.ReadLine();
                                        if (!DateTime.TryParse(terminationDateInput, out DateTime terminationDate))
                                        {
                                            throw new InvalidInputException("Invalid Termination Date.");
                                        }
                                        employee.Termination = terminationDate;

                                        bool isAdded = employeeService.AddEmployee(employee);
                                        if (isAdded)
                                        {
                                            Console.WriteLine($"Employee with Employee Id {employee.EmployeeID} Added Successfully");
                                        }
                                        else
                                        {
                                            Console.WriteLine("Failed To Add Employee");
                                        }
                                    }
                                    catch (InvalidInputException ex)
                                    {
                                        Console.WriteLine($"Error: {ex.Message}");
                                    }
                                    catch (DataBaseConnectionException ex)
                                    {
                                        Console.WriteLine(ex.Message);
                                    }
                                    Console.ReadKey();
                                    break;

                                case 4:
                                    //employeeService.UpdateEmployee(employee);
                                    try
                                    {
                                        Console.WriteLine("---Updating Details----");
                                        Console.Write("Enter EmployeeId : ");
                                        employee.EmployeeID = Convert.ToInt32(Console.ReadLine());
                                        employee.EmployeeID = 0;
                                        Console.Write("Enter FirstName : ");
                                        employee.Firstname = (Console.ReadLine());
                                        if (string.IsNullOrWhiteSpace(employee.Firstname))
                                        {
                                            throw new InvalidInputException("First Name cannot be empty.");
                                        }
                                        Console.Write("Enter LastName : ");
                                        employee.Lastname = (Console.ReadLine());
                                        if (string.IsNullOrWhiteSpace(employee.Lastname))
                                        {
                                            throw new InvalidInputException("Last Name cannot be empty.");
                                        }
                                        Console.Write("Enter DOB : ");
                                        employee.DOB = Convert.ToDateTime(Console.ReadLine());
                                        if (employee.DOB > DateTime.Now)
                                        {
                                            throw new InvalidInputException("Date of Birth cannot be in the future.");
                                        }
                                        Console.Write("Enter Gender : ");
                                        employee.Gender = Console.ReadLine();
                                        if (string.IsNullOrWhiteSpace(employee.Gender))
                                        {
                                            throw new InvalidInputException("Gender cannot be empty.");
                                        }
                                        Console.Write("Enter Email : ");
                                        employee.Email = Console.ReadLine();
                                        if (!employeeRepository.IsValidEmail(employee.Email))
                                        {
                                            throw new InvalidInputException("Invalid email format.");
                                        }
                                        Console.Write("Enter Phone Number : ");
                                        employee.PhoneNumber = Console.ReadLine();
                                        if (!employeeRepository.IsValidPhoneNumber(employee.PhoneNumber))
                                        {
                                            throw new InvalidInputException("Invalid phone number.");
                                        }
                                        Console.Write("Enter Address : ");
                                        employee.Address = Console.ReadLine();
                                        if (string.IsNullOrWhiteSpace(employee.Address))
                                        {
                                            throw new InvalidInputException("Address cannot be empty.");
                                        }
                                        Console.Write("Enter Position : ");
                                        employee.Position = Console.ReadLine();
                                        if (string.IsNullOrWhiteSpace(employee.Position))
                                        {
                                            throw new InvalidInputException("Position cannot be empty.");
                                        }
                                        Console.Write("Enter Joining Date (MM/DD/YYYY): ");
                                        string joiningDateInput = Console.ReadLine();
                                        if (!DateTime.TryParse(joiningDateInput, out DateTime joiningDate))
                                        {
                                            throw new InvalidInputException("Invalid Joining Date.");
                                        }
                                        employee.JoiningDate = joiningDate;

                                        Console.Write("Enter Termination Date (MM/DD/YYYY): ");
                                        string terminationDateInput = Console.ReadLine();
                                        if (!DateTime.TryParse(terminationDateInput, out DateTime terminationDate))
                                        {
                                            throw new InvalidInputException("Invalid Termination Date.");
                                        }
                                        employee.Termination = terminationDate;

                                        bool isUpdated = employeeService.UpdateEmployee(employee);
                                        if (isUpdated)
                                        {
                                            Console.WriteLine("Employee Updated Successfully ");
                                        }
                                        else
                                        {
                                            throw new EmployeeNotFoundException($"Employee with ID {employee.EmployeeID} was not found. Updation Failed");
                                        }
                                    }
                                    catch (InvalidInputException ex)
                                    {
                                        Console.WriteLine($"Error: {ex.Message}");
                                    }
                                    catch (EmployeeNotFoundException ex)
                                    {
                                        Console.WriteLine(ex.Message);
                                    }
                                    Console.ReadKey();
                                    break;
                                case 5:
                                    Console.Write("Enter Employee Id: ");
                                    int removeId = Convert.ToInt32(Console.ReadLine());
                                    try 
                                    {
                                        bool isRemoved = employeeService.RemoveEmployee(removeId);
                                        if (isRemoved)
                                        {
                                            Console.WriteLine($"Employee With ID {removeId} Removed Sucessfully  ");
                                        }
                                        else
                                        {
                                            throw new EmployeeNotFoundException($"Employee with ID {removeId} was not found. Updation Failed");
                                        }

                                    }
                                    catch (EmployeeNotFoundException ex)
                                    {
                                        Console.WriteLine(ex.Message);
                                    }
                                    catch (DataBaseConnectionException ex)
                                    {
                                        Console.WriteLine(ex.Message);
                                    }
                                    Console.ReadKey();
                                    break;
                                case 6:
                                    employeeExit = true; // Exit to the main menu
                                    break;
                                default:
                                    Console.WriteLine("Invalid option, please try again.");
                                    break;
                            }
                        }
                        break;

                    case 2:
                        bool financialExit = false;
                        while (!financialExit)
                        {
                            Console.WriteLine("-- Financial Record Operations  --");
                            Console.WriteLine("1. Get Details By Employee Id");
                            Console.WriteLine("2. Get Details By Record Date");
                            Console.WriteLine("3. Add New Financial Record");
                            Console.WriteLine("4. Get Details By Record Id");
                            Console.WriteLine("5. Go To Main Menu");
                            Console.Write("Choose An Option: ");

                            int c2 = Convert.ToInt32(Console.ReadLine());

                            FinancialRecordRepository financialRecordRepository = new FinancialRecordRepository();
                            FinancialRecordService financialRecordService = new FinancialRecordService(financialRecordRepository);

                            switch (c2)
                            {
                                case 1:
                                    Console.Write("Enter Employee Id: ");
                                    int id = Convert.ToInt32(Console.ReadLine());
                                    try
                                    {
                                        FinancialRecord record = financialRecordService.GetFinancialRecordsForEmployee(id);
                                        if (record != null)
                                        {
                                            Console.WriteLine("RecordId : " + record.RecordId);
                                            Console.WriteLine("EmployeeID  : " + record.EmployeeID);
                                            Console.WriteLine("RecordDate  : " + record.RecordDate);
                                            Console.WriteLine("Description  : " + record.Description);
                                            Console.WriteLine("Amount  : " + record.Amount);
                                            Console.WriteLine("RecordType  : " + record.RecordType);
                                        }
                                        else
                                        {
                                            throw new FinancialRecordException($"Financial Record  with Employee Id {id} was not found");
                                        }
                                    }
                                    catch (FinancialRecordException ex)
                                    {
                                        Console.WriteLine(ex.Message);
                                    }
                                    catch (DataBaseConnectionException ex)
                                    {
                                        Console.WriteLine(ex.Message);
                                    }
                                    Console.ReadKey();
                                    break;
                                case 2:
                                    Console.Write("Enter Record Date :  ");
                                    string recDate= Console.ReadLine();
                                    try
                                    {
                                        FinancialRecord record = financialRecordService.GetFinancialRecordsForDate(Convert.ToDateTime($"{recDate}"));
                                        if (record != null)
                                        {
                                            Console.WriteLine("RecordId : " + record.RecordId);
                                            Console.WriteLine("EmployeeID  : " + record.EmployeeID);
                                            Console.WriteLine("RecordDate  : " + record.RecordDate);
                                            Console.WriteLine("Description  : " + record.Description);
                                            Console.WriteLine("Amount  : " + record.Amount);
                                            Console.WriteLine("RecordType  : " + record.RecordType);
                                        }
                                        else
                                        {
                                            throw new FinancialRecordException($"Financial Record  with Record Date {recDate} was not found");
                                        }
                                    }
                                    catch (FinancialRecordException ex)
                                    {
                                        Console.WriteLine(ex.Message);
                                    }
                                    catch (DataBaseConnectionException ex)
                                    {
                                        Console.WriteLine(ex.Message);
                                    }
                                    Console.ReadKey();
                                    break;
                                case 3:
                                    Console.Write("Enter Employee Id : ");
                                    int Id= Convert.ToInt32(Console.ReadLine());
                                    Console.Write("Enter Record Description : ");
                                    string desc=Console.ReadLine();
                                    Console.Write("Enter Amount : ");
                                    decimal amt =Convert.ToDecimal( Console.ReadLine());
                                    Console.Write("Enter Record Type : ");
                                    string recType=Console.ReadLine();
                                    try
                                    {
                                        bool isSuccess = financialRecordService.AddFinancialRecord(Id, desc, amt, recType);

                                        if (isSuccess)
                                        {
                                            Console.WriteLine("Financial record added successfully.");
                                        }
                                        else
                                        {
                                            Console.WriteLine("Error adding financial record.");
                                        }

                                    }
                                    catch (DataBaseConnectionException ex)
                                    {
                                        Console.WriteLine(ex.Message);
                                    }
                                    Console.ReadKey();
                                    break;
                                case 4:
                                    Console.Write("Enter Record Id : ");
                                    int ID = Convert.ToInt32(Console.ReadLine());
                                    try
                                    {
                                        FinancialRecord record = financialRecordService.GetFinancialRecordById(ID);

                                        if (record != null)
                                        {
                                            Console.WriteLine("RecordId : " + record.RecordId);
                                            Console.WriteLine("EmployeeID  : " + record.EmployeeID);
                                            Console.WriteLine("RecordDate  : " + record.RecordDate);
                                            Console.WriteLine("Description  : " + record.Description);
                                            Console.WriteLine("Amount  : " + record.Amount);
                                            Console.WriteLine("RecordType  : " + record.RecordType);
                                        }
                                        else
                                        {
                                            throw new FinancialRecordException($"Financial Record  with Record Id {ID} was not found");
                                        }
                                    }
                                    catch (FinancialRecordException ex)
                                    {
                                        Console.WriteLine(ex.Message);
                                    }
                                    catch (DataBaseConnectionException ex)
                                    {
                                        Console.WriteLine(ex.Message);
                                    }
                                    Console.ReadKey();
                                    break;
                                case 5:
                                    financialExit = true; // Exit to the main menu
                                    break;
                                default:
                                    Console.WriteLine("Invalid option, please try again.");
                                    break;
                            }
                        }
                        break;

                    case 3:
                        bool payrollExit = false;
                        while (!payrollExit)
                        {
                            Console.WriteLine("-- Payroll Operations  --");
                            Console.WriteLine("1. Generate New Payroll");
                            Console.WriteLine("2. Get Payroll By Payroll Id");
                            Console.WriteLine("3. Get Payroll By Employee Id");
                            Console.WriteLine("4. Get Payroll For Period");
                            Console.WriteLine("5. Go To Main Menu");
                            Console.Write("Choose An Option: ");

                            int c3 = Convert.ToInt32(Console.ReadLine());

                            PayrollRepository payrollRepository = new PayrollRepository();
                            PayrollService payrollService = new PayrollService(payrollRepository);

                            switch (c3)
                            {
                                case 1:
                                    try
                                    {
                                        Console.Write("Enter Payroll Id");
                                        int pId = Convert.ToInt32(Console.ReadLine());
                                        Console.Write("Enter Employee Id");
                                        int Id = Convert.ToInt32(Console.ReadLine());
                                        Console.Write("Enter Pay Period Start Date ");
                                        string sdate = Console.ReadLine();
                                        Console.Write("Enter Pay Period End Date ");
                                        string edate = Console.ReadLine();

                                        Payroll payroll = new Payroll();
                                        payroll.PayrollID = pId;
                                        payroll.EmployeeID = Id;
                                        payroll.PayPeriodStartDate = Convert.ToDateTime($"{sdate}");
                                        payroll.PayPeriodEndDate = Convert.ToDateTime($"{edate}");

                                        Console.Write("Enter Basic Salary : ");

                                        payroll.BasicSalary = Convert.ToDecimal(Console.ReadLine());

                                        Console.Write("Enter OverTime Pay : ");
                                        payroll.OverTimePay = Convert.ToDecimal(Console.ReadLine());

                                        Console.Write("Enter  Deductions : ");
                                        payroll.Deduction = Convert.ToDecimal(Console.ReadLine());

                                        payroll.Netsalary = (payroll.BasicSalary + payroll.OverTimePay) - payroll.Deduction;

                                        bool isPayrollGenerated = payrollService.GeneratePayroll(payroll);

                                        if (isPayrollGenerated)
                                        {
                                            Console.WriteLine("Payroll Generated Successfully");
                                        }
                                        else
                                        {
                                            Console.WriteLine("Failed To Add Employee");
                                        }

                                    }
                                    catch (DataBaseConnectionException ex)
                                    {
                                        Console.WriteLine(ex.Message);
                                    }

                                    Console.ReadKey();
                                    break;
                                case 2:
                                    Console.Write("Enter Payroll Id");
                                    int PId= Convert.ToInt32(Console.ReadLine());
                                    try
                                    {
                                        Payroll payroll = payrollService.GetPayrollById(PId);

                                        if (payroll != null)
                                        {
                                            Console.WriteLine("Payroll Id: " + payroll.PayrollID);
                                            Console.WriteLine("Employee Id: " + payroll.EmployeeID);
                                            Console.WriteLine("PayPeriodStartDate: " + payroll.PayPeriodStartDate);
                                            Console.WriteLine("PayPeriodEndDate : " + payroll.PayPeriodEndDate);
                                            Console.WriteLine("BasicSalary : " + payroll.BasicSalary);
                                            Console.WriteLine("OverTimePay : " + payroll.OverTimePay);
                                            Console.WriteLine("Deduction : " + payroll.Deduction);
                                            Console.WriteLine("Netsalary : " + payroll.Netsalary);
                                        }
                                        else
                                        {
                                            throw new PayrollGenerationException("Payroll not fuound");
                                        }

                                    }
                                    catch (DataBaseConnectionException ex)
                                    {
                                        Console.WriteLine(ex.Message);
                                    }
                                    catch (PayrollGenerationException ex)
                                    {
                                        Console.WriteLine(ex.Message);
                                    }
                                    Console.ReadKey();
                                    break;
                                case 3:
                                    Console.Write("Enter Employee Id");
                                    int eId = Convert.ToInt32(Console.ReadLine());

                                    try
                                    {
                                        List<Payroll> payrolls = payrollService.GetPayrollsForEmployee(eId);

                                        if (payrolls != null && payrolls.Count > 0)
                                        {
                                            foreach (var payroll in payrolls)
                                            {
                                                Console.WriteLine("Payroll Id: " + payroll.PayrollID);
                                                Console.WriteLine("Employee Id: " + payroll.EmployeeID);
                                                Console.WriteLine("PayPeriodStartDate: " + payroll.PayPeriodStartDate);
                                                Console.WriteLine("PayPeriodEndDate : " + payroll.PayPeriodEndDate);
                                                Console.WriteLine("BasicSalary : " + payroll.BasicSalary);
                                                Console.WriteLine("OverTimePay : " + payroll.OverTimePay);
                                                Console.WriteLine("Deduction : " + payroll.Deduction);
                                                Console.WriteLine("Netsalary : " + payroll.Netsalary);
                                            }
                                        }
                                        else
                                        {
                                            throw new PayrollGenerationException("Payroll not fuound");
                                        }

                                    }
                                    catch (PayrollGenerationException ex)
                                    {
                                        Console.WriteLine(ex.Message);
                                    }
                                    catch (DataBaseConnectionException ex)
                                    {
                                        Console.WriteLine(ex.Message);
                                    }
                                    Console.ReadKey();
                                    break;
                                case 4:
                                    Console.Write("Enter Pay Period Start Date ");
                                    string Sdate = Console.ReadLine();
                                    Console.Write("Enter Pay Period End Date ");
                                    string Edate = Console.ReadLine();

                                    try
                                    {
                                        List<Payroll> payrolls = payrollService.GetPayrollsForPeriod(Convert.ToDateTime($"{Sdate}"), Convert.ToDateTime($"{Edate}"));
                                        Console.ReadKey();

                                        if (payrolls != null && payrolls.Count > 0)
                                        {
                                            foreach (var payroll in payrolls)
                                            {
                                                Console.WriteLine("Payroll Id: " + payroll.PayrollID);
                                                Console.WriteLine("Employee Id: " + payroll.EmployeeID);
                                                Console.WriteLine("PayPeriodStartDate: " + payroll.PayPeriodStartDate);
                                                Console.WriteLine("PayPeriodEndDate : " + payroll.PayPeriodEndDate);
                                                Console.WriteLine("BasicSalary : " + payroll.BasicSalary);
                                                Console.WriteLine("OverTimePay : " + payroll.OverTimePay);
                                                Console.WriteLine("Deduction : " + payroll.Deduction);
                                                Console.WriteLine("Netsalary : " + payroll.Netsalary);
                                            }
                                        }
                                        else
                                        {
                                            throw new PayrollGenerationException("Payroll not found");
                                        }

                                    }
                                    catch (PayrollGenerationException ex)
                                    {
                                        Console.WriteLine(ex.Message);
                                    }
                                    catch (DataBaseConnectionException ex)
                                    {
                                        Console.WriteLine(ex.Message);
                                    }
                                    payrollService.GetPayrollsForPeriod(Convert.ToDateTime($"{Sdate}"), Convert.ToDateTime($"{Edate}"));
                                    Console.ReadKey();
                                    break;
                                case 5:
                                    payrollExit = true; // Exit to the main menu
                                    break;
                                default:
                                    Console.WriteLine("Invalid option, please try again.");
                                    break;
                            }
                        }
                        break;

                    case 4:
                        bool taxExit = false;
                        while (!taxExit)
                        {
                            Console.WriteLine("-- Tax Operations  --");
                            Console.WriteLine("1. Calculate and Update Tax");
                            Console.WriteLine("2. Get Tax Details By Tax Id");
                            Console.WriteLine("3. Get Tax Details By Employee Id");
                            Console.WriteLine("4. Get Tax Details For Period");
                            Console.WriteLine("5. Go To Main Menu");
                            Console.Write("Choose An Option: ");

                            int c4 = Convert.ToInt32(Console.ReadLine());

                            TaxRepository taxRepository = new TaxRepository();
                            TaxService taxService = new TaxService(taxRepository);

                            switch (c4)
                            {
                                case 1:
                                    Console.Write("Enter Employee Id: ");
                                    int eid= Convert.ToInt32(Console.ReadLine());
                                    Console.Write("Enter Tax Year : ");
                                    int tdate= Convert.ToInt32(Console.ReadLine());
                                    decimal taxAmount;
                                    try
                                    {
                                        taxAmount = taxService.CalculateTax(eid, tdate);
                                        Console.WriteLine($"Calculated Tax Amount: {taxAmount}");
                                    }
                                    catch (TaxCalculationException ex)
                                    {
                                        Console.WriteLine(ex.Message);

                                    }
                                    catch (SqlException ex)
                                    {
                                        Console.WriteLine("Error executing query: " + ex.Message);
                                    }
                                    catch (DataBaseConnectionException ex)
                                    {
                                        Console.WriteLine(ex.Message);
                                    }

                                    Console.ReadKey();
                                    break;
                                case 2:
                                    Console.Write("Enter Tax Id : ");
                                    int tId = Convert.ToInt32(Console.ReadLine());
                                    try
                                    {
                                        Tax tax = taxService.GetTaxById(tId);
                                        if (tax!=null)
                                        {
                                            Console.WriteLine("Tax ID : " + tax.TaxID);
                                            Console.WriteLine("EmployeeID  : " + tax.EmployeeID);
                                            Console.WriteLine("TaxYear  : " + tax.TaxYear);
                                            Console.WriteLine("TaxableIncome  : " + tax.TaxableIncome);
                                            Console.WriteLine("TaxAmount  : " + tax.TaxAmount);
                                        }
                                        else
                                        {
                                            throw new EmployeeNotFoundException($"Employee with TaxID {tId} was not found.");

                                        }

                                    }
                                    catch (EmployeeNotFoundException ex)
                                    {
                                        Console.WriteLine(ex.Message);

                                    }
                                    catch (SqlException ex)
                                    {
                                        Console.WriteLine("Error executing query: " + ex.Message);
                                    }
                                    catch (DataBaseConnectionException ex)
                                    {
                                        Console.WriteLine(ex.Message);
                                    }
                                    taxService.GetTaxById(tId);
                                    Console.ReadKey();
                                    break;
                                case 3:
                                    Console.Write("Enter Employee Id : ");
                                    int EId = Convert.ToInt32(Console.ReadLine());
                                    try
                                    {
                                        Tax tax = taxService.GetTaxesForEmployee(EId);
                                        if (tax != null)
                                        {
                                            Console.WriteLine("Tax ID : " + tax.TaxID);
                                            Console.WriteLine("EmployeeID  : " + tax.EmployeeID);
                                            Console.WriteLine("TaxYear  : " + tax.TaxYear);
                                            Console.WriteLine("TaxableIncome  : " + tax.TaxableIncome);
                                            Console.WriteLine("TaxAmount  : " + tax.TaxAmount);
                                        }
                                        else
                                        {
                                            throw new EmployeeNotFoundException($"Employee with Employee Id {EId} was not found.");

                                        }
                                    }
                                    catch (EmployeeNotFoundException ex)
                                    {
                                        Console.WriteLine(ex.Message);

                                    }
                                    catch (SqlException ex)
                                    {
                                        Console.WriteLine("Error executing query: " + ex.Message);
                                    }
                                    catch (DataBaseConnectionException ex)
                                    {
                                        Console.WriteLine(ex.Message);
                                    }
                                    Console.ReadKey();
                                    break;
                                case 4:
                                    Console.Write("Enter Tax Year : ");
                                    int yr = Convert.ToInt32(Console.ReadLine());
                                    try
                                    {
                                        Tax tax = taxService.GetTaxesForYear(yr);
                                        if (tax != null)
                                        {
                                            Console.WriteLine("Tax ID : " + tax.TaxID);
                                            Console.WriteLine("EmployeeID  : " + tax.EmployeeID);
                                            Console.WriteLine("TaxYear  : " + tax.TaxYear);
                                            Console.WriteLine("TaxableIncome  : " + tax.TaxableIncome);
                                            Console.WriteLine("TaxAmount  : " + tax.TaxAmount);
                                        }
                                        else
                                        {
                                            throw new EmployeeNotFoundException($"Employee with Tax Year {yr} was not found.");

                                        }
                                    }
                                    catch (EmployeeNotFoundException ex)
                                    {
                                        Console.WriteLine(ex.Message);

                                    }
                                    catch (SqlException ex)
                                    {
                                        Console.WriteLine("Error executing query: " + ex.Message);
                                    }
                                    catch (DataBaseConnectionException ex)
                                    {
                                        Console.WriteLine(ex.Message);
                                    }
                                    Console.ReadKey();
                                    break;
                                case 5:
                                    taxExit = true; // Exit to the main menu
                                    break;
                                default:
                                    Console.WriteLine("Invalid option, please try again.");
                                    break;
                            }
                        }
                        break;

                    case 5:
                        Console.WriteLine("Exiting the system...");
                        exit = true; // Exit the entire program
                        break;

                    default:
                        Console.WriteLine("Invalid choice, please try again.");
                        break;
                }

                Console.Clear(); // Clears the console before showing the main menu again
            }


            /*
            Console.WriteLine("-----------PayXpert - Payroll Management System-------------");
            Console.WriteLine("");

            Console.WriteLine("Main Menu");
            Console.WriteLine("1.Employee Details");
            Console.WriteLine("2.Financial Record Details");
            Console.WriteLine("3.Payroll Details");
            Console.WriteLine("4..Tax Details");
            Console.WriteLine("5. EXIT");

            Console.WriteLine("");
            Console.Write("Enter your Choice : ");
            int ch = Convert.ToInt32(Console.ReadLine());

            switch(ch)
            {
                case 1:

                    Console.WriteLine("-- Employee Operations  --");
                    Console.WriteLine("1. Get All Details");
                    Console.WriteLine("2. Get Details By Employee Id");
                    Console.WriteLine("3. Add New Employee Details");
                    Console.WriteLine("4. Update Employee Details");
                    Console.WriteLine("5. Remove Employee Details");
                    Console.WriteLine("6 Go To Main Menu ");

                    EmployeeRepository employeeRepository = new EmployeeRepository();
                    EmployeeService employeeService = new EmployeeService(employeeRepository);
                    Employee employee = new Employee();

                    Console.Write("Choose An Option : ");
                    int choice=Convert.ToInt32(Console.ReadLine());
                    switch(choice)
                    {
                        case 1:
                            employeeService.GetAllEmployees();
                            Console.ReadKey();
                            break;
                        case 2:
                            Console.Write("Enter Employee Id");
                            int id = Convert.ToInt32(Console.ReadLine());
                            employeeService.GetEmployeeById(id);
                            Console.ReadKey();
                            break;
                        case 3:
                            try
                            {
                                employeeService.AddEmployee(employee);
                                Console.ReadKey();
                            }
                            catch (InvalidInputException ex)
                            {
                                Console.WriteLine($"Error: {ex.Message}");
                            }
                            break;
                        case 4:
                            employeeService.UpdateEmployee(employee);
                            Console.ReadKey();
                            break;
                        case 5:
                            Console.Write("Enter Employee Id");
                            int Id = Convert.ToInt32(Console.ReadLine());
                            employeeService.RemoveEmployee(Id);
                            Console.ReadKey();
                            break;
                        case 6:
                            break;

                    }

                    break;
                case 2:
                    Console.WriteLine("--  Financial Record Operations  --");
                    Console.WriteLine("1. Get Details By Employee Id");
                    Console.WriteLine("2. Get Details By Record Date");
                    Console.WriteLine("3. Add New Financial Record ");
                    Console.WriteLine("4. Get Details By Record Id");
                    Console.WriteLine("5. Go To Main Menu ");

                    FinancialRecordRepository financialRecordRepository = new FinancialRecordRepository();
                    FinancialRecordService financialRecordService = new FinancialRecordService(financialRecordRepository);

                    //financialRecordService.AddFinancialRecord(10, "Salary", 1000000, "Income");
                    //financialRecordService.GetFinancialRecordsForEmployee(2);
                    //financialRecordService.GetFinancialRecordsForDate(Convert.ToDateTime("2018-09-15"));
                    //financialRecordService.GetFinancialRecordById(2);

                    break;
                case 3:
                    Console.WriteLine("--  Payroll Operations  --");
                    Console.WriteLine("1. Generate New Payroll");
                    Console.WriteLine("2. Get Payroll By Payroll Id");
                    Console.WriteLine("3. Get Payroll By Employee Id ");
                    Console.WriteLine("4. Get Payroll For  Period");
                    Console.WriteLine("5. Go To Main Menu ");

                    PayrollRepository payrollRepository = new PayrollRepository();
                    PayrollService payrollService = new PayrollService(payrollRepository);


                    //payrollService.GeneratePayroll(13, 2, Convert.ToDateTime("2024-08-01"), Convert.ToDateTime("2024-08-31"));
                    //payrollService.GetPayrollById(1);
                    //payrollService.GetPayrollsForEmployee(1);
                    //payrollService.GetPayrollsForPeriod(Convert.ToDateTime("2016-08-01"), Convert.ToDateTime("2016-08-31"));

                    break;
                case 4:
                    Console.WriteLine("--  Tax Operations  --");
                    Console.WriteLine("1. Calculate and Update Tax");
                    Console.WriteLine("2. Get Tax Details By Tax Id");
                    Console.WriteLine("3. Get Tax Details By Employee Id ");
                    Console.WriteLine("4. Get Tax Details For Period");
                    Console.WriteLine("5. Go To Main Menu ");

                    TaxRepository taxRepository = new TaxRepository();
                    TaxService taxService = new TaxService(taxRepository);

                    //decimal taxAmount=taxService.CalculateTax(2, 2016);
                    //Console.WriteLine($"Calculated Tax Amount: {taxAmount}");

                    //taxService.GetTaxById(2);
                    //taxService.GetTaxesForEmployee(3);
                    //taxService.GetTaxesForYear(1950);
                    break;
            }*/

        }
    }
}

