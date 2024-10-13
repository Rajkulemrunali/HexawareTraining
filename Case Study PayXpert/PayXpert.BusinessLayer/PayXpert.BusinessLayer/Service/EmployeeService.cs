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
        public EmployeeService(EmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }
        public void GetEmployeeById(int id)
        {
            _employeeRepository.GetEmployeeById(id);
        }
        public void GetAllEmployees()
        {
            _employeeRepository.GetAllEmployees();
        }
        public void AddEmployee(Employee employee)
        {
            _employeeRepository.AddEmployee(employee);
        }
        public void UpdateEmployee(Employee employee)
        {
            _employeeRepository.UpdateEmployee(employee);
        }
        public void RemoveEmployee(int employeeId)
        {
            _employeeRepository.RemoveEmployee(employeeId);
        }



    }
}
