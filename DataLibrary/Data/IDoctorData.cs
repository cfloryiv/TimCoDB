using System.Collections.Generic;
using System.Threading.Tasks;
using DataLibrary.Models;

namespace DataLibrary.Data
{
    public interface IDoctorData
    {
        Task<List<DoctorModel>> GetDoctors();
        Task<int> CreateDoctor(DoctorModel Doctor);
        Task<DoctorModel> GetDoctorById(int bookId);
        Task<int> DeleteDoctor(int Id);
        Task<int> UpdateDoctor(DoctorModel Doctor);
    }
}