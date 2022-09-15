using JasmineTask_Wfm.Models;
using System.Collections.Generic;
namespace JasmineTask_Wfm.Services
{
    public class SoftlockService : ISoftlockService
    {
        List<SoftLock> softLockList = new List<SoftLock>()
        {
            new SoftLock(){ EmployeeId = 1,Manager="Haris", Status="good", LockId=1, Requestmessage="nill", Wfmremark="good", Managerstatus="", Mgrstatuscomment=""},
            new SoftLock(){ EmployeeId = 2,Manager="Shawn", Status="good", LockId=2, Requestmessage="nill", Wfmremark="avg", Managerstatus="", Mgrstatuscomment=""},
            new SoftLock(){ EmployeeId = 3,Manager="Karthi", Status="avg", LockId=2, Requestmessage="nill", Wfmremark="avg", Managerstatus="", Mgrstatuscomment=""},
            new SoftLock(){ EmployeeId = 4,Manager="Vishal", Status="excellent", LockId=1, Requestmessage="nill", Wfmremark="good", Managerstatus="", Mgrstatuscomment=""},
            new SoftLock(){ EmployeeId = 5,Manager="Shonay", Status="Nil", LockId=1, Requestmessage="nill", Wfmremark="good", Managerstatus="", Mgrstatuscomment=""},
        };

        public IEnumerable<SoftLock> GetSoftLock()
        {
            return softLockList;
        }

        public SoftLock GetSoftLockAgainstId(int EmployeeId)
        {
            foreach (SoftLock softLock in softLockList)
            {
                if (softLock.EmployeeId == EmployeeId)
                    return softLock;
            }
            return null;
        }
        public void AddSoftLock(SoftLock softLock)
        {
            softLockList.Add(softLock);
        }
        public bool DeleteSoftLock(SoftLock softLock)
        {
            return softLockList.Remove(softLock);
        }
    }
}
