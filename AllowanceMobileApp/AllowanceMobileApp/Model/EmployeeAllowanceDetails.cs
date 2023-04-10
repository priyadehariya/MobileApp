using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace AllowanceMobileApp.Model
{
    public class EmployeeAllowanceDetails 
    {
       

        [PrimaryKey, AutoIncrement]
        public int SerialNo { get; set; }
        public long EmployeeKey { get; set; }
       
        public int AllowanceId { get; set; }
     
        public DateTime ClockDate { get; set; }
        public decimal AllowanceAmount { get; set; }
       
    }


}
