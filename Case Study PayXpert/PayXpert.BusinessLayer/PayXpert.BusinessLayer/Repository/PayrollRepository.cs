using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PayXpert.Entity;
using PayXpert.Exception;
using PayXpert.DataAccessLayer;
using System.Data.SqlClient;

namespace PayXpert.BusinessLayer.Repository
{
    public class PayrollRepository : IPayrollRepository
    {
        
        public bool GeneratePayroll(Payroll payroll)
        {
            SqlConnection conn = DBUtil.getDBConnection();

            if (conn == null)
            {
                throw new DataBaseConnectionException("Database connection failed.");
            }

            try
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = @"Insert into Payroll 
                            (PayrollId, EmployeeId, PayPeriodStartDate, PayPeriodEndDate, BasicSalary, OverTimePay, Deduction, Netsalary)
                            values 
                            (@PayrollId, @EmployeeId, @PayPeriodStartDate, @PayPeriodEndDate, @BasicSalary, @OverTimePay, @Deduction, @Netsalary)";

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
                return rowsaffected > 0;
            }
            catch (SqlException)
            {
                return false; // Return false if an exception occurs
            }
            finally
            {
                conn.Close();
            }
        }

        public Payroll GetPayrollById(int payrollId)
        {
            SqlConnection conn = DBUtil.getDBConnection();

            if (conn == null)
            {
                throw new DataBaseConnectionException("Database connection failed.");
            }

            try
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = @"Select * from Payroll where PayrollID = @payrollId";
                cmd.Parameters.AddWithValue("@payrollId", payrollId);
                cmd.Connection = conn;

                SqlDataReader sqlDataReader = cmd.ExecuteReader();
                if (sqlDataReader.Read())
                {
                    Payroll payroll = new Payroll()
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
                    sqlDataReader.Close();
                    return payroll; // Return the populated Payroll object
                }
                else
                {
                    throw new PayrollGenerationException($"Payroll with ID {payrollId} not found.");
                }
            }
           
            finally
            {
                conn.Close();
            }
        }

        public List<Payroll> GetPayrollsForEmployee(int employeeId)
        {
            SqlConnection conn = DBUtil.getDBConnection();

            if (conn == null)
            {
                throw new DataBaseConnectionException("Database connection failed.");
            }

            List<Payroll> payrolls = new List<Payroll>();

            try
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = @"Select * from Payroll where EmployeeID = @employeeId";
                cmd.Parameters.AddWithValue("@employeeId", employeeId);
                cmd.Connection = conn;

                SqlDataReader sqlDataReader = cmd.ExecuteReader();

                while (sqlDataReader.Read())
                {
                    Payroll payroll = new Payroll()
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

                    payrolls.Add(payroll); // Add the payroll to the list
                }

                sqlDataReader.Close();

                if (payrolls.Count == 0)
                {
                    throw new PayrollGenerationException($"No payrolls found for employee with ID {employeeId}.");
                }

                return payrolls; // Return the list of payrolls

            }
            catch (PayrollGenerationException)
            {
                // Re-throw to handle it at a higher level
                throw;
            }
            finally
            {
                conn.Close();
            }
        }

        public List<Payroll> GetPayrollsForPeriod(DateTime startDate, DateTime endDate)
        {
            SqlConnection conn = DBUtil.getDBConnection();

            if (conn == null)
            {
                throw new DataBaseConnectionException("Database connection failed.");
            }

            List<Payroll> payrolls = new List<Payroll>();

            try
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = @"SELECT * FROM Payroll WHERE PayPeriodStartDate = @startDate AND PayPeriodEndDate = @endDate";
                cmd.Parameters.AddWithValue("@startDate", startDate);
                cmd.Parameters.AddWithValue("@endDate", endDate);
                cmd.Connection = conn;

                SqlDataReader sqlDataReader = cmd.ExecuteReader();

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
                        Netsalary = Convert.ToDecimal(sqlDataReader["NetSalary"])
                    };

                    payrolls.Add(payroll); // Add the payroll to the list
                }

                sqlDataReader.Close();

                if (payrolls.Count == 0)
                {
                    throw new PayrollGenerationException($"No payrolls found for the period {startDate} to {endDate}.");
                }

                return payrolls; // Return the list of payrolls
            }
            
            finally
            {
                conn.Close();
            }
        }



    }
}
