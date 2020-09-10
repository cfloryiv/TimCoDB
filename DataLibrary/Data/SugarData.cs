using DataLibrary.Db;
using DataLibrary.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace DataLibrary.Data
{
    public interface ISugarData
    {
        Task<List<SugarModel>> GetSugars();
        Task<int> CreateSugar(SugarModel Sugar);
        Task<int> UpdateSugar(SugarModel Sugar);
        Task<SugarModel> GetSugarById(int SugarId);
        Task<int> DeleteSugar(int Id);
    }

    public class SugarData : ISugarData
    {
        private readonly IDataAccess _dataAccess;
        private readonly ConnectionStringData _connectionString;

        public SugarData(IDataAccess dataAccess, ConnectionStringData connectionString)
        {
            _dataAccess = dataAccess;
            _connectionString = connectionString;
        }
        public Task<List<SugarModel>> GetSugars()
        {
            return _dataAccess.LoadData<SugarModel, dynamic>("dbo.spSugars_All",
                new { },
                _connectionString.SqlConnectionName);
        }
        public async Task<int> CreateSugar(SugarModel Sugar)
        {
            DynamicParameters p = new DynamicParameters();

            p.Add("Level", Sugar.Level);
            p.Add("Date", Sugar.Date);

            p.Add("ID", System.Data.DbType.Int32, direction: ParameterDirection.Output);

            await _dataAccess.SaveData("dbo.spSugars_Insert", p, _connectionString.SqlConnectionName);

            return p.Get<int>("ID");
        }
        public async Task<int> UpdateSugar(SugarModel Sugar)
        {
            DynamicParameters p = new DynamicParameters();

            p.Add("Level", Sugar.Level);
            p.Add("Date", Sugar.Date);
            p.Add("ID", Sugar.ID);

            await _dataAccess.SaveData("dbo.spSugars_Update", p, _connectionString.SqlConnectionName);
            return Sugar.ID;
        }
        public async Task<SugarModel> GetSugarById(int SugarId)
        {
            var recs = await _dataAccess.LoadData<SugarModel, dynamic>("dbo.spSugars_GetById",
                new
                {
                    ID = SugarId
                },
                _connectionString.SqlConnectionName);

            return recs.FirstOrDefault();
        }
        public Task<int> DeleteSugar(int Id)
        {
            return _dataAccess.SaveData("dbo.spSugars_Delete",
                new
                {
                    ID = Id
                },
                _connectionString.SqlConnectionName);
        }
    }
}
