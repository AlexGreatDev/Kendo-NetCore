using Business.Service.Interfaces;
using Core.ApplicationCore.UnitOfWork;
using Core.Common.DTOs.Employee;
using Data.DataAccessLayer.Context;
using Data.DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Business.Service.Engines
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IUnitOfWork<DbAppContext> _unitOfWork;

        public EmployeeService(IUnitOfWork<DbAppContext> unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> AddEmployee(EmployeeDto model)
        {
            Employee employee = await _unitOfWork.GetRepository<Employee>().AddAsync(new Employee
            {
                EmployeeFirstName = model.EmployeeFirstName,
                EmployeeLastName = model.EmployeeLastName,
                EmployeePhone = model.EmployeePhone,
                EmployeeZip = model.EmployeeZip,
                Date = model.Date,
                HireDate = model.HireDate
            });

            return employee != null && employee.EmployeeID != 0;
        }

        public async Task<bool> EmployeeIsExists(string employeefirstName,string employeelastname) => 
            await _unitOfWork.GetRepository<Employee>().FindAsync(
                x => string.Equals(x.EmployeeFirstName, employeefirstName, StringComparison.CurrentCultureIgnoreCase)
                && string.Equals(x.EmployeeLastName, employeelastname, StringComparison.CurrentCultureIgnoreCase)
                ) != null;

        public async Task<bool> EmployeeIsExists(int id, string employeefirstName, string employeelastname) =>
            await _unitOfWork.GetRepository<Employee>().FindAsync(
                x => x.EmployeeID != id
                && string.Equals(x.EmployeeFirstName, employeefirstName, StringComparison.CurrentCultureIgnoreCase)
                && string.Equals(x.EmployeeLastName, employeelastname, StringComparison.CurrentCultureIgnoreCase)
                ) != null;

        public IEnumerable<EmployeeDto> GetAllEmployee()
        {
            IEnumerable<Employee> teams =
                _unitOfWork.GetRepository<Employee>().Filter(null, x => x.OrderBy(y => y.EmployeeLastName));

            return teams.Select(x => new EmployeeDto
            {
                EmployeeID = x.EmployeeID,
                EmployeeFirstName = x.EmployeeFirstName,
                EmployeeLastName = x.EmployeeLastName,
                EmployeePhone = x.EmployeePhone,
                EmployeeZip = x.EmployeeZip,
                Date =x.Date,
                HireDate = x.HireDate
            }).AsEnumerable();
        }

        public EmployeeDto GetEmployeeById(int id)
        {
            Employee employee = _unitOfWork.GetRepository<Employee>().FindAsync(x => x.EmployeeID == id).Result;

            if (employee == null)
            {
                return new EmployeeDto();
            }

            return new EmployeeDto
            {
                EmployeeID = employee.EmployeeID,
                EmployeeFirstName = employee.EmployeeFirstName,
                EmployeeLastName = employee.EmployeeLastName,
                EmployeePhone = employee.EmployeePhone,
                EmployeeZip = employee.EmployeeZip,
                Date = employee.Date,
                HireDate = employee.HireDate
            };
        }

        public async Task<bool> UpdateEmployee(EmployeeDto model)
        {
            Employee employee = await _unitOfWork.GetRepository<Employee>().UpdateAsync(new Employee
            {
                EmployeeID = model.EmployeeID,
                EmployeeFirstName = model.EmployeeFirstName,
                EmployeeLastName = model.EmployeeLastName,
                EmployeePhone = model.EmployeePhone,
                EmployeeZip = model.EmployeeZip,
                HireDate = model.HireDate
            });

            return employee != null;
        }

        public bool DeleteEmployeeById(int id)
        {
            Task<int> result = _unitOfWork.GetRepository<Employee>().DeleteAsync(new Employee { EmployeeID = id });

            return Convert.ToBoolean(result.Result);
        }

        
    }
}
