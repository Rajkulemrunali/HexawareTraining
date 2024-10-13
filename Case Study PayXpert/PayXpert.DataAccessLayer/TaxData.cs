using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PayXpert.Entity;
using PayXpert.Exception;

namespace PayXpert.DataAccessLayer
{
    public class TaxData
    {
        public decimal CalculateTax(int employeeId, int taxYear)
        {

            SqlConnection conn = DBUtil.getDBConnection();
            try
            {

                if (conn == null)
                {
                    throw new DataBaseConnectionException("Database connection failed.");
                    return 0;

                }
            }
            catch (DataBaseConnectionException ex)
            {
                Console.WriteLine(ex.Message);
                return 0;

            }
            try
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "SELECT TaxableIncome FROM Tax WHERE EmployeeID = @EmployeeID AND TaxYear = @TaxYear";
                cmd.Parameters.AddWithValue("@EmployeeID", employeeId);
                cmd.Parameters.AddWithValue("@TaxYear", taxYear);
                cmd.Connection = conn;

                SqlDataReader sqlDataReader = cmd.ExecuteReader();

                if (sqlDataReader.Read())
                {
                    decimal taxableIncome = Convert.ToDecimal(sqlDataReader["TaxableIncome"]);
                    sqlDataReader.Close();

                    decimal taxRate = 0.20m;  // Example tax rate (20%)
                    decimal taxAmount = taxableIncome * taxRate;

                    SqlCommand updateCmd = new SqlCommand();
                    updateCmd.CommandText = "UPDATE Tax SET TaxAmount = @TaxAmount WHERE EmployeeID = @EmployeeID AND TaxYear = @TaxYear";
                    updateCmd.Parameters.AddWithValue("@TaxAmount", taxAmount);
                    updateCmd.Parameters.AddWithValue("@EmployeeID", employeeId);
                    updateCmd.Parameters.AddWithValue("@TaxYear", taxYear);
                    updateCmd.Connection = conn;

                    int rowsAffected = updateCmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        Console.WriteLine("Tax calculated and updated successfully.");
                    }
                    else
                    {
                        throw new TaxCalculationException("Failed to update tax amount.");
                    }
                    return taxAmount;

                }
                else
                {
                    Console.WriteLine($"No tax record found for EmployeeID: {employeeId}, TaxYear: {taxYear}");
                    return 0;

                }
            }
            catch (TaxCalculationException ex)
            {
                Console.WriteLine(ex.Message );
                return 0;

            }
            catch (SqlException ex)
            {
                Console.WriteLine("Error executing query: " + ex.Message);
                return 0;

            }
            finally
            {
                conn.Close();
            }
        }

        public void GetTaxById(int taxId)
        {
            SqlConnection conn = null;
            conn=DBUtil.getDBConnection();

            try
            {
                if (conn == null)
                {
                    throw new DataBaseConnectionException("DataBase Connection Failed");
                }
            }
            catch (DataBaseConnectionException ex)
            {
                Console.WriteLine(ex.Message);
            }

            try
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "Select * from Tax where TaxID='"+ taxId + "'";
                cmd.Connection = conn;

                SqlDataReader sqlDataReader = cmd.ExecuteReader();

                if (sqlDataReader.Read())
                {
                    Tax tax = new Tax();
                    tax.TaxID = taxId;
                    tax.EmployeeID = Convert.ToInt32(sqlDataReader["EmployeeID"]);
                    tax.TaxYear = Convert.ToInt32(sqlDataReader["TaxYear"]);
                    tax.TaxableIncome = Convert.ToDecimal(sqlDataReader["TaxableIncome"]);
                    tax.TaxAmount = Convert.ToDecimal(sqlDataReader["TaxAmount"]);

                    Console.WriteLine("Tax ID : "+ tax.TaxID);
                    Console.WriteLine("EmployeeID  : " + tax.EmployeeID);
                    Console.WriteLine("TaxYear  : " + tax.TaxYear);
                    Console.WriteLine("TaxableIncome  : " + tax.TaxableIncome);
                    Console.WriteLine("TaxAmount  : " + tax.TaxAmount);

                }
                else
                {
                    throw new EmployeeNotFoundException($"Employee with TaxID {taxId} was not found.");
                }

            }
            catch (EmployeeNotFoundException ex)
            {
                Console.WriteLine(ex.Message);

            }
            finally
            {
                conn.Close();
            }

        }
        public void GetTaxesForEmployee(int employeeId)
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
            catch (DataBaseConnectionException ex)
            {
                Console.WriteLine(ex.Message);
            }

            try
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "Select * from Tax where EmployeeID='" + employeeId + "'";
                cmd.Connection = conn;

                SqlDataReader sqlDataReader = cmd.ExecuteReader();

                if (sqlDataReader.Read())
                {
                    Tax tax = new Tax();
                    tax.EmployeeID = employeeId;
                    tax.TaxID = Convert.ToInt32(sqlDataReader["TaxID"]);
                    tax.TaxYear = Convert.ToInt32(sqlDataReader["TaxYear"]);
                    tax.TaxableIncome = Convert.ToDecimal(sqlDataReader["TaxableIncome"]);
                    tax.TaxAmount = Convert.ToDecimal(sqlDataReader["TaxAmount"]);

                    Console.WriteLine("Tax ID : " + tax.TaxID);
                    Console.WriteLine("EmployeeID  : " + tax.EmployeeID);
                    Console.WriteLine("TaxYear  : " + tax.TaxYear);
                    Console.WriteLine("TaxableIncome  : " + tax.TaxableIncome);
                    Console.WriteLine("TaxAmount  : " + tax.TaxAmount);

                }
                else
                {
                    throw new EmployeeNotFoundException($"Employee with TaxID {employeeId} was not found.");
                }

            }
            catch (EmployeeNotFoundException ex)
            {
                Console.WriteLine(ex.Message);

            }
            finally
            {
                conn.Close();
            }
        }
        public void GetTaxesForYear(int taxYear)
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
            catch (DataBaseConnectionException ex)
            {
                Console.WriteLine(ex.Message);
            }

            try
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "Select * from Tax where TaxYear='" + taxYear + "'";
                cmd.Connection = conn;

                SqlDataReader sqlDataReader = cmd.ExecuteReader();

                if (sqlDataReader.Read())
                {
                    Tax tax = new Tax();
                    tax.TaxYear = taxYear;
                    tax.TaxID = Convert.ToInt32(sqlDataReader["TaxID"]);
                    tax.EmployeeID = Convert.ToInt32(sqlDataReader["EmployeeID"]);
                    tax.TaxableIncome = Convert.ToDecimal(sqlDataReader["TaxableIncome"]);
                    tax.TaxAmount = Convert.ToDecimal(sqlDataReader["TaxAmount"]);

                    Console.WriteLine("Tax ID : " + tax.TaxID);
                    Console.WriteLine("EmployeeID  : " + tax.EmployeeID);
                    Console.WriteLine("TaxYear  : " + tax.TaxYear);
                    Console.WriteLine("TaxableIncome  : " + tax.TaxableIncome);
                    Console.WriteLine("TaxAmount  : " + tax.TaxAmount);

                }
                else
                {
                    throw new EmployeeNotFoundException($"Employee with TaxYear {taxYear} was not found.");
                }

            }
            catch (EmployeeNotFoundException ex)
            {
                Console.WriteLine(ex.Message);

            }
            finally
            {
                conn.Close();
            }
        }
    }
}
