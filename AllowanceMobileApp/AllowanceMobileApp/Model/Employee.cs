using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace AllowanceMobileApp.Model
{
   
    

      public class Employee : INotifyPropertyChanged
        {
            

            public event PropertyChangedEventHandler PropertyChanged;
           

            public long EmployeeKey { get; set; }
            public string EmployeeName { get; set; }
            public bool IsSelect { get; set; }
            public bool AllChecked { get; set; }
        }

    
}
