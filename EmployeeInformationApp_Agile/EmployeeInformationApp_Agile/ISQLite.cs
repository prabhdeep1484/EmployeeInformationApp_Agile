using EmployeeInformationApp_Agile.Model;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeInformationApp_Agile
{
    public interface ISQLite
    {
        SQLiteConnection GetConnection();
        bool SaveEmployee(Employee employee);
        List<Employee> GetEmployees();
        bool UpdateEmployee(Employee employee);
        void DeleteEmployee(int id);

    }
}
