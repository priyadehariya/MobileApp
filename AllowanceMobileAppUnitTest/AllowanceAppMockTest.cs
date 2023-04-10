using AllowanceMobileApp;
using AllowanceMobileApp.ViewModel;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Mocks;
using Xamarin.Forms.Xaml;

namespace AllowanceMobileAppUnitTest
{

    [TestFixture]
    class AllowanceAppMockTest
    {
        public static AllowanceAppMockTest App { get; private set; }
        public NavigationPage MainPage { get; private set; }

        [SetUp]
        public void SetUp()
        {
            MockForms.Init();
            App = new AllowanceAppMockTest();
        }



        [Test]
        public static void IsAppRunning()
        {
    //Tests whether the specified object is non-null and throws an exception if it is null. 
            Assert.NotNull(App);
        }

        //for checking Navigation MainPage to AddAmountPage

        [Test]
        public async Task IsCheck_Navigation_MainPage_To_AddAmountPage_NavigationStack()
        {
            var mainPage = new MainPage();
            var addAmountpage = new AddAmountPage();
            await mainPage.Navigation.PushAsync(addAmountpage);
            Assert.AreEqual(mainPage.Navigation.NavigationStack.Last(), addAmountpage);
        }

        //for checking Navigation MainPage to AllowancetPage

        [Test]
        public async Task IsCheck_Navigation_MainPage_To_AllowancePage_NavigationStack()
        {
            var mainPage = new MainPage();
            var allowancePage = new AllowancePage();
            await mainPage.Navigation.PushAsync(allowancePage);
            Assert.AreEqual(mainPage.Navigation.NavigationStack.Last(), allowancePage);
        }


        [Test]
        public async Task IsCheck_ReverseNavigation_MainPage_To_AllowancePage_NavigationStack()
        {
            var mainPage = new MainPage();
            var allowancePage = new AllowancePage();
            await mainPage.Navigation.PushAsync(allowancePage);
            await allowancePage.Navigation.PushAsync(mainPage);
            Assert.AreEqual(allowancePage.Navigation.NavigationStack.Last(), mainPage);
        }

        [Test]
        public void IsCheck_MainPageTitle()
        {
            //Arrange
            var title = new MainPage();
            var ExpectedTitle = "AllowanceApp-LogIn";
            //Action
            var ActualTitle = title.Text;
            //Assert
            Assert.AreEqual(ActualTitle, ExpectedTitle);
        }

        [Test]
        public void DoneButtonClickTest()
        {
            var addAllowancePage = new AllowanceViewModel();
            addAllowancePage.DoneCommand.ChangeCanExecute();

        }




        //for checking Device
        [Test]
       // [Obsolete]
        public void RuntimePlatformAndroid()
        {
            MockForms.Init(Device.Android);

            Assert.AreEqual(Device.Android, Device.RuntimePlatform);
            Assert.AreEqual(TargetPlatform.Android, Device.OS);
        }

        //for checking Timer
        //[Test]
        //public async Task StartTimer()
        //{
        //    MockForms.Init();

        //    var source = new TaskCompletionSource<bool>();

        //    Device.StartTimer(TimeSpan.FromSeconds(30), () =>
        //    {
        //        source.SetResult(true);
        //        return false;
        //    });

            //    Assert.IsTrue(await source.Task);
            //}

            //    [Test]
            //    public void DeviceInfo()
            //    {
            //        //Device.Info is EditorBrowsable.Never, but is used internally by Master/Detail template
            //        MockForms.Init();
            //        Device.Info.ToString();
            //    }
        }

}
