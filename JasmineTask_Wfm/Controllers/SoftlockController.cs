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
    public class SoftlockController : ControllerBase
    {
        ISoftlockService _softlockService;
        public SoftlockController(ISoftlockService softlockService)
        {
            _softlockService = softlockService;
        }

        [HttpGet]
        public IEnumerable<SoftLock> Get()
        {
            return this._softlockService.GetSoftLock();
        }

        [HttpGet("{employeeId}")]
        public ActionResult<SoftLock> Get(int employeeId)
        {
            SoftLock softlock = this._softlockService.GetSoftLockAgainstId(employeeId);
            return softlock;
        }

        [HttpPost]
        public ActionResult<SoftLock> AddEmployee(SoftLock softlock)
        {
            if (softlock.Manager == null || softlock.Manager.Length <= 2)
                return StatusCode(StatusCodes.Status500InternalServerError, new
                {
                    messge = "Manager not valid"
                });
            if (softlock.Status == null || softlock.Manager.Length <= 2)
                return StatusCode(StatusCodes.Status500InternalServerError, new
                {
                    messge = "Status not valid"
                });
            if (softlock.Requestmessage == null || softlock.Requestmessage.Length <= 2)
                return StatusCode(StatusCodes.Status500InternalServerError, new
                {
                    messge = "Requestmessage not valid"
                });
            if (softlock.Wfmremark == null || softlock.Wfmremark.Length <= 2)
                return StatusCode(StatusCodes.Status500InternalServerError, new
                {
                    messge = "Wfmremark not valid"
                });
            if (softlock.Managerstatus == null || softlock.Managerstatus.Length <= 2)
                return StatusCode(StatusCodes.Status500InternalServerError, new
                {
                    messge = "Managerstatus not valid"
                });
            if (softlock.Mgrstatuscomment == null || softlock.Mgrstatuscomment.Length <= 2)
                return StatusCode(StatusCodes.Status500InternalServerError, new
                {
                    messge = "Mgrstatuscomment not valid"
                });
            _softlockService.AddSoftLock(softlock);
            return softlock;
        }

        [HttpDelete("{employeeId}")]
        public ActionResult<SoftLock> DeleteEmployee(int employeeId)
        {
            SoftLock softlock = this._softlockService.GetSoftLockAgainstId(employeeId);
            _softlockService.DeleteSoftLock(softlock);
            return softlock;
        }

        [HttpPatch("{employeeId}")]
        public ActionResult<SoftLock> PatchEmployee(int employeeId, SoftLock softlock)
        {
            SoftLock e = this._softlockService.GetSoftLockAgainstId(employeeId);
            try
            {
                if (e == null)
                    return StatusCode(StatusCodes.Status204NoContent);
                if (softlock.Manager != null)
                    e.Manager = softlock.Manager;
                if (softlock.Status != null)
                    e.Status = softlock.Status;
                if (softlock.Managerstatus != null)
                    e.Managerstatus = softlock.Managerstatus;
                if (softlock.Mgrstatuscomment != null)
                    e.Mgrstatuscomment = softlock.Mgrstatuscomment;
                return e;
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = "Server error" });

            }
        }
    }
}
