
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AllowanceMobileApp
{

  
    public partial class MainPage : ContentPage
    {

        public object Text { get; set; }
       public object page { get; set; }

        public MainPage()
        {
            InitializeComponent();
            Text = "AllowanceApp-LogIn";
            BindingContext = new AllowancePage();
        }

        //The sender is the event raising object, and the e variable is the event arguments
        private void Loginbtn_Clicked(object sender, EventArgs e)
        {
            //null or empty field validation, check weather email and password is null or empty  
            if (string.IsNullOrEmpty(UserID.Text) || string.IsNullOrEmpty(Password.Text))
            {
                DisplayAlert("Empty Values", "Please enter UserID and Password", "OK");
            }
            else
            {
                if (UserID.Text == "A" && Password.Text == "p")
                {
                    _ = App.Database.GetEmployeeAllowance().Result;
                    Navigation.PushModalAsync(new AllowancePage()); ;
                }
                else
                    _ = DisplayAlert("Login Fail", "Please enter correct UserID and Password", "OK");
            }
        }
    }
}
                                                            