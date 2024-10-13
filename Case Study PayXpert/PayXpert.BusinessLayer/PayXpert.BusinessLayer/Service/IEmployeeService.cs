﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PayXpert.Entity;

namespace PayXpert.BusinessLayer.Service
{
    public interface IEmployeeService
    {
        void GetEmployeeById(int employeeId);
        void GetAllEmployees();
        void AddEmployee(Employee employee);
        void UpdateEmployee(Employee employee);
       // void RemoveEmployee(int employeeId);
    }
}
