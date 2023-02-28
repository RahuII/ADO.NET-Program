using AspWithADONet.Models;
using System.Data.SqlClient;
using System.Runtime.CompilerServices;
using static AspWithADONet.Services.StudentServices;

namespace AspWithADONet.Services
{
    
    public class StudentServices : IStudentService
    {
        public string Constr { get; set; }
        public IConfiguration _configuration;
        public   SqlConnection con;
        public StudentServices(IConfiguration configuration)
        {
            _configuration = configuration;
            Constr = _configuration.GetConnectionString("DBConnection");
        }
        public List<Students> GetStudentRecord()
        {
            List<Students> studentsList = new List<Students>();
            try
            {
               using (con=new SqlConnection(Constr))
                {
                    con.Open();
                    var cmd = new SqlCommand("SP_GetStudentsRecords", con);
                    cmd.CommandType=System.Data.CommandType.StoredProcedure;
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Students std = new Students();
                        std.Id = Convert.ToInt32(reader["id"]);
                        std.Name = reader["Name"].ToString();
                        std.Email = reader["Email"].ToString();
                        studentsList.Add(std);
                    }
                }
                return studentsList.ToList();

            }
            catch (Exception)
            {
                throw;
            }
        }
        public interface IStudentService
        {
            public List<Students> GetStudentRecord();
        }
    }
}
