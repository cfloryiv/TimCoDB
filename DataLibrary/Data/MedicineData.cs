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
    public interface IMedicineData
    {
        public Task<List<MedicineModel>> GetMedicines();
        public Task<int> CreateMedicine(MedicineModel Medicine);
        Task<MedicineModel> GetMedicineById(int bookId);
        Task<int> DeleteMedicine(int Id);
        Task<int> UpdateMedicine(MedicineModel Medicine);
    }

    public class MedicineData : IMedicineData
    {
        private readonly IDataAccess _dataAccess;
        private readonly ConnectionStringData _connectionString;

        public MedicineData(IDataAccess dataAccess, ConnectionStringData connectionString)
        {
            _dataAccess = dataAccess;
            _connectionString = connectionString;
        }
        public Task<List<MedicineModel>> GetMedicines()
        {
            return _dataAccess.LoadData<MedicineModel, dynamic>("dbo.spMedicines_All",
                new { },
                _connectionString.SqlConnectionName);
        }
        public async Task<int> CreateMedicine(MedicineModel Medicine)
        {
            DynamicParameters p = new DynamicParameters();
/*       public string Name { get; set; }
        public int PillSize { get; set; }
        public Decimal Cost { get; set; }
        public string Doctor { get; set; }
*/
            p.Add("Name", Medicine.Name);
            p.Add("PillSize", Medicine.PillSize);
            p.Add("Cost", Medicine.Cost);
            p.Add("Doctor", Medicine.Doctor);

            p.Add("ID", System.Data.DbType.Int32, direction: ParameterDirection.Output);

            await _dataAccess.SaveData("dbo.spMedicines_Insert", p, _connectionString.SqlConnectionName);

            return p.Get<int>("ID");
        }
        public async Task<int> UpdateMedicine(MedicineModel Medicine)
        {
            DynamicParameters p = new DynamicParameters();
            /*       public string Name { get; set; }
                    public int PillSize { get; set; }
                    public Decimal Cost { get; set; }
                    public string Doctor { get; set; }
            */
            p.Add("Name", Medicine.Name);
            p.Add("PillSize", Medicine.PillSize);
            p.Add("Cost", Medicine.Cost);
            p.Add("Doctor", Medicine.Doctor);
            p.Add("ID", Medicine.ID);

            await _dataAccess.SaveData("dbo.spMedicines_Update", p, _connectionString.SqlConnectionName);

            return Medicine.ID;
        }
        public async Task<MedicineModel> GetMedicineById(int bookId)
        {
            var recs = await _dataAccess.LoadData<MedicineModel, dynamic>("dbo.spMedicines_GetById",
                new
                {
                    ID = bookId
                },
                _connectionString.SqlConnectionName);

            return recs.FirstOrDefault();
        }
        public Task<int> DeleteMedicine(int Id)
        {
            return _dataAccess.SaveData("dbo.spMedicines_Delete",
                new
                {
                    ID = Id
                },
                _connectionString.SqlConnectionName);
        }
    }
}
