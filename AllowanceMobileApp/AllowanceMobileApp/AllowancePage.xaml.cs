using AllowanceMobileApp.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;
using Xamarin.Forms.Xaml;
using TimePicker = Xamarin.Forms.TimePicker;

namespace AllowanceMobileApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AllowancePage : ContentPage
    {
       
        public AllowancePage()
        {
            InitializeComponent();
           BindingContext = new AllowanceViewModel();

            Device.StartTimer(TimeSpan.FromSeconds(1), () =>
            {

                time.Text = DateTime.Now.ToString("hh:mm:ss tt");
                return true;
            }); 
        }


  


        private void btn_Clicked(object sender,EventArgs e)
        {
            Navigation.PushModalAsync(new AddAmountPage());
        }

        //Event handlers are used in graphical user interface (GUI) applications to handle events such as button clicks
    }
}