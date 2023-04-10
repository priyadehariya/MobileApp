using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;

namespace AllowanceMobileApp.Model
{
  public  class AllowanceMaster : INotifyPropertyChanged
    {
        internal bool isUploaded;

        public event PropertyChangedEventHandler PropertyChanged;
      //  private bool isSelect;

        public long EmployeeKey { get; set; }
       
        public int AllowanceId { get; set; }
        public string AllowanceName { get; set; }
       
        public decimal AllowanceAmount { get; set; }
      
    }
}
