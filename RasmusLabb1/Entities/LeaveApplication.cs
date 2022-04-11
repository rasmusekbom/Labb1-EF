using RasmusLabb1.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace RasmusLabb1.Entities
{
    public class LeaveApplication
    {
        [Key]
        public int LeaveId { get; set; }

        [MaxLength(50)]
        [Column(TypeName = "varchar(50)")]
        public LeaveReason LeaveReason { get; set; }
        
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public DateTime ApplicationCreated { get; set; }
        //Relationships

        public int EmployeeId { get; set; }
        [ForeignKey("EmployeeId")]
        public Employee Employee { get; set; }

    }
}
