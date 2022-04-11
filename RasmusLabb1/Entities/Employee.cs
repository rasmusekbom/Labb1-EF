using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace RasmusLabb1.Entities
{
    public class Employee
    {
        [Key]
        public int EmployeeId { get; set; }
        public string FullName { get; set; }


        public IEnumerable<LeaveApplication> LeaveApplications { get; set; }
    }
}
