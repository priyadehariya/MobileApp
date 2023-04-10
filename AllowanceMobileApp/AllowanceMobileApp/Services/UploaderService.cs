using AllowanceMobileApp.Model;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace AllowanceMobileApp.Services
{
   public class UploaderService
    {
        public UploaderService()
        {
            Device.StartTimer(TimeSpan.FromSeconds(30), () =>
            {

                Device.BeginInvokeOnMainThread(() =>
                UploadAllowance()
                );
                return true;
            });
        }

     public void UploadAllowance()
        {
            List<EmployeeAllowanceDetails> app = App.Database.GetEmployeeAllowance().Result;
            AllowanceService service = new AllowanceService();
            //var  response = service.SaveAllowance(app);

            if (app != null)
            {
               bool APIresult= service.SaveAllowance(app);
                if (APIresult == true)
                {
                    _ = App.Database.DeleteEmployeeAllowance(app).Result;
                    //Application.Current.MainPage.DisplayAlert("Successfull", " Employee Allowance  Successfully Saved ", "OK");
                }
               
            }
           


        }




    }
}
