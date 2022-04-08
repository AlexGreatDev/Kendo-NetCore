using Core.Common.DTOs.Employee;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.Service.Interfaces
{
    public interface IEmployeeService
    {
        Task<bool> AddEmployee(EmployeeDto model);

        Task<bool> EmployeeIsExists(string employeefirstname,string employeelastname);

        Task<bool> EmployeeIsExists(int id, string employeefirstname, string employeelastname);

        IEnumerable<EmployeeDto> GetAllEmployee();

        EmployeeDto GetEmployeeById(int id);

        Task<bool> UpdateEmployee(EmployeeDto model);

        bool DeleteEmployeeById(int id);
    }
}
