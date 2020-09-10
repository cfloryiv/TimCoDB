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
    public interface IMedicalVisitData
    {
        public Task<List<MedicalVisitModel>> GetMedicalVisits();
        public Task<int> CreateMedicalVisit(MedicalVisitModel MedicalVisit);
        Task<MedicalVisitModel> GetMedicalVisitById(int bookId);
        Task<int> DeleteMedicalVisit(int Id);
        Task<int> UpdateMedicalVisit(MedicalVisitModel MedicalVisit);
    }

    public class MedicalVisitData : IMedicalVisitData
    {
        private readonly IDataAccess _dataAccess;
        private readonly ConnectionStringData _connectionString;

        public MedicalVisitData(IDataAccess dataAccess, ConnectionStringData connectionString)
        {
            _dataAccess = dataAccess;
            _connectionString = connectionString;
        }
        public Task<List<MedicalVisitModel>> GetMedicalVisits()
        {
            return _dataAccess.LoadData<MedicalVisitModel, dynamic>("dbo.spMedicalVisits_All",
                new { },
                _connectionString.SqlConnectionName);
        }
        public async Task<int> CreateMedicalVisit(MedicalVisitModel MedicalVisit)
        {
            DynamicParameters p = new DynamicParameters();
  
            p.Add("Doctor", MedicalVisit.Doctor);
            p.Add("Notes", MedicalVisit.Notes);

            p.Add("Type", MedicalVisit.Type);
            p.Add("PersonID", MedicalVisit.PersonID);
            p.Add("Date", MedicalVisit.Date);


            p.Add("ID", System.Data.DbType.Int32, direction: ParameterDirection.Output);

            await _dataAccess.SaveData("dbo.spMedicalVisits_Insert", p, _connectionString.SqlConnectionName);

            return p.Get<int>("ID");
        }
        public async Task<int> UpdateMedicalVisit(MedicalVisitModel MedicalVisit)
        {
            DynamicParameters p = new DynamicParameters();

            p.Add("Doctor", MedicalVisit.Doctor);
            p.Add("Notes", MedicalVisit.Notes);

            p.Add("Type", MedicalVisit.Type);
            p.Add("PersonID", MedicalVisit.PersonID);
            p.Add("Date", MedicalVisit.Date);
            p.Add("ID", MedicalVisit.ID);

            await _dataAccess.SaveData("dbo.spMedicalVisits_Update", p, _connectionString.SqlConnectionName);

            return MedicalVisit.ID;
        }
        public async Task<MedicalVisitModel> GetMedicalVisitById(int bookId)
        {
            var recs = await _dataAccess.LoadData<MedicalVisitModel, dynamic>("dbo.spMedicalVisits_GetById",
                new
                {
                    ID = bookId
                },
                _connectionString.SqlConnectionName);

            return recs.FirstOrDefault();
        }
        public Task<int> DeleteMedicalVisit(int Id)
        {
            return _dataAccess.SaveData("dbo.spMedicalVisits_Delete",
                new
                {
                    ID = Id
                },
                _connectionString.SqlConnectionName);
        }
    }
}
