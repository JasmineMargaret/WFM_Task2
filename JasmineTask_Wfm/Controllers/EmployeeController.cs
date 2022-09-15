using JasmineTask_Wfm.Models;
using JasmineTask_Wfm.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace JasmineTask_Wfm.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        IEmployeeService _employeeService;
        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpGet]
        public IEnumerable<Employee> Get()
        {
            return this._employeeService.GetEmployees();
        }

        [HttpGet("{employeeId}")]
        public ActionResult<Employee> Get(int employeeId)
        {
            Employee employee = this._employeeService.GetEmployeesAgainstId(employeeId);
            return employee;
        }

        [HttpPost]
        public ActionResult<Employee> AddEmployee(Employee employee)
        {
            if (employee.Name == null || employee.Name.Length <= 2)
                return StatusCode(StatusCodes.Status500InternalServerError, new
                {
                    messge = "Name not valid"
                });
            if (employee.Manager == null || employee.Manager.Length <= 2)
                return StatusCode(StatusCodes.Status500InternalServerError, new
                {
                    messge = "Manager not valid"
                });
            if (employee.WfmManager == null || employee.WfmManager.Length <= 2)
                return StatusCode(StatusCodes.Status500InternalServerError, new
                {
                    messge = "WfmManager not valid"
                });
            if (employee.Email == null || employee.Email.Length <= 2)
                return StatusCode(StatusCodes.Status500InternalServerError, new
                {
                    messge = "Email not valid"
                });
            _employeeService.AddEmployee(employee);
            return employee;
        }

        [HttpDelete("{employeeId}")]
        public ActionResult<Employee> DeleteEmployee(int employeeId)
        {
            Employee employee = this._employeeService.GetEmployeesAgainstId(employeeId);
            _employeeService.DeleteEmployee(employee);
            return employee;
        }

        [HttpPatch("{employeeId}")]
        public ActionResult<Employee> PatchEmployee(int employeeId, Employee employee)
        {
            Employee e = this._employeeService.GetEmployeesAgainstId(employeeId);
            try
            {
                if (e == null)
                    return StatusCode(StatusCodes.Status204NoContent);
                if (employee.Name != null)
                    e.Name = employee.Name;
                if (employee.Status != null)
                    e.Status = employee.Status;
                if (employee.Manager != null)
                    e.Manager = employee.Manager;
                if (employee.WfmManager != null)
                    e.WfmManager = employee.WfmManager;
                if (employee.Email != null)
                    e.Email = employee.Email;
                if (employee.Experience != null)
                    e.Experience = employee.Experience;
                return e;
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = "Server error" });

            }
        }
    }
}
