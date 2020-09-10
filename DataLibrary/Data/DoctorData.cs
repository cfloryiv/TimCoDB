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
    public class DoctorData : IDoctorData
    {
        private readonly IDataAccess _dataAccess;
        private readonly ConnectionStringData _connectionString;

        public DoctorData(IDataAccess dataAccess, ConnectionStringData connectionString)
        {
            _dataAccess = dataAccess;
            _connectionString = connectionString;
        }

        public System.Threading.Tasks.Task<List<DoctorModel>> GetDoctors()
        {

            return _dataAccess.LoadData<DoctorModel, dynamic>("spDoctors_All",
                new { },
                _connectionString.SqlConnectionName);
        }
        public async Task<int> CreateDoctor(DoctorModel Doctor)
        {
            DynamicParameters p = new DynamicParameters();

            p.Add("Hospital", Doctor.Hospital);
            p.Add("Name", Doctor.Name);
            p.Add("TelNo", Doctor.TelNo);
            p.Add("Speciality", Doctor.Speciality);

            p.Add("ID", System.Data.DbType.Int32, direction: ParameterDirection.Output);

            await _dataAccess.SaveData("dbo.spDoctors_Insert", p, _connectionString.SqlConnectionName);

            return p.Get<int>("ID");
        }
        public async Task<int> UpdateDoctor(DoctorModel Doctor)
        {
            DynamicParameters p = new DynamicParameters();

            p.Add("Hospital", Doctor.Hospital);
            p.Add("Name", Doctor.Name);
            p.Add("TelNo", Doctor.TelNo);
            p.Add("Speciality", Doctor.Speciality);
            p.Add("ID", Doctor.ID);


            await _dataAccess.SaveData("dbo.spDoctors_Update", p, _connectionString.SqlConnectionName);

            return Doctor.ID;
        }
        public async Task<DoctorModel> GetDoctorById(int bookId)
        {
            var recs = await _dataAccess.LoadData<DoctorModel, dynamic>("dbo.spDoctors_GetById",
                new
                {
                    ID = bookId
                },
                _connectionString.SqlConnectionName);

            return recs.FirstOrDefault();
        }
        public Task<int> DeleteDoctor(int Id)
        {
            return _dataAccess.SaveData("dbo.spDoctors_Delete",
                new
                {
                    ID = Id
                },
                _connectionString.SqlConnectionName);
        }
    }
}
