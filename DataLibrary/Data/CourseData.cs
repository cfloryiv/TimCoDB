using Dapper;
using DataLibrary.Db;
using DataLibrary.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLibrary.Data
{
    public class CourseData : ICourseData
    {
        private readonly IDataAccess _dataAccess;
        private readonly ConnectionStringData _connectionString;

        public CourseData(IDataAccess dataAccess, ConnectionStringData connectionString)
        {
            _dataAccess = dataAccess;
            _connectionString = connectionString;
        }

        public System.Threading.Tasks.Task<List<CourseModel>> GetCourses()
        {

            return _dataAccess.LoadData<CourseModel, dynamic>("spCourses_All",
                new { },
                _connectionString.SqlConnectionName);
        }

        public async Task<int> CreateCourse(CourseModel course)
        {
            DynamicParameters p = new DynamicParameters();

            p.Add("Platform", course.Platform);
            p.Add("Name", course.Name);
            p.Add("Author", course.Author);
            p.Add("Cost", course.Cost);
            p.Add("PersonID", course.PersonID);
            p.Add("Date", course.Date);

            p.Add("ID", System.Data.DbType.Int32, direction: ParameterDirection.Output);

            await _dataAccess.SaveData("dbo.spCourses_Insert", p, _connectionString.SqlConnectionName);

            return p.Get<int>("ID");
        }
        public async Task<int> UpdateCourse(CourseModel course)
        {
            DynamicParameters p = new DynamicParameters();

            p.Add("Platform", course.Platform);
            p.Add("Name", course.Name);
            p.Add("Author", course.Author);
            p.Add("Cost", course.Cost);
            p.Add("PersonID", course.PersonID);
            p.Add("Date", course.Date);
            p.Add("ID", course.ID);


            await _dataAccess.SaveData("dbo.spCourses_Update", p, _connectionString.SqlConnectionName);

            return course.ID;
        }
        public async Task<CourseModel> GetCourseById(int courseId)
        {
            var recs = await _dataAccess.LoadData<CourseModel, dynamic>("dbo.spCourses_GetById",
                new
                {
                    ID = courseId
                },
                _connectionString.SqlConnectionName);

            return recs.FirstOrDefault();
        }
        public Task<int> DeleteCourse(int Id)
        {
            return _dataAccess.SaveData("dbo.spCourses_Delete",
                new
                {
                    ID = Id
                },
                _connectionString.SqlConnectionName);
        }
    }
}
