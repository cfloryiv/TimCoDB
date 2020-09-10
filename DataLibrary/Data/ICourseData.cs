using System.Collections.Generic;
using System.Threading.Tasks;
using DataLibrary.Models;

namespace DataLibrary.Data
{
    public interface ICourseData
    {
        Task<List<CourseModel>> GetCourses();
        Task<int> CreateCourse(CourseModel course);
        Task<CourseModel> GetCourseById(int courseId);
        Task<int> DeleteCourse(int Id);
        Task<int> UpdateCourse(CourseModel course);
    }
}