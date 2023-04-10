using AllowanceMobileApp.Model;
using AllowanceMobileApp.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text;
using Xamarin.Forms;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http.Headers;

namespace AllowanceMobileApp.ViewModel
{
    public class AllowanceViewModel : INotifyPropertyChanged
    {
        //UploaderService upload = new UploaderService();

        public event PropertyChangedEventHandler PropertyChanged;

        public List<Employee> EmplyeeItems { get; set; }

        public List<EmployeeAllowanceDetails> EmployeeAllowancelist;
        public AllowanceMaster SelectedAllowance { get; set; }
        public decimal Amount { get; set; }
        public decimal AllowanceAmount { get; set; }
        public Command DoneCommand { get; }
        public List<AllowanceMaster> allowances { get; set; }

        public ObservableCollection<AllowanceMaster> user { get; set; }
       



        public AllowanceViewModel()
        {

            EmployeeAllowancelist = new List<EmployeeAllowanceDetails>();

            EmployeeData();
            AllowanceData();
            //Userdata();

            DoneCommand = new Command(DoneButton_Clicked);
        }

        public List<Employee> EmployeeData()
        {
            AllowanceService EmpServices = new AllowanceService();
            EmplyeeItems = (List<Employee>)EmpServices.RefreshDataAsync();
            return EmplyeeItems;
        }

        public void AllowanceData()
        {
            AllowanceService AllowanceService = new AllowanceService();
            allowances = (List<AllowanceMaster>)AllowanceService.GetAllowance();

        }

        public async void DoneButton_Clicked()
        {

            UploaderService upload = new UploaderService();
            var Allowanceservice = new AllowanceService();
            decimal amount = Amount;
            int allowanceID = SelectedAllowance.AllowanceId;
            List<EmployeeAllowanceDetails> EmpallowanceList = new List<EmployeeAllowanceDetails>();
            AllowanceMaster allowances = new AllowanceMaster();

             foreach (var emp in EmplyeeItems)
            {
                if (emp.IsSelect && amount > 0)
                {
                    EmployeeAllowanceDetails Empallowance = new EmployeeAllowanceDetails
                    {
                        EmployeeKey = emp.EmployeeKey,
                        AllowanceId = allowanceID,
                        ClockDate = DateTime.Now,
                        AllowanceAmount = amount,
                     

                    };
                    // App.Database.SaveAllowance(Empallowance);
                 //   _ =App.Database.SaveEmployeeAllowance(Empallowance);



                    EmployeeAllowancelist.Add(Empallowance);
                }


            }
            if (EmployeeAllowancelist.Count > 0)
            {
                //   _ = Allowanceservice.SaveAllowance(EmployeeAllowancelist);
                _ = App.Database.SaveEmployeeAllowance(EmployeeAllowancelist);
              
                upload.UploadAllowance();
              await  Application.Current.MainPage.DisplayAlert("Successfull", " Employee Allowance  Successfully Saved ", "OK");


            }
            else
            {
              await   App.Current.MainPage.DisplayAlert("Warning", " Please Add atleast one allowance ", "OK");

            }

        }

    }
}