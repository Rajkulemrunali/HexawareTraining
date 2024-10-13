using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using PayXpert.Entity;
using PayXpert.Exception;

namespace PayXpert.DataAccessLayer
{
    public class EmployeeData
    {
        public void GetEmployeeById(int id)
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
                Employee employee = null;
                conn.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "Select * From Employee Where EmployeeID= '" + id + "'";
                cmd.Connection = conn;

                SqlDataReader sqlDataReader = cmd.ExecuteReader();

                if (sqlDataReader.Read())
                {
                    employee = new Employee()
                    {
                        EmployeeID = Convert.ToInt32(sqlDataReader["EmployeeID"]),
                        Firstname = sqlDataReader["FirstName"].ToString(),
                        Lastname = sqlDataReader["LastName"].ToString(),
                        DOB = Convert.ToDateTime(sqlDataReader["DOB"]),
                        Gender = sqlDataReader["Gender"].ToString(),
                        Email = sqlDataReader["Email"].ToString(),
                        PhoneNumber = sqlDataReader["PhoneNumber"].ToString(),
                        Address = sqlDataReader["Address"].ToString(),
                        Position = sqlDataReader["Position"].ToString(),
                        JoiningDate = Convert.ToDateTime(sqlDataReader["JoiningDate"]),
                        Termination = sqlDataReader["Termination"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(sqlDataReader["Termination"])
                    };

                    Console.WriteLine($"ID: {employee.EmployeeID}");
                    Console.WriteLine($"Name: {employee.Firstname} {employee.Lastname}");
                    Console.WriteLine($"DOB: {employee.DOB.ToShortDateString()}");
                    Console.WriteLine($"Gender: {employee.Gender}");
                    Console.WriteLine($"Email: {employee.Email}");
                    Console.WriteLine($"PhoneNumber: {employee.PhoneNumber}");
                    Console.WriteLine($"Address: {employee.Address}");
                    Console.WriteLine($"Position: {employee.Position}");
                    Console.WriteLine($"Joining Date: {employee.JoiningDate.ToShortDateString()}");
                    Console.WriteLine($"Termination Date: {(employee.Termination.HasValue ? employee.Termination.Value.ToShortDateString() : "N/A")}");

                }
                else
                {
                    throw new EmployeeNotFoundException($"Employee with ID {id} was not found.");
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

        public void GetAllEmployees()
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
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "Select * From Employee";
                cmd.Connection = conn;

                SqlDataReader sqlDataReader = cmd.ExecuteReader();

                // Check if there are any records
                if (!sqlDataReader.HasRows)
                {
                    Console.WriteLine("No Records found.");
                    return;
                }

                // Loop through the records and display employee details
                while (sqlDataReader.Read()) // Read all records
                {
                    // Create and populate an Employee object
                    Employee employee = new Employee
                    {
                        EmployeeID = Convert.ToInt32(sqlDataReader["EmployeeID"]),
                        Firstname = sqlDataReader["FirstName"].ToString(),
                        Lastname = sqlDataReader["LastName"].ToString(),
                        DOB = Convert.ToDateTime(sqlDataReader["DOB"]),
                        Gender = sqlDataReader["Gender"].ToString(),
                        Email = sqlDataReader["Email"].ToString(),
                        PhoneNumber = sqlDataReader["PhoneNumber"].ToString(),
                        Address = sqlDataReader["Address"].ToString(),
                        Position = sqlDataReader["Position"].ToString(),
                        JoiningDate = Convert.ToDateTime(sqlDataReader["JoiningDate"]),
                        Termination = sqlDataReader["Termination"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(sqlDataReader["Termination"])
                    };

                    // Display the Employee properties for each record
                    Console.WriteLine($"ID: {employee.EmployeeID}");
                    Console.WriteLine($"Name: {employee.Firstname} {employee.Lastname}");
                    Console.WriteLine($"DOB: {employee.DOB.ToShortDateString()}");
                    Console.WriteLine($"Gender: {employee.Gender}");
                    Console.WriteLine($"Email: {employee.Email}");
                    Console.WriteLine($"Address: {employee.Address}");
                    Console.WriteLine($"Position: {employee.Position}");
                    Console.WriteLine($"Joining Date: {employee.JoiningDate.ToShortDateString()}");
                    Console.WriteLine($"Termination Date: {(employee.Termination.HasValue ? employee.Termination.Value.ToShortDateString() : "N/A")}");
                    Console.WriteLine(new string('-', 40)); // Separator for readability
                }

                sqlDataReader.Close();


            }
            catch (SqlException ex)
            {
                Console.WriteLine("Failed To ExecuteQuery : " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        public void AddEmployee(Employee employee)
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
                conn.Open();

                SqlCommand cmd1 = new SqlCommand();
                cmd1.CommandText = "select top 1 EmployeeID from Employee order by EmployeeID desc";
                cmd1.Connection = conn;
                

                SqlDataReader sqlDataReader = cmd1.ExecuteReader();
                if (sqlDataReader.Read()) 
                {
                    employee.EmployeeID= Convert.ToInt32(sqlDataReader["EmployeeID"])+1;
                    sqlDataReader.Close();
                }

                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = @"Insert into Employee (EmployeeID, FirstName, LastName, DOB, Gender, Email, PhoneNumber, Address, Position, JoiningDate, Termination) values (@EmployeeID, @FirstName, @LastName, @DOB, @Gender, @Email,@PhoneNumber, @Address, @Position, @JoiningDate, @Termination)";

                cmd.Parameters.AddWithValue("@EmployeeID", employee.EmployeeID);
                cmd.Parameters.AddWithValue("@FirstName", employee.Firstname);
                cmd.Parameters.AddWithValue("@LastName", employee.Lastname);
                cmd.Parameters.AddWithValue("@DOB", employee.DOB);
                cmd.Parameters.AddWithValue("@Gender", employee.Gender);
                cmd.Parameters.AddWithValue("@Email", employee.Email);
                cmd.Parameters.AddWithValue("@PhoneNumber", employee.PhoneNumber);
                cmd.Parameters.AddWithValue("@Address", employee.Address);
                cmd.Parameters.AddWithValue("@Position", employee.Position);
                cmd.Parameters.AddWithValue("@JoiningDate", employee.JoiningDate);
                cmd.Parameters.AddWithValue("@Termination", employee.Termination);

                cmd.Connection = conn;
                int rowsaffected = cmd.ExecuteNonQuery();

                if (rowsaffected > 0)
                {
                    Console.WriteLine($"Employee with {employee.EmployeeID} Added Successfully");
                }
                else
                {
                    Console.WriteLine("Failed To Add Employee");
                }


            }
            catch (SqlException ex)
            {
                Console.WriteLine("Error Executing Query : " + ex.Message);
            }
            finally
            {
                conn.Close();
            }

        }

        public void UpdateEmployee(Employee employee)
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
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = @"Update Employee
                                set FirstName = @FirstName, 
                                LastName = @LastName, 
                                DOB = @DOB, 
                                Gender = @Gender, 
                                Email = @Email, 
                                PhoneNumber= @PhoneNumber,
                                Address = @Address, 
                                Position = @Position, 
                                JoiningDate = @JoiningDate, 
                                Termination = @Termination
                                    where EmployeeID=@EmployeeID ";

                cmd.Parameters.AddWithValue("@EmployeeID", employee.EmployeeID);
                cmd.Parameters.AddWithValue("@FirstName", employee.Firstname);
                cmd.Parameters.AddWithValue("@LastName", employee.Lastname);
                cmd.Parameters.AddWithValue("@DOB", employee.DOB);
                cmd.Parameters.AddWithValue("@Gender", employee.Gender);
                cmd.Parameters.AddWithValue("@Email", employee.Email);
                cmd.Parameters.AddWithValue("@PhoneNumber", employee.PhoneNumber);
                cmd.Parameters.AddWithValue("@Address", employee.Address);
                cmd.Parameters.AddWithValue("@Position", employee.Position);
                cmd.Parameters.AddWithValue("@JoiningDate", employee.JoiningDate);
                cmd.Parameters.AddWithValue("@Termination", employee.Termination);

                cmd.Connection = conn;
                int rowsaffected = cmd.ExecuteNonQuery();
                if (rowsaffected > 0)
                {
                    Console.WriteLine("Employee Updated Successfully ");
                }
                else
                {
                    throw new EmployeeNotFoundException ($"Employee with ID {employee.EmployeeID} was not found. Updation Failed");
                }

            }
            catch (EmployeeNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                conn?.Close();
            }
        }

        public void RemoveEmployee(int employeeId)
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
                conn.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = @"Delete Employee where EmployeeID = @EmployeeID";

                cmd.Parameters.AddWithValue("@EmployeeID", employeeId);

                cmd.Connection = conn;

                int rowsaffected = cmd.ExecuteNonQuery();
                if (rowsaffected > 0)
                {
                    Console.WriteLine("Employee Removed Sucessfully : ");

                }
                else
                {
                    throw new EmployeeNotFoundException($"Employee with ID {employeeId} was not found. Updation Failed");

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
