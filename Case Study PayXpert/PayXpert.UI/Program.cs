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
                                    employeeService.GetAllEmployees();
                                    Console.ReadKey();
                                    break;
                                case 2:
                                    Console.Write("Enter Employee Id: ");
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
                                    Console.Write("Enter Employee Id: ");
                                    int removeId = Convert.ToInt32(Console.ReadLine());
                                    employeeService.RemoveEmployee(removeId);
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
                                    financialRecordService.GetFinancialRecordsForEmployee(id);
                                    Console.ReadKey();
                                    break;
                                case 2:
                                    Console.Write("Enter Record Date :  ");
                                    int recDate= Convert.ToInt32(Console.ReadLine());
                                    financialRecordService.GetFinancialRecordsForDate(Convert.ToDateTime($"{recDate}"));
                                    Console.ReadKey();
                                    break;
                                case 3:
                                    Console.Write("Enter Employee Id");
                                    int Id= Convert.ToInt32(Console.ReadLine());
                                    Console.Write("Enter Record Description : ");
                                    string desc=Console.ReadLine();
                                    Console.Write("Enter Amount : ");
                                    decimal amt =Convert.ToDecimal( Console.ReadLine());
                                    Console.Write("Enter Record Type : ");
                                    string recType=Console.ReadLine();
                                    financialRecordService.AddFinancialRecord(Id, desc, amt, recType);
                                    Console.ReadKey();
                                    break;
                                case 4:
                                    financialRecordService.GetFinancialRecordById(2);
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
                                    Console.Write("Enter Payroll Id");
                                    int pId = Convert.ToInt32(Console.ReadLine());
                                    Console.Write("Enter Employee Id");
                                    int Id = Convert.ToInt32(Console.ReadLine());
                                    Console.Write("Enter Pay Period Start Date ");
                                    int sdate = Convert.ToInt32(Console.ReadLine());
                                    Console.Write("Enter Pay Period End Date ");
                                    int edate = Convert.ToInt32(Console.ReadLine());

                                    payrollService.GeneratePayroll(pId,Id, Convert.ToDateTime($"{sdate}"), Convert.ToDateTime($"{edate}"));
                                    Console.ReadKey();
                                    break;
                                case 2:
                                    Console.Write("Enter Payroll Id");
                                    int PId= Convert.ToInt32(Console.ReadLine());
                                    payrollService.GetPayrollById(PId);
                                    Console.ReadKey();
                                    break;
                                case 3:
                                    Console.Write("Enter Employee Id");
                                    int eId = Convert.ToInt32(Console.ReadLine());
                                    payrollService.GetPayrollsForEmployee(eId);
                                    Console.ReadKey();
                                    break;
                                case 4:
                                    Console.Write("Enter Pay Period Start Date ");
                                    int Sdate = Convert.ToInt32(Console.ReadLine());
                                    Console.Write("Enter Pay Period End Date ");
                                    int Edate = Convert.ToInt32(Console.ReadLine());
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
                                    decimal taxAmount = taxService.CalculateTax(2, 2016);
                                    Console.WriteLine($"Calculated Tax Amount: {taxAmount}");
                                    Console.ReadKey();
                                    break;
                                case 2:
                                    Console.Write("Enter Tax Id : ");
                                    int tId = Convert.ToInt32(Console.ReadLine());
                                    taxService.GetTaxById(tId);
                                    Console.ReadKey();
                                    break;
                                case 3:
                                    Console.Write("Enter Employee Id : ");
                                    int EId = Convert.ToInt32(Console.ReadLine());
                                    taxService.GetTaxesForEmployee(EId);
                                    Console.ReadKey();
                                    break;
                                case 4:
                                    Console.Write("Enter Tax Year : ");
                                    int yr = Convert.ToInt32(Console.ReadLine());
                                    taxService.GetTaxesForYear(yr);
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

