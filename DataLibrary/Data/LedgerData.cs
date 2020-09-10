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
    public interface ILedgerData
    {
        public Task<List<LedgerModel>> GetLedgers();
        public Task<int> CreateLedger(LedgerModel Ledger);
        Task<LedgerModel> GetLedgerById(int bookId);
        Task<int> DeleteLedger(int Id);
        Task<int> UpdateLedger(LedgerModel Ledger);
        Task<int> DeleteLedgerByYear(int Year);
        Task<List<LedgerModel>> GetLedgerByYear(int Year);


    }

    public class LedgerData : ILedgerData
    {
        private readonly IDataAccess _dataAccess;
        private readonly ConnectionStringData _connectionString;

        public LedgerData(IDataAccess dataAccess, ConnectionStringData connectionString)
        {
            _dataAccess = dataAccess;
            _connectionString = connectionString;
        }

        public Task<List<LedgerModel>> GetLedgers()
        {
            return _dataAccess.LoadData<LedgerModel, dynamic>("dbo.spLedgers_All",
                new { },
                _connectionString.SqlConnectionName);
        }

        public async Task<int> CreateLedger(LedgerModel Ledger)
        {
            DynamicParameters p = new DynamicParameters();

            p.Add("AccountNumber", Ledger.AccountNumber);
            p.Add("ClassID", Ledger.ClassID);
            p.Add("Year", Ledger.Year);
            p.Add("Budget", Ledger.Budget);
            p.Add("Actual", Ledger.Actual);


            p.Add("ID", System.Data.DbType.Int32, direction: ParameterDirection.Output);

            await _dataAccess.SaveData("dbo.spLedgers_Insert", p, _connectionString.SqlConnectionName);

            return p.Get<int>("ID");
        }

        public async Task<int> UpdateLedger(LedgerModel Ledger)
        {
            DynamicParameters p = new DynamicParameters();

            p.Add("AccountNumber", Ledger.AccountNumber);
            p.Add("ClassID", Ledger.ClassID);
            p.Add("Year", Ledger.Year);
            p.Add("Budget", Ledger.Budget);
            p.Add("Actual", Ledger.Actual);
            p.Add("ID", Ledger.ID);

            await _dataAccess.SaveData("dbo.spLedgers_Update", p, _connectionString.SqlConnectionName);
            return Ledger.ID;
        }

        public async Task<LedgerModel> GetLedgerById(int LedgerId)
        {
            var recs = await _dataAccess.LoadData<LedgerModel, dynamic>("dbo.spLedgers_GetById",
                new
                {
                    ID = LedgerId
                },
                _connectionString.SqlConnectionName);

            return recs.FirstOrDefault();
        }

        public Task<int> DeleteLedger(int Id)
        {
            return _dataAccess.SaveData("dbo.spLedgers_Delete",
                new
                {
                    ID = Id
                },
                _connectionString.SqlConnectionName);
        }

        public Task<int> DeleteLedgerByYear(int Year)
        {
            return _dataAccess.SaveData("dbo.spLedgers_Delete_Year",
                new
                {
                    Year = Year
                },
                _connectionString.SqlConnectionName);
        }

        public async Task<List<LedgerModel>> GetLedgerByYear(int Year)
        {
            var recs = await _dataAccess.LoadData<LedgerModel, dynamic>("dbo.spLedgersByYear",
                new
                {
                    Year = Year
                },
                _connectionString.SqlConnectionName);

            return recs;
        }
    }
}
