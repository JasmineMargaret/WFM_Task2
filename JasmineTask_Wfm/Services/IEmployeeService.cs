using JasmineTask_Wfm.Models;
using System.Collections.Generic;
namespace JasmineTask_Wfm.Services
{
    public interface IEmployeeService
    {
        public IEnumerable<Employee> GetEmployees();
        public Employee GetEmployeesAgainstId(int employeeId);
        public void AddEmployee(Employee employee);
        public bool DeleteEmployee(Employee employee);
    }
}
