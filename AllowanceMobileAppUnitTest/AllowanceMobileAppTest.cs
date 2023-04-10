using AllowanceMobileApp;
using AllowanceMobileApp.Model;
using AllowanceMobileApp.Services;
using AllowanceMobileApp.ViewModel;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace AllowanceMobileAppUnitTest
{
    class AllowanceMobileAppTest
    {
        //private List<AllowanceMaster> allowances;

        public static AllowanceViewModel ViewModel { get; private set; }
       // public object ItemsSource { get; private set; }

        [SetUp]
        public void Setup()
        {
           Xamarin.Forms.Mocks.MockForms.Init();
            ViewModel = new AllowanceViewModel();
        }

       

        [Test]
        public void  IsCheck_Count_AllowanceList()
        {
            //Arrange
            //var allowanceService = new AllowanceService();
            var allowanceService = new AllowanceService();
            int expectedAllowanceCount = 5;
            //Action
            IEnumerable<AllowanceMaster> allowances = allowanceService.GetAllowance();
            List<AllowanceMaster> ResultService = allowances as List<AllowanceMaster>;
            int ActualResultAllowanceCount = ResultService.Count;
            //Assert
            Assert.AreEqual(expectedAllowanceCount, ActualResultAllowanceCount);
        }
        [Test]
        public void IsCheck_InvalidCount_Of_AllowanceList()
        {
            //Arrange
            //var allowanceService = new AllowanceService();
            var allowanceService = new AllowanceService();
            int expectedAllowanceCount = 6;
            //Action
            IEnumerable<AllowanceMaster> allowances = allowanceService.GetAllowance();
            List<AllowanceMaster> ResultService = allowances as List<AllowanceMaster>;
            int ActualResultAllowanceCount = ResultService.Count;
            //Assert
            Assert.AreEqual(expectedAllowanceCount, ActualResultAllowanceCount);
        }

        [Test]
        public void IsCheck_AllowanceCount_InStackLayoutTest()
        {
            //Arrange
            var countAllowance = new AllowanceViewModel();
            int expectedAllowanceCount = 5;
            //Action
            var result = countAllowance.allowances;
            List<AllowanceMaster> Result = result as List<AllowanceMaster>;
            int ActualResultAllowanceCount = Result.Count;
            //Assert
            Assert.AreEqual(expectedAllowanceCount, ActualResultAllowanceCount);
        }

        [Test]
        public void IsCheck_InvalidAllowanceCount_InStackLayoutTest()
        {
            //Arrange
            var countAllowance = new AllowanceViewModel();
            int expectedAllowanceCount = 6;
            //Action
            var result = countAllowance.allowances;
            List<AllowanceMaster> Result = result as List<AllowanceMaster>;
            int ActualResultAllowanceCount = Result.Count;
            //Assert
            Assert.AreEqual(expectedAllowanceCount, ActualResultAllowanceCount);
        }


        [Test]
        public void IsCheck_PresentEmployeeCount_InCollectionView()
        {
            //Arrange
          
            var countPresentEmployee = new AllowanceViewModel();
            int ExpectedPresentEmployeeCount = 3;
            //Action
            var result = countPresentEmployee.EmplyeeItems;
            List<Employee> ResultEmployeeList = result as List<Employee>;
            int ActualResultPresentEmployeeCount = ResultEmployeeList.Count;
            //Assert
            Assert.AreEqual(ExpectedPresentEmployeeCount, ActualResultPresentEmployeeCount);
        }

        [Test]
        public void IsCheck_InvalidPresentEmployeeCount_InCollectionView()
        {
            //Arrange

            var countPresentEmployee = new AllowanceViewModel();
            int ExpectedPresentEmployeeCount = 6;
            //Action
            var result = countPresentEmployee.EmplyeeItems;
            List<Employee> ResultEmployeeList = result as List<Employee>;
            int ActualResultPresentEmployeeCount = ResultEmployeeList.Count;
            //Assert
            Assert.AreEqual(ExpectedPresentEmployeeCount, ActualResultPresentEmployeeCount);
        }


        [Test]
        public void IsCheck_Count_PresentEmployee()
        {
            //Arrange
         
            var allowanceService = new AllowanceService();
            int expectedPresentEmployeCount = 3;
            //Action
            IEnumerable<Employee> allowances = allowanceService.RefreshDataAsync();
            List<Employee> ResultService = allowances as List<Employee>;
            int ActualResultPresentEmployeCount = ResultService.Count;
            //Assert
            Assert.AreEqual(expectedPresentEmployeCount, ActualResultPresentEmployeCount);
        }

        [Test]
        public void IsCheck_InvalidCount_PresentEmployee()
        {
            //Arrange

            var allowanceService = new AllowanceService();
            int expectedPresentEmployeCount = 6;
            //Action
            IEnumerable<Employee> allowances = allowanceService.RefreshDataAsync();
            List<Employee> ResultService = allowances as List<Employee>;
            int ActualResultPresentEmployeCount = ResultService.Count;
            //Assert
            Assert.AreEqual(expectedPresentEmployeCount, ActualResultPresentEmployeCount);
        }



        [Test]
        public void IsCheck_AllowancePost()
        {
            //Arrange
            var objEmployee = new EmployeeAllowanceDetails
            {
                EmployeeKey = 43,
                AllowanceAmount = 700,
                AllowanceId = 3,
                ClockDate = DateTime.Now.Date
            };
            //Action
            List<EmployeeAllowanceDetails> PostAllowanceList = new List<EmployeeAllowanceDetails>();
            var AllowanceService = new AllowanceService();
            PostAllowanceList.Add(objEmployee);
            var result = AllowanceService.SaveAllowance(PostAllowanceList);
            //Assert
             Assert.IsTrue(result);  
        }

      

       
    }
}
