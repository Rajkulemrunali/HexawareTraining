using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PayXpert.Entity;
using PayXpert.Exception;

namespace PayXpert.DataAccessLayer
{
    public class PayrollData
    {
        public void GeneratePayroll(Payroll payroll)
        {
            SqlConnection conn = null;
            conn = DBUtil.getDBConnection();
            try
            {
                if (conn == null)
                {
                    throw new DataBaseConnectionException("DataBase Connection Failed");
                }
            }
            catch(DataBaseConnectionException ex)
            {
                Console.WriteLine(ex.Message);
            }

            try
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = @"Insert into Payroll values (@PayrollId,@EmployeeId,@PayPeriodStartDate,@PayPeriodEndDate,@BasicSalary,@OverTimePay,@Deduction,@Netsalary)";

                cmd.Parameters.AddWithValue("@PayrollId", payroll.PayrollID);
                cmd.Parameters.AddWithValue("@EmployeeId", payroll.EmployeeID);
                cmd.Parameters.AddWithValue("@PayPeriodStartDate", payroll.PayPeriodStartDate);
                cmd.Parameters.AddWithValue("@PayPeriodEndDate", payroll.PayPeriodEndDate);
                cmd.Parameters.AddWithValue("@BasicSalary", payroll.BasicSalary);
                cmd.Parameters.AddWithValue("@OverTimePay", payroll.OverTimePay);
                cmd.Parameters.AddWithValue("@Deduction", payroll.Deduction);
                cmd.Parameters.AddWithValue("@Netsalary", payroll.Netsalary);

                cmd.Connection = conn;
                int rowsaffected = cmd.ExecuteNonQuery();
                if(rowsaffected > 0)
                {
                    Console.WriteLine("Payroll Generated Successfully");
                }
                else
                {
                    Console.WriteLine("Failed To Add Employee");
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Error Executing Query : "+ex.Message);
            }
            finally
            {
                conn.Close();
            }


        }
        public void GetPayrollById(int payrollId)
        {
            SqlConnection conn = null;
            conn = DBUtil.getDBConnection();
            try
            {
                if (conn == null)
                {
                    throw new DataBaseConnectionException("DataBase Connection Failed ");
                }
            }
            catch (DataBaseConnectionException ex)
            {
                Console.WriteLine(ex.Message);
            }

            try
            {
                Payroll payroll = null;
                conn.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = @"Select * from Payroll where PayrollID= @payrollId";

                cmd.Parameters.AddWithValue("@payrollId ", payrollId);
                cmd.Connection = conn;

                SqlDataReader sqlDataReader = cmd.ExecuteReader();
                if (sqlDataReader.Read())
                {
                    payroll = new Payroll()
                    {
                        PayrollID = Convert.ToInt32(sqlDataReader["PayrollID"]),
                        EmployeeID = Convert.ToInt32(sqlDataReader["EmployeeID"]),
                        PayPeriodStartDate = Convert.ToDateTime(sqlDataReader["PayPeriodStartDate"]),
                        PayPeriodEndDate = Convert.ToDateTime(sqlDataReader["PayPeriodEndDate"]),
                        BasicSalary = Convert.ToDecimal(sqlDataReader["BasicSalary"]),
                        OverTimePay = Convert.ToDecimal(sqlDataReader["OvertimePay"]),
                        Deduction = Convert.ToDecimal(sqlDataReader["Deductions"]),
                        Netsalary  = Convert.ToDecimal(sqlDataReader["NetSalary"])
                    };

                    Console.WriteLine("Payroll Id: "+ payroll.PayrollID);
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
            catch (PayrollGenerationException ex)
            {
                Console.WriteLine (ex.Message);
            }
            finally 
            {
                conn.Close();
            }
        }
        public void GetPayrollsForEmployee(int employeeId)
        {
            SqlConnection conn = null;
            conn = DBUtil.getDBConnection();
            try
            {
                if (conn == null)
                {
                    throw new DataBaseConnectionException("DataBase Connection Failed ");
                }
            }
            catch (DataBaseConnectionException ex)
            {
                Console.WriteLine(ex.Message);
            }

            try
            {
                Payroll payroll = null;
                conn.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = @"Select * from Payroll where PayrollID= @employeeId";

                cmd.Parameters.AddWithValue("@employeeId ", employeeId);
                cmd.Connection = conn;

                SqlDataReader sqlDataReader = cmd.ExecuteReader();
                if (sqlDataReader.Read())
                {
                    payroll = new Payroll()
                    {
                        PayrollID = Convert.ToInt32(sqlDataReader["PayrollID"]),
                        EmployeeID = Convert.ToInt32(sqlDataReader["EmployeeID"]),
                        PayPeriodStartDate = Convert.ToDateTime(sqlDataReader["PayPeriodStartDate"]),
                        PayPeriodEndDate = Convert.ToDateTime(sqlDataReader["PayPeriodEndDate"]),
                        BasicSalary = Convert.ToDecimal(sqlDataReader["BasicSalary"]),
                        OverTimePay = Convert.ToDecimal(sqlDataReader["OvertimePay"]),
                        Deduction = Convert.ToDecimal(sqlDataReader["Deductions"]),
                        Netsalary = Convert.ToDecimal(sqlDataReader["NetSalary"])
                    };

                    Console.WriteLine("Payroll Id: " + payroll.PayrollID);
                    Console.WriteLine("Employee Id: " + payroll.EmployeeID);
                    Console.WriteLine("PayPeriodStartDate: " + payroll.PayPeriodStartDate);
                    Console.WriteLine("PayPeriodEndDate : " + payroll.PayPeriodEndDate);
                    Console.WriteLine("BasicSalary : " + payroll.BasicSalary);
                    Console.WriteLine("OverTimePay : " + payroll.OverTimePay);
                    Console.WriteLine("Deduction : " + payroll.Deduction);
                    Console.WriteLine("Netsalary : " + payroll.Netsalary);

                    sqlDataReader.Close();

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
            finally
            {
                conn.Close();
            }
        }
        public void GetPayrollsForPeriod(DateTime startDate, DateTime endDate)
        {
            SqlConnection conn = null;
            conn = DBUtil.getDBConnection();
            try
            {
                if (conn == null)
                {
                    throw new DataBaseConnectionException("DataBase Connection Failed");
                }
            }
            catch(DataBaseConnectionException ex)
            {  
                Console.WriteLine(ex.Message); 
            }

            try
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.CommandText =@"select * from Payroll where PayPeriodStartDate= @startDate and PayPeriodEndDate = @endDate";
                cmd.Parameters.AddWithValue("startDate", startDate);
                cmd.Parameters.AddWithValue("endDate", endDate);

                cmd.Connection = conn;

                SqlDataReader sqlDataReader = cmd.ExecuteReader();

                if (!sqlDataReader.HasRows)
                {
                    Console.WriteLine("No Records found.");
                    return;
                }

                while (sqlDataReader.Read())
                {
                    Payroll payroll = new Payroll()
                    {
                        PayrollID = Convert.ToInt32(sqlDataReader["PayrollID"]),
                        EmployeeID = Convert.ToInt32(sqlDataReader["EmployeeID"]),
                        PayPeriodEndDate = Convert.ToDateTime(sqlDataReader["PayPeriodEndDate"]),
                        PayPeriodStartDate = Convert.ToDateTime(sqlDataReader["PayPeriodStartDate"]),
                        BasicSalary = Convert.ToDecimal(sqlDataReader["BasicSalary"]),
                        OverTimePay = Convert.ToDecimal(sqlDataReader["OverTimePay"]),
                        Deduction = Convert.ToDecimal(sqlDataReader["Deductions"]),
                        Netsalary = Convert.ToDecimal(sqlDataReader["Netsalary"])
                    };

                    Console.WriteLine($"PayrollID : {payroll.PayrollID}");
                    Console.WriteLine($"EmployeeID : {payroll.EmployeeID}");
                    Console.WriteLine($"PayPeriodEndDate : {payroll.PayPeriodEndDate}");
                    Console.WriteLine($"PayPeriodStartDate : {payroll.PayPeriodStartDate}");
                    Console.WriteLine($"BasicSalary : {payroll.BasicSalary}");
                    Console.WriteLine($"OverTimePay : {payroll.OverTimePay}");
                    Console.WriteLine($"Deduction : {payroll.Deduction}");
                    Console.WriteLine($"Netsalary : {payroll.Netsalary}");


                }

                sqlDataReader.Close();

            }
            catch (SqlException ex) 
            {
                Console.WriteLine("Failed To Execute Query : "+ex.Message);
            }
            finally
            {
                conn.Close();  
            }
        }

    }
}
