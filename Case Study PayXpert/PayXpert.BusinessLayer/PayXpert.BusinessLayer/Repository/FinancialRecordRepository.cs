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
    public class FinancialRecordRepository : IFinancialRecordRepository
    {
        public bool AddFinancialRecord(int employeeId, string description, decimal amount, string recordType)
        {
            SqlConnection conn = DBUtil.getDBConnection();

            if (conn == null)
            {
                throw new DataBaseConnectionException("Database connection failed.");
            }

            try
            {
                conn.Open();
                SqlCommand cmd1 = new SqlCommand();
                cmd1.CommandText = "Select top 1 RecordID from FinancialRecord order by RecordId Desc";
                cmd1.Connection = conn;

                int recordid = 0;
                SqlDataReader sqlDataReader = cmd1.ExecuteReader();

                if (sqlDataReader.Read())
                {
                    recordid = Convert.ToInt32(sqlDataReader["RecordID"]) + 1;
                }

                sqlDataReader.Close();

                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = @"INSERT INTO FinancialRecord (RecordID, EmployeeID, RecordDate, Description, Amount, RecordType)
                            VALUES (@RecordID, @EmployeeID, @RecordDate, @Description, @Amount, @RecordType)";
                cmd.Parameters.AddWithValue("@RecordID", recordid);
                cmd.Parameters.AddWithValue("@EmployeeID", employeeId);
                cmd.Parameters.AddWithValue("@RecordDate", DateTime.Now);
                cmd.Parameters.AddWithValue("@Description", description);
                cmd.Parameters.AddWithValue("@Amount", amount);
                cmd.Parameters.AddWithValue("@RecordType", recordType);
                cmd.Connection = conn;

                int rowsAffected = cmd.ExecuteNonQuery();

                return rowsAffected > 0;
            }
            catch (SqlException)
            {
                return false; // Return false if any SQL exception occurs
            }
            finally
            {
                conn.Close();
            }
        }

        public FinancialRecord GetFinancialRecordById(int recordId)
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
                cmd.CommandText = @"Select * from FinancialRecord where RecordID = @recordId";
                cmd.Parameters.AddWithValue("@recordId", recordId);
                cmd.Connection = conn;

                SqlDataReader sqlDataReader = cmd.ExecuteReader();

                if (sqlDataReader.Read())
                {
                    FinancialRecord financialRecord = new FinancialRecord
                    {
                        EmployeeID = Convert.ToInt32(sqlDataReader["EmployeeID"]),
                        RecordId = Convert.ToInt32(sqlDataReader["RecordID"]),
                        RecordDate = Convert.ToDateTime(sqlDataReader["RecordDate"]),
                        Amount = Convert.ToDecimal(sqlDataReader["Amount"]),
                        Description = Convert.ToString(sqlDataReader["Description"]),
                        RecordType = Convert.ToString(sqlDataReader["RecordType"])
                    };

                    sqlDataReader.Close();
                    return financialRecord;
                }
                else
                {
                    sqlDataReader.Close();
                    throw new FinancialRecordException($"Financial record with Record ID {recordId} was not found.");
                }
            }
            catch (SqlException)
            {
                return null; // Return null in case of SQL exceptions
            }
            finally
            {
                conn?.Close();
            }
        }

        public FinancialRecord GetFinancialRecordsForEmployee(int employeeId)
        {
            SqlConnection conn = null;
            conn = DBUtil.getDBConnection();

            if (conn == null)
            {
                throw new DataBaseConnectionException("DataBase Connection Failed");
            }

            try
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "Select * from FinancialRecord where EmployeeID = @EmployeeID";
                cmd.Parameters.AddWithValue("@EmployeeID", employeeId);
                cmd.Connection = conn;

                SqlDataReader sqlDataReader = cmd.ExecuteReader();

                if (sqlDataReader.Read())
                {
                    FinancialRecord financialRecord = new FinancialRecord
                    {
                        EmployeeID = employeeId,
                        RecordId = Convert.ToInt32(sqlDataReader["RecordID"]),
                        RecordDate = Convert.ToDateTime(sqlDataReader["RecordDate"]),
                        Amount = Convert.ToDecimal(sqlDataReader["Amount"]),
                        Description = Convert.ToString(sqlDataReader["Description"]),
                        RecordType = Convert.ToString(sqlDataReader["RecordType"])
                    };

                    return financialRecord;
                }
                else
                {
                    return null; // No record found
                }
            }
            catch (SqlException)
            {
                // Return null if there was an issue executing the SQL query
                return null;
            }
            finally
            {
                conn?.Close();
            }
        }

        public FinancialRecord GetFinancialRecordsForDate(DateTime recordDate)
        {
            SqlConnection conn = null;
            conn = DBUtil.getDBConnection();

            if (conn == null)
            {
                throw new DataBaseConnectionException("Database Connection Failed");
            }

            try
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = @"Select * from FinancialRecord where RecordDate = @recordDate";
                cmd.Parameters.AddWithValue("@recordDate", recordDate);
                cmd.Connection = conn;

                SqlDataReader sqlDataReader = cmd.ExecuteReader();

                if (sqlDataReader.Read())
                {
                    FinancialRecord financialRecord = new FinancialRecord
                    {
                        EmployeeID = Convert.ToInt32(sqlDataReader["EmployeeID"]),
                        RecordId = Convert.ToInt32(sqlDataReader["RecordID"]),
                        RecordDate = Convert.ToDateTime(sqlDataReader["RecordDate"]),
                        Amount = Convert.ToDecimal(sqlDataReader["Amount"]),
                        Description = Convert.ToString(sqlDataReader["Description"]),
                        RecordType = Convert.ToString(sqlDataReader["RecordType"])
                    };

                    sqlDataReader.Close();
                    return financialRecord;
                }
                else
                {
                    sqlDataReader.Close();
                    return null; // No financial record found for the given date
                }
            }
            catch (SqlException)
            {
                return null; // Return null if an SQL error occurs
            }
            finally
            {
                conn?.Close();
            }
        }

    }
}
