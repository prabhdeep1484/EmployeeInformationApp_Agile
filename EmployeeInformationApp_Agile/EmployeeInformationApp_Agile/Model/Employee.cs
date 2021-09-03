using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeInformationApp_Agile.Model
{
    public class Employee
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
