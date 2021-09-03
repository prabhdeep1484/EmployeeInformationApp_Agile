using SQLite;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EmployeeInformationApp_Agile
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            SQLiteConnection conn = DependencyService.Get<ISQLite>().GetConnection();
            MainPage = new NavigationPage(new StartPage());
            //MainPage = new MainPage();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
