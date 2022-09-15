using JasmineTask_Wfm.Models;
using System.Collections.Generic;
namespace JasmineTask_Wfm.Services
{
    public interface ISoftlockService
    {
        public IEnumerable<SoftLock> GetSoftLock();
        public SoftLock GetSoftLockAgainstId(int EmployeeId);
        public void AddSoftLock(SoftLock softLock);
        public bool DeleteSoftLock(SoftLock softLock);
    }
}
