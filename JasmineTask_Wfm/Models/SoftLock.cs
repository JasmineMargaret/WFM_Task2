using System;
using System.Collections.Generic;

#nullable disable

namespace JasmineTask_Wfm.Models
{
    public partial class SoftLock
    {
        public int? EmployeeId { get; set; }
        public string Manager { get; set; }
        public DateTime? Reqdate { get; set; }
        public string Status { get; set; }
        public DateTime? Lastupdated { get; set; }
        public int LockId { get; set; }
        public string Requestmessage { get; set; }
        public string Wfmremark { get; set; }
        public string Managerstatus { get; set; }
        public string Mgrstatuscomment { get; set; }
        public DateTime? Mgrlastupdate { get; set; }
    }
}
