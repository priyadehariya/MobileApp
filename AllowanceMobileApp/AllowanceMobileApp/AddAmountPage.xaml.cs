using AllowanceMobileApp.Model;
using AllowanceMobileApp.Services;
using AllowanceMobileApp.ViewModel;
using AndroidX.Lifecycle;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AllowanceMobileApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddAmountPage : ContentPage
    {
       
        AllowanceViewModel _viewModel;

        private bool _allChecked;
        private object allowances;

        public AddAmountPage()
        {
            InitializeComponent();
            BindingContext = _viewModel = new AllowanceViewModel();
            
        }

        private void Checkbox_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            try
            {
                int totalEmployee = _viewModel.EmplyeeItems.Count();
                int selectEmployee = _viewModel.EmplyeeItems.Where(emp => emp.IsSelect).Count();
                SelectAll.IsChecked = totalEmployee == selectEmployee;

            }
            catch (Exception ex)
            {
                throw ex;
            }


        }

        //public bool AllChecked
        //{
        //    get => _allChecked;
        //    set
        //    {
        //        if (value != _allChecked)
        //        {
        //            UpdateCompaniesCollection(value);
        //            OnPropertyChanged(nameof(AllChecked));
        //        }
        //    }
        //}


        //void UpdateCompaniesCollection(bool newValue)
        //{

        //    foreach (var Employee in totalEmployee)
        //    {
        //        SelectEmployee.Add(Employee);
        //    }
        //}

    }
}

