using PayXpert.BusinessLayer.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PayXpert.Entity;

namespace PayXpert.BusinessLayer.Service
{
    public class EmployeeService : IEmployeeService
    {
        IEmployeeRepository _employeeRepository;
        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }
        public Employee GetEmployeeById(int id)
        {
            return _employeeRepository.GetEmployeeById(id);
        }
        public List<Employee> GetAllEmployees()
        {
           return _employeeRepository.GetAllEmployees();
        }
        public bool AddEmployee(Employee employee)
        {
           return _employeeRepository.AddEmployee(employee);
        }
        public bool UpdateEmployee(Employee employee)
        {
            return _employeeRepository.UpdateEmployee(employee);
        }
        public bool RemoveEmployee(int employeeId)
        {
           return _employeeRepository.RemoveEmployee(employeeId);
        }



    }
}
