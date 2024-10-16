using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PayXpert.Exception;
using PayXpert.Entity;
using System.Data.SqlClient;

namespace PayXpert.DataAccessLayer
{
    public class FinancialRecordData
    {
        public void AddFinancialRecord(int employeeId, string description, decimal amount, string recordType)
        {
            SqlConnection conn = DBUtil.getDBConnection();
            try
            {
                if (conn == null)
                {
                    throw new DataBaseConnectionException("Database connection failed.");
                }
            }
            catch(DataBaseConnectionException ex)
            {
                Console.WriteLine(ex.Message);
            }
            try
            {
                conn.Open();
                SqlCommand cmd1 = new SqlCommand();
                cmd1.CommandText = "Select top 1 RecordID from FinancialRecord order by RecordId Desc";
                cmd1.Connection= conn;
                int recordid=0;
                SqlDataReader sqlDataReader = cmd1.ExecuteReader();
                if (sqlDataReader.Read()) 
                {
                    recordid = Convert.ToInt32(sqlDataReader["RecordID"])+1;
                    sqlDataReader.Close();
                }

                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "INSERT INTO FinancialRecord (RecordID,EmployeeID, RecordDate, Description, Amount, RecordType) " +
                                  "VALUES (@RecordID, @EmployeeID, @RecordDate, @Description, @Amount, @RecordType)";

                
                cmd.Parameters.AddWithValue("@RecordID", recordid);
                cmd.Parameters.AddWithValue("@EmployeeID", employeeId);
                cmd.Parameters.AddWithValue("@RecordDate", DateTime.Now); 
                cmd.Parameters.AddWithValue("@Description", description);
                cmd.Parameters.AddWithValue("@Amount", amount);
                cmd.Parameters.AddWithValue("@RecordType", recordType);
                cmd.Connection = conn;

                int rowsAffected = cmd.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    Console.WriteLine("Financial record added successfully.");
                }
                else
                {
                    Console.WriteLine("Error adding financial record.");
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Error executing query: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }


        public void GetFinancialRecordById(int recordId)
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
                cmd.CommandText = @"Select * from FinancialRecord where RecordID=@recordId";
                cmd.Parameters.AddWithValue("@recordId", recordId);
                cmd.Connection = conn;

                SqlDataReader sqlDataReader = cmd.ExecuteReader();

                if (sqlDataReader.Read())
                {
                    FinancialRecord financialRecord = new FinancialRecord();
                    financialRecord.EmployeeID = Convert.ToInt32(sqlDataReader["employeeId"]);
                    financialRecord.RecordId = Convert.ToInt32(sqlDataReader["RecordID"]);
                    financialRecord.RecordDate = Convert.ToDateTime(sqlDataReader["RecordDate"]);
                    financialRecord.Amount = Convert.ToDecimal(sqlDataReader["Amount"]);
                    financialRecord.Description = Convert.ToString(sqlDataReader["Description"]);
                    financialRecord.RecordType = Convert.ToString(sqlDataReader["RecordType"]);

                    Console.WriteLine("RecordId : " + financialRecord.RecordId);
                    Console.WriteLine("EmployeeID  : " + financialRecord.EmployeeID);
                    Console.WriteLine("RecordDate  : " + financialRecord.RecordDate);
                    Console.WriteLine("Description  : " + financialRecord.Description);
                    Console.WriteLine("Amount  : " + financialRecord.Description);
                    Console.WriteLine("RecordType  : " + financialRecord.RecordType);

                }
                else
                {
                    throw new FinancialRecordException($"Financial Record  with Record ID {recordId} was not found");
                }
                sqlDataReader.Close();

            }
            catch (FinancialRecordException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Error Executing The Query" + ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }
    
        public void GetFinancialRecordsForEmployee(int employeeId)
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
                cmd.CommandText = "Select * from FinancialRecord where EmployeeID='" + employeeId + "'";
                cmd.Connection = conn;

                SqlDataReader sqlDataReader = cmd.ExecuteReader();

                if (sqlDataReader.Read())
                {
                    FinancialRecord financialRecord = new FinancialRecord();
                    financialRecord.EmployeeID = employeeId;
                    financialRecord.RecordId = Convert.ToInt32(sqlDataReader["RecordID"]);
                    financialRecord.RecordDate = Convert.ToDateTime(sqlDataReader["RecordDate"]);
                    financialRecord.Amount  = Convert.ToDecimal(sqlDataReader["Amount"]);
                    financialRecord.Description = Convert.ToString(sqlDataReader["Description"]);
                    financialRecord.RecordType = Convert.ToString(sqlDataReader["RecordType"]);

                    Console.WriteLine("RecordId : " + financialRecord.RecordId);
                    Console.WriteLine("EmployeeID  : " + financialRecord.EmployeeID);
                    Console.WriteLine("RecordDate  : " + financialRecord.RecordDate);
                    Console.WriteLine("Description  : " + financialRecord.Description);

                    Console.WriteLine("Amount  : " + financialRecord.Description);
                    Console.WriteLine("RecordType  : " + financialRecord.RecordType);

                }
                else
                {
                    throw new EmployeeNotFoundException($"Employee with EmployeeId {employeeId} was not found.");
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
        public void GetFinancialRecordsForDate(DateTime recordDate)
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
                cmd.CommandText = @"Select * from FinancialRecord where RecordDate=@recordDate";
                cmd.Parameters.AddWithValue("@recordDate", recordDate);
                cmd.Connection = conn;

                SqlDataReader sqlDataReader = cmd.ExecuteReader();

                if (sqlDataReader.Read())
                {
                    FinancialRecord financialRecord = new FinancialRecord();
                    financialRecord.EmployeeID = Convert.ToInt32(sqlDataReader["employeeId"]);
                    financialRecord.RecordId = Convert.ToInt32(sqlDataReader["RecordID"]);
                    financialRecord.RecordDate = Convert.ToDateTime(sqlDataReader["RecordDate"]);
                    financialRecord.Amount = Convert.ToDecimal(sqlDataReader["Amount"]);
                    financialRecord.Description = Convert.ToString(sqlDataReader["Description"]);
                    financialRecord.RecordType = Convert.ToString(sqlDataReader["RecordType"]);

                    Console.WriteLine("RecordId : " + financialRecord.RecordId);
                    Console.WriteLine("EmployeeID  : " + financialRecord.EmployeeID);
                    Console.WriteLine("RecordDate  : " + financialRecord.RecordDate);
                    Console.WriteLine("Description  : " + financialRecord.Description);
                    Console.WriteLine("Amount  : " + financialRecord.Description);
                    Console.WriteLine("RecordType  : " + financialRecord.RecordType);

                }
                else
                {
                    throw new FinancialRecordException($"Financial Record  with Record Date {recordDate} was not found");
                }
                sqlDataReader.Close();

            }
            catch (FinancialRecordException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch(SqlException ex)
            {
                Console.WriteLine("Error Executing The Query" + ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }
    }
}
