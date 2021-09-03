using EmployeeInformationApp_Agile.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EmployeeInformationApp_Agile
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class StartPage : ContentPage
    {
        public StartPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            PopulateEmployeeList();
        }

        public void PopulateEmployeeList()
        {
            EmployeeList.ItemsSource = null;
            EmployeeList.ItemsSource = DependencyService.Get<ISQLite>().GetEmployees();
        }

        private void AddEmployee_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new MainPage());
        }

        private void EditEmployee(object sender, ItemTappedEventArgs e)
        {
            Employee details = e.Item as Employee;
            if (details != null)
            {
                Navigation.PushAsync(new MainPage(details));
            }
        }
        private async void DeleteEmploye(object sender, EventArgs e)
        {
            bool res = await DisplayAlert("Message", "Do you want to delete employee?", "Ok", "Cancel");
            if (res)
            {
                var menu = sender as MenuItem;
                Employee employee = menu.CommandParameter as Employee;
                DependencyService.Get<ISQLite>().DeleteEmployee(employee.ID);
                PopulateEmployeeList();
            }
        }

            
    }
}