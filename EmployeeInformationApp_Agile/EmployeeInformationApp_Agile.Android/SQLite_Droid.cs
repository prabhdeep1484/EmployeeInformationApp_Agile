using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using EmployeeInformationApp_Agile.Droid;
using EmployeeInformationApp_Agile.Model;
using SQLite;
using Xamarin.Forms;

[assembly: Dependency(typeof(SQLite_Droid))]
namespace EmployeeInformationApp_Agile.Droid
{
    public class SQLite_Droid : ISQLite
    {
        SQLiteConnection con;

        public void DeleteEmployee(int id)
        {
            string sql = $"Delete From Employee where ID={id}";
            con.Execute(sql);
        }

        public SQLiteConnection GetConnection()
        {
            var dbName = "EmployeeDB.db3";
            var dbPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            var path = Path.Combine(dbPath, dbName);
            con = new SQLiteConnection(path);
            con.CreateTable<Employee>();
            return con;
        }

        public List<Employee> GetEmployees()
        {
            string sql = "Select * from Employee";
            List<Employee> employees = con.Query<Employee>(sql);
            return employees;
        }

        public bool SaveEmployee(Employee employee)
        {
            bool flag = false;
            try
            {
                con.Insert(employee);
                flag = true;

            }
            catch (Exception)
            {
                flag = false;
            }
            return flag;
        }

        public bool UpdateEmployee(Employee employee)
        {
            bool res = false;
            try
            {
                string sql = $"UPDATE Employee set Name='{employee.Name}',Address='{employee.Address}',PhoneNumber='{employee.PhoneNumber}', Email='{employee.Email}' where ID='{employee.ID}'";

                con.Execute(sql);
                res = true;
            }
            catch (Exception ex)
            {

                res = false;

            }
            return res;
        }
    }
}