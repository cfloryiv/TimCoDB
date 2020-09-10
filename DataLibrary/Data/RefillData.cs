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
    public interface IRefillData
    {
        public Task<List<RefillModel>> GetRefills();
        public Task<int> CreateRefill(RefillModel Refill);
        Task<RefillModel> GetRefillById(int bookId);
        Task<int> DeleteRefill(int Id);
        Task<int> UpdateRefill(RefillModel Refill);
    }

    public class RefillData : IRefillData
    {
        private readonly IDataAccess _dataAccess;
        private readonly ConnectionStringData _connectionString;

        public RefillData(IDataAccess dataAccess, ConnectionStringData connectionString)
        {
            _dataAccess = dataAccess;
            _connectionString = connectionString;
        }
        public Task<List<RefillModel>> GetRefills()
        {
            return _dataAccess.LoadData<RefillModel, dynamic>("dbo.spRefills_All",
                new { },
                _connectionString.SqlConnectionName);
        }
        public async Task<int> CreateRefill(RefillModel Refill)
        {
            DynamicParameters p = new DynamicParameters();
/*         public string Name { get; set; }
        public DateTime Date { get; set; }
        public int PillSize { get; set; }
        public decimal Cost { get; set; }
        public int PersonID { get; set; }
        public int Period { get; set; }
        public string Doctor { get; set; }
*/
            p.Add("Name", Refill.Name);
            p.Add("Date", Refill.Date);
            p.Add("PillSize", Refill.PillSize);
            p.Add("Cost", Refill.Cost);
            p.Add("PersonID", Refill.PersonID);
            p.Add("Period", Refill.Period);
            p.Add("Doctor", Refill.Doctor);


            p.Add("ID", System.Data.DbType.Int32, direction: ParameterDirection.Output);

            await _dataAccess.SaveData("dbo.spRefills_Insert", p, _connectionString.SqlConnectionName);

            return p.Get<int>("ID");
        }
        public async Task<int> UpdateRefill(RefillModel Refill)
        {
            DynamicParameters p = new DynamicParameters();
            /*         public string Name { get; set; }
                    public DateTime Date { get; set; }
                    public int PillSize { get; set; }
                    public decimal Cost { get; set; }
                    public int PersonID { get; set; }
                    public int Period { get; set; }
                    public string Doctor { get; set; }
            */
            p.Add("Name", Refill.Name);
            p.Add("Date", Refill.Date);
            p.Add("PillSize", Refill.PillSize);
            p.Add("Cost", Refill.Cost);
            p.Add("PersonID", Refill.PersonID);
            p.Add("Period", Refill.Period);
            p.Add("Doctor", Refill.Doctor);
            p.Add("ID", Refill.ID);

            await _dataAccess.SaveData("dbo.spRefills_Update", p, _connectionString.SqlConnectionName);

            return Refill.ID;
        }
        public async Task<RefillModel> GetRefillById(int bookId)
        {
            var recs = await _dataAccess.LoadData<RefillModel, dynamic>("dbo.spRefills_GetById",
                new
                {
                    ID = bookId
                },
                _connectionString.SqlConnectionName);

            return recs.FirstOrDefault();
        }
        public Task<int> DeleteRefill(int Id)
        {
            return _dataAccess.SaveData("dbo.spRefills_Delete",
                new
                {
                    ID = Id
                },
                _connectionString.SqlConnectionName);
        }
    }
}
