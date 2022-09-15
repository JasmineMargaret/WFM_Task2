using JasmineTask_Wfm.Models;
using System.Collections.Generic;
namespace JasmineTask_Wfm.Services
{
    public class EmployeeService : IEmployeeService
    {
        List<Employee> employeeList = new List<Employee>()
        {
            new Employee(){ EmployeeId = 1, Name ="Jasmine", Status="good", Manager="Haris", WfmManager="Charan", Email="jasmine@softura.com", Lockstatus="No", Experience=2 },
            new Employee(){ EmployeeId = 2, Name ="Pallavi", Status="good", Manager="Shawn", WfmManager="Anto", Email="pallavi@softura.com", Lockstatus="No", Experience=2 },
            new Employee(){ EmployeeId = 3, Name ="Krish", Status="avg", Manager="Karthi", WfmManager="Charan", Email="krish@softura.com", Lockstatus="yes", Experience=1 },
            new Employee(){ EmployeeId = 4, Name ="Bona", Status="excellent", Manager="Vishal", WfmManager="Charan", Email="bona@softura.com", Lockstatus="No", Experience=3 },
            new Employee(){ EmployeeId = 5, Name ="Jerry", Status="Nil", Manager="Shonay", WfmManager="Afiz", Email="jerry@softura.com", Lockstatus="yes", Experience=4 },
        };

        public IEnumerable<Employee> GetEmployees()
        {
            return employeeList;
        }

        public Employee GetEmployeesAgainstId(int employeeId)
        {
            foreach (Employee employee in employeeList)
            {
                if (employee.EmployeeId == employeeId)
                    return employee;
            }
            return null;
        }
        public void AddEmployee(Employee employee)
        {
            employeeList.Add(employee);
        }
        public bool DeleteEmployee(Employee employee)
        {
            return employeeList.Remove(employee);
        }
    }
}
