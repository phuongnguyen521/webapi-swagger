using System;
using System.Collections.Generic;

#nullable disable

namespace MySQLWebAPI.Models
{
    public partial class Student
    {
        public int IdStudent { get; set; }
        public string StudentName { get; set; }
        public string Major { get; set; }
    }
}
