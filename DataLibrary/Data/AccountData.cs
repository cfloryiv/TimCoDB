using DataLibrary.Db;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using DataLibrary.Models;

namespace DataLibrary.Data
{
    public interface IAccountData
    {
        Task<List<AccountModel>> GetAccounts();
        Task<int> CreateAccount(AccountModel Account);
        Task<AccountModel> GetAccountById(string AccountNumber, string ClassID);
        Task<int> DeleteAccount(string AccountNumber, string ClassID);
        Task<int> UpdateAccount(AccountModel Account);
    }

    public class AccountData : IAccountData
    {
        private readonly IDataAccess _dataAccess;
        private readonly ConnectionStringData _connectionString;

        public AccountData(IDataAccess dataAccess, ConnectionStringData connectionString)
        {
            _dataAccess = dataAccess;
            _connectionString = connectionString;
        }
        public Task<List<AccountModel>> GetAccounts()
        {
            return _dataAccess.LoadData<AccountModel, dynamic>("dbo.spAccounts_All",
                new { },
                _connectionString.SqlConnectionName);
        }
        public async Task<int> CreateAccount(AccountModel Account)
        {
            DynamicParameters p = new DynamicParameters();

            p.Add("AccountNumber", Account.AccountNumber);
            p.Add("ClassID", Account.ClassID);
            p.Add("Description", Account.Description);
            p.Add("Type", Account.Type);

            await _dataAccess.SaveData("dbo.spAccounts_Insert", p, _connectionString.SqlConnectionName);

            return 0;
        }
        public async Task<int> UpdateAccount(AccountModel Account)
        {
            DynamicParameters p = new DynamicParameters();

            p.Add("AccountNumber", Account.AccountNumber);
            p.Add("ClassID", Account.ClassID);
            p.Add("Description", Account.Description);
            p.Add("Type", Account.Type);

            await _dataAccess.SaveData("dbo.spAccounts_Update", p, _connectionString.SqlConnectionName);
            return 0;
        }
        public async Task<AccountModel> GetAccountById(string AccountNumber, string ClassID)
        {
            var recs = await _dataAccess.LoadData<AccountModel, dynamic>("dbo.spAccounts_GetById",
                new
                {
                    AccountNumber=AccountNumber,
                    ClassID=ClassID
                },
                _connectionString.SqlConnectionName);

            return recs.FirstOrDefault();
        }
        public Task<int> DeleteAccount(string AccountNumber, string ClassID)
        {
            return _dataAccess.SaveData("dbo.spAccounts_Delete",
                new
                {
                    AccountNumber=AccountNumber,
                    ClassID=ClassID
                },
                _connectionString.SqlConnectionName);
        }
    }
}
