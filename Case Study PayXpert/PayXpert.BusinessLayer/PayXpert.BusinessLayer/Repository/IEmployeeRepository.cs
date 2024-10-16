using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PayXpert.Entity;

namespace PayXpert.BusinessLayer.Repository
{
    public interface IEmployeeRepository
    {
        Employee GetEmployeeById(int employeeId);
        List<Employee> GetAllEmployees();
        bool AddEmployee(Employee employee);
        bool UpdateEmployee(Employee employee);
        bool RemoveEmployee(int employeeId);

    }
}
