using AllowanceMobileApp.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Net.Http.Headers;

namespace AllowanceMobileApp.Services
{
    public class AllowanceService
    {
       
        private List<AllowanceMaster> allowances { get; set; }

       // private ObservableCollection<AllowanceMaster> user { get; set; }

        private List<Employee> EmplyeeItems { get; set; }


        public IEnumerable<AllowanceMaster> GetAllowance()
        { 
            var uri = new Uri("http://192.168.4.144/PiyaAPIs/api/EmployeeAllowanceDetails/AllowanceNameLists");
            var client = new HttpClient();
            var response = client.GetStringAsync(uri);
            allowances = JsonConvert.DeserializeObject<List<AllowanceMaster>>(response.Result);
            return allowances;
        }

        public IEnumerable<Employee> RefreshDataAsync()
        {
            var uri = new Uri("http://192.168.4.144/PiyaAPIs/api/EmployeeAllowanceDetails/PresentEmployees");
            HttpClient client = new HttpClient();
            var response = client.GetStringAsync(uri);
            EmplyeeItems = JsonConvert.DeserializeObject<List<Employee>>(response.Result);
            return EmplyeeItems;
        }

        public bool SaveAllowance(List<EmployeeAllowanceDetails> empAllowance)
        {

            string json = JsonConvert.SerializeObject(empAllowance);
            HttpContent httpContent = new StringContent(json);
            httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/Json");
            HttpClient Client = new HttpClient();
            var postList = Client.PostAsync("http://192.168.4.144/PiyaAPIs/api/EmployeeAllowanceDetails/postEmployeeAllowance", httpContent);
            return postList.Result.IsSuccessStatusCode;
        }

        //public bool (ObservableCollection<AllowanceMaster>) GetUserinfo()
        //{
        //    var uri = new Uri("http://192.168.4.141/PiyaAPIs/api/UserInfoes/UserInformation?UserName=Priya2000&Password=Priya@123");
        //    var client = new HttpClient();
        //    var response = client.GetStringAsync(uri);
        //    user = JsonConvert.DeserializeObject<ObservableCollection<AllowanceMaster>>(response.Result);
        //    return user;
        //}
    }



    }
