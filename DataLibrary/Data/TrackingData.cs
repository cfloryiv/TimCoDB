using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using DataLibrary.Db;
using DataLibrary.Models;

namespace DataLibrary.Data
{
    public interface ITrackingData
    {
        public Task<List<TrackingModel>> GetTrackings();
        public Task<int> CreateTracking(TrackingModel Tracking);
        Task<TrackingModel> GetTrackingById(int bookId);
        Task<int> DeleteTracking(int Id);
        Task<int> UpdateTracking(TrackingModel Tracking);
    }

    public class TrackingData : ITrackingData
    {
        private readonly IDataAccess _dataAccess;
        private readonly ConnectionStringData _connectionString;

        public TrackingData(IDataAccess dataAccess, ConnectionStringData connectionString)
        {
            _dataAccess = dataAccess;
            _connectionString = connectionString;
        }
        public Task<List<TrackingModel>> GetTrackings()
        {
            return _dataAccess.LoadData<TrackingModel, dynamic>("dbo.spTrackings_All",
                new { },
                _connectionString.SqlConnectionName);
        }
        public async Task<int> CreateTracking(TrackingModel Tracking)
        {
            DynamicParameters p = new DynamicParameters();
            /*
             *         public DateTime Date { get; set; }
                    public String Qty { get; set; }
                    public int PersonID { get; set; }
             */
            p.Add("Date", Tracking.Date);
            p.Add("Qty", Tracking.Qty);
            p.Add("PersonID", Tracking.PersonID);
            p.Add("Item", Tracking.Item);
            p.Add("Depleted", Tracking.Depleted);
            p.Add("DepletedDate", Tracking.DepletedDate);


            p.Add("ID", System.Data.DbType.Int32, direction: ParameterDirection.Output);

            await _dataAccess.SaveData("dbo.spTrackings_Insert", p, _connectionString.SqlConnectionName);

            return p.Get<int>("ID");
        }
        public async Task<int> UpdateTracking(TrackingModel Tracking)
        {
            DynamicParameters p = new DynamicParameters();
            /*
             *         public DateTime Date { get; set; }
                    public String Qty { get; set; }
                    public int PersonID { get; set; }
             */
            p.Add("Date", Tracking.Date);
            p.Add("Qty", Tracking.Qty);
            p.Add("PersonID", Tracking.PersonID);
            p.Add("Item", Tracking.Item);
            p.Add("Depleted", Tracking.Depleted);
            p.Add("DepletedDate", Tracking.DepletedDate);
            p.Add("ID", Tracking.ID);

            await _dataAccess.SaveData("dbo.spTrackings_Update", p, _connectionString.SqlConnectionName);

            return Tracking.ID;
        }
        public async Task<TrackingModel> GetTrackingById(int bookId)
        {
            var recs = await _dataAccess.LoadData<TrackingModel, dynamic>("dbo.spTrackings_GetById",
                new
                {
                    ID = bookId
                },
                _connectionString.SqlConnectionName);

            return recs.FirstOrDefault();
        }
        public Task<int> DeleteTracking(int Id)
        {
            return _dataAccess.SaveData("dbo.spTrackings_Delete",
                new
                {
                    ID = Id
                },
                _connectionString.SqlConnectionName);
        }
    }
}
