using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Text;

namespace CommonModel
{
    public class EmployeeModel
    {
        public int EmpId { get; set; }
        public string Name { get; set; }
        public string ProfileImage { get; set; }
        public string Gender { get; set; }
        public string Department { get; set; }
        public long Salary { get; set; }
        public DateTime StartDate { get; set; }
        public string Notes { get; set; }
    }
}

   