using EmployeeInformationApp_Agile.Model;
using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace EmployeeInformationApp_Agile
{
    public partial class MainPage : ContentPage
    {
        Employee employeeDetails;
        public MainPage()
        {
            InitializeComponent();
        }
        public MainPage(Employee employee)
        {
            InitializeComponent();
            employeeDetails = employee;
            PopulateDetails(employeeDetails);
        }

        private void PopulateDetails(Employee details)
        {
            Name.Text = details.Name;
            Address.Text = details.Address;
            PhoneNumber.Text = details.PhoneNumber;
            Email.Text = details.Email;
            Password.IsEnabled = false;
            SaveButton.Text = "Update";
            this.Title = "Update Employee";
        }

        private void SaveButton_Clicked(object sender, EventArgs e)
        {
            if (SaveButton.Text == "Save")
            {
                Employee employee = new Employee();
                employee.Name = Name.Text;
                employee.Address = Address.Text;
                employee.PhoneNumber = PhoneNumber.Text;
                employee.Email = Email.Text;
                employee.Password = Password.Text;
                bool response = DependencyService.Get<ISQLite>().SaveEmployee(employee);
                if (response)
                {
                    //DisplayAlert("Message", "Employee has successfully saved", "OK");
                    Navigation.PopAsync();
                }
                else
                {
                    DisplayAlert("Message", "Employee has failed to save", "OK");
                }
            }
            else
            {
                employeeDetails.Name = Name.Text;
                employeeDetails.Address = Address.Text;
                employeeDetails.PhoneNumber = PhoneNumber.Text;
                employeeDetails.Email = Email.Text;
                bool response= DependencyService.Get<ISQLite>().UpdateEmployee(employeeDetails);
                if(response)
                {
                    Navigation.PopAsync();
                }
                else
                {
                    DisplayAlert("Message", "Employee has failed to update", "OK");
                }
            }
            

        }

    }
}
