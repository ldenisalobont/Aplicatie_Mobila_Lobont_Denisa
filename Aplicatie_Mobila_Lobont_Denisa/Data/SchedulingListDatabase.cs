using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Aplicatie_Mobila_Lobont_Denisa.Models;
using Nume_Pren_Lab10.Models;
using SQLite;

namespace Aplicatie_Mobila_Lobont_Denisa.Data
{
    public class SchedulingListDatabase
    {
        readonly SQLiteAsyncConnection _database;
        public SchedulingListDatabase(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<SchedulingList>().Wait();
            _database.CreateTableAsync<Service>().Wait();
            _database.CreateTableAsync<ListService>().Wait();
        }
        public Task<int> SaveServiceAsync(Service service)
        {
            if (service.ID != 0)
            {
                return _database.UpdateAsync(service);
            }
            else
            {
                return _database.InsertAsync(service);
            }
        }
        public Task<int> DeleteServiceAsync(Service service)
        {
            return _database.DeleteAsync(service);
        }
        public Task<List<Service>> GetServicesAsync()
        {
            return _database.Table<Service>().ToListAsync();
        }
        public Task<List<SchedulingList>> GetSchedulingListsAsync()
        {
            return _database.Table<SchedulingList>().ToListAsync();
        }
        public Task<SchedulingList> GetSchedulingListAsync(int id)
        {
            return _database.Table<SchedulingList>()
            .Where(i => i.ID == id)
           .FirstOrDefaultAsync();
        }

        public Task<int> SaveSchedulingListAsync(SchedulingList plist)
        {
            if (plist.ID != 0)
            {
                return _database.UpdateAsync(plist);
            }
            else
            {
                return _database.InsertAsync(plist);
            }
        }
        public Task<int> DeleteSchedulingListAsync(SchedulingList plist)
        {
            return _database.DeleteAsync(plist);
        }
        public Task<int> SaveListServiceAsync(ListService listp)
        {
            if (listp.ID != 0)
            {
                return _database.UpdateAsync(listp);
            }
            else
            {
                return _database.InsertAsync(listp);
            }
        }
        public Task<List<Service>> GetListServicesAsync(int shoplistid)
        {
            return _database.QueryAsync<Service>(
            "select P.ID, P.Description from Service P"
            + " inner join ListService LP"
            + " on P.ID = LP.ServiceID where LP.SchedulingListID = ?",
            shoplistid);
        } 
    }
}
