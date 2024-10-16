using PayXpert.DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PayXpert.Entity;
using PayXpert.Exception;

namespace PayXpert.BusinessLayer.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        public Employee GetEmployeeById(int id)
        {
            SqlConnection conn = null;
            conn = DBUtil.getDBConnection();

            if (conn == null)
            {
                throw new DataBaseConnectionException("DataBase Connection Failed");
            }

            try
            {
                Employee employee = null;
                conn.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "Select * From Employee Where EmployeeID = @id";
                cmd.Parameters.AddWithValue("@id", id); // Using parameterized query to avoid SQL injection
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
                }
                else
                {
                    throw new EmployeeNotFoundException($"Employee with ID {id} was not found.");
                }

                return employee;
            }
            finally
            {
                conn.Close();
            }
        }
        public List<Employee> GetAllEmployees()
        {
            SqlConnection conn = null;
            conn = DBUtil.getDBConnection();

            if (conn == null)
            {
                throw new DataBaseConnectionException("DataBase Connection Failed");
            }

            List<Employee> employees = new List<Employee>();

            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "Select * From Employee";
                cmd.Connection = conn;

                SqlDataReader sqlDataReader = cmd.ExecuteReader();

                // If there are records, iterate through and populate the list
                while (sqlDataReader.Read())
                {
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

                    employees.Add(employee); // Add each employee to the list
                }

                sqlDataReader.Close();
            }
            finally
            {
                conn.Close();
            }

            return employees; // Return the list of employees
        }
        public bool AddEmployee(Employee employee)
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

                // Get the last EmployeeID and increment it for the new employee
                SqlCommand cmd1 = new SqlCommand();
                cmd1.CommandText = "select top 1 EmployeeID from Employee order by EmployeeID desc";
                cmd1.Connection = conn;

                SqlDataReader sqlDataReader = cmd1.ExecuteReader();
                if (sqlDataReader.Read())
                {
                    employee.EmployeeID = Convert.ToInt32(sqlDataReader["EmployeeID"]) + 1;
                }
                sqlDataReader.Close();

                // Insert the new employee record
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = @"Insert into Employee (EmployeeID, FirstName, LastName, DOB, Gender, Email, PhoneNumber, Address, Position, JoiningDate, Termination)
                            values (@EmployeeID, @FirstName, @LastName, @DOB, @Gender, @Email, @PhoneNumber, @Address, @Position, @JoiningDate, @Termination)";

                // Add parameters for the employee
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
                int rowsAffected = cmd.ExecuteNonQuery();

                // Return true if the employee was added successfully
                return rowsAffected > 0;
            }
            catch (SqlException)
            {
                // Return false if any SQL exception occurs
                return false;
            }
            finally
            {
                conn.Close();
            }
        }
        public bool UpdateEmployee(Employee employee)
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

                // Create and set up the update command
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
                            where EmployeeID = @EmployeeID";

                // Add parameters for the employee update
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

                // Execute the update command
                int rowsAffected = cmd.ExecuteNonQuery();

                // Return true if the employee was updated, otherwise false
                return rowsAffected > 0;
            }
            catch (SqlException)
            {
                // Return false if any SQL exception occurs
                return false;
            }
            finally
            {
                conn?.Close();
            }
        }
        public bool RemoveEmployee(int employeeId)
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
                cmd.CommandText = @"Delete From Employee where EmployeeID = @EmployeeID";
                cmd.Parameters.AddWithValue("@EmployeeID", employeeId);
                cmd.Connection = conn;

                int rowsAffected = cmd.ExecuteNonQuery();

                // Return true if the employee was removed successfully
                return rowsAffected > 0;
            }
            catch (EmployeeNotFoundException)
            {
                // Return false if the employee was not found
                return false;
            }
            catch (SqlException)
            {
                // Return false if any SQL error occurs
                return false;
            }
            finally
            {
                conn?.Close();
            }
        }
        public bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }
        public bool IsValidPhoneNumber(string phoneNumber)
        {
            return phoneNumber.All(char.IsDigit) && phoneNumber.Length == 10; // Adjust validation rules as needed.
        }

    }
}
