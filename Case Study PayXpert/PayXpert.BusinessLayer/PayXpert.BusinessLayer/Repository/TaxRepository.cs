using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PayXpert.Entity;
using PayXpert.DataAccessLayer;
using PayXpert.Exception;
using System.Data.SqlClient;

namespace PayXpert.BusinessLayer.Repository
{
    public class TaxRepository : ITaxRepository
    {
        TaxData taxData =new TaxData();
        public decimal CalculateTax(int employeeId, int taxYear)
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
                        return taxAmount;  // Successfully updated tax amount
                    }
                    else
                    {
                        throw new TaxCalculationException("Failed to update tax amount.");
                    }
                }
                else
                {
                    throw new TaxCalculationException($"No tax record found for EmployeeID: {employeeId}, TaxYear: {taxYear}");
                }
            }
           
            catch (SqlException ex)
            {
                throw new System.Exception("Error executing query: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }


        public Tax GetTaxById(int taxId)
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
                cmd.CommandText = "Select * from Tax where TaxID = @taxId";
                cmd.Parameters.AddWithValue("@taxId", taxId);
                cmd.Connection = conn;

                SqlDataReader sqlDataReader = cmd.ExecuteReader();

                if (sqlDataReader.Read())
                {
                    Tax tax = new Tax
                    {
                        TaxID = taxId,
                        EmployeeID = Convert.ToInt32(sqlDataReader["EmployeeID"]),
                        TaxYear = Convert.ToInt32(sqlDataReader["TaxYear"]),
                        TaxableIncome = Convert.ToDecimal(sqlDataReader["TaxableIncome"]),
                        TaxAmount = Convert.ToDecimal(sqlDataReader["TaxAmount"])
                    };

                    sqlDataReader.Close();
                    return tax;  // Return the found Tax object
                }
                else
                {
                    throw new EmployeeNotFoundException($"Employee with TaxID {taxId} was not found.");
                }
            }
           
            catch (SqlException ex)
            {
                throw new System.Exception("Error executing query: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        public Tax GetTaxesForEmployee(int employeeId)
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
                cmd.CommandText = "Select * from Tax where EmployeeID = @employeeId";
                cmd.Parameters.AddWithValue("@employeeId", employeeId);
                cmd.Connection = conn;

                SqlDataReader sqlDataReader = cmd.ExecuteReader();

                if (sqlDataReader.Read())
                {
                    Tax tax = new Tax
                    {
                        EmployeeID = employeeId,
                        TaxID = Convert.ToInt32(sqlDataReader["TaxID"]),
                        TaxYear = Convert.ToInt32(sqlDataReader["TaxYear"]),
                        TaxableIncome = Convert.ToDecimal(sqlDataReader["TaxableIncome"]),
                        TaxAmount = Convert.ToDecimal(sqlDataReader["TaxAmount"])
                    };

                    sqlDataReader.Close();
                    return tax;  // Return the found Tax object
                }
                else
                {
                    throw new EmployeeNotFoundException($"Employee with EmployeeID {employeeId} was not found.");
                }
            }
            
            catch (SqlException ex)
            {
                throw new System.Exception("Error executing query: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        public Tax GetTaxesForYear(int taxYear)
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
                cmd.CommandText = "Select * from Tax where TaxYear = @taxYear";
                cmd.Parameters.AddWithValue("@taxYear", taxYear);
                cmd.Connection = conn;

                SqlDataReader sqlDataReader = cmd.ExecuteReader();

                if (sqlDataReader.Read())
                {
                    Tax tax = new Tax
                    {
                        TaxYear = taxYear,
                        TaxID = Convert.ToInt32(sqlDataReader["TaxID"]),
                        EmployeeID = Convert.ToInt32(sqlDataReader["EmployeeID"]),
                        TaxableIncome = Convert.ToDecimal(sqlDataReader["TaxableIncome"]),
                        TaxAmount = Convert.ToDecimal(sqlDataReader["TaxAmount"])
                    };

                    sqlDataReader.Close();
                    return tax;  // Return the found Tax object
                }
                else
                {
                    throw new EmployeeNotFoundException($"No tax record found for TaxYear {taxYear}.");
                }
            }
           
            catch (SqlException ex)
            {
                throw new SystemException("Error executing query: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

    }
}
