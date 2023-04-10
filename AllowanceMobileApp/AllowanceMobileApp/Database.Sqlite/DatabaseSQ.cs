using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using AllowanceMobileApp.Model;
using System.Threading.Tasks;

namespace AllowanceMobileApp.Model
{
    //identify your unique object in your database.
    public class DatabaseSQ
    {
        readonly SQLiteAsyncConnection database;
        internal object upload;

        public DatabaseSQ(string dbPath)
        {
            database = new SQLiteAsyncConnection(dbPath);
            database.CreateTableAsync<EmployeeAllowanceDetails>().Wait();
        }
        public Task<List<EmployeeAllowanceDetails>> GetEmployeeAllowance()
        {
            return database.Table<EmployeeAllowanceDetails>().ToListAsync();
        }

        public async Task<bool> SaveEmployeeAllowance(List<EmployeeAllowanceDetails> allowanceMaster)
        {
           
                await database.InsertAllAsync(allowanceMaster);
            
            return true;
        }



        public async Task<bool> DeleteEmployeeAllowance(List<EmployeeAllowanceDetails> employeAllowance)
        {
            foreach (var emp in employeAllowance)
            {
               
                await database.DeleteAsync(emp);
            }
            return true;
        }
    }

}
