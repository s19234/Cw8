using Kolos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Kolos.Services
{
    public class ProjectDbService : IProjectDbService
    {
        public Project GetProject(int id)
        {
            var pr = new Project();

            using(var con = new SqlConnection("Data Source=db-mssql;Initial Catalog=s19234;Integrated Security=True"))
            using(var com = new SqlCommand())
            {
                com.Connection = con;
                con.Open();

                var tran = con.BeginTransaction();

                try
                {
                    com.CommandText = "Select * From Project where id=@id";
                    com.Parameters.AddWithValue("id", id);

                    var dr = com.ExecuteReader();
                    if (!dr.Read())
                        tran.Rollback();

                    int idProject = (int)dr["IdProject"];
                    string name = (string)dr["Name"];
                    DateTime dateTime = DateTime.Parse((string)dr["Deadline"]);
                    pr.IdTeam = idProject;
                    pr.Name = name;
                    pr.Deadline = dateTime;
                    tran.Commit();
                } 
                catch(SqlException)
                {
                    tran.Rollback();
                }
            }
            return pr;
        }

        public void AddProject()
        {
            throw new NotImplementedException();
        }
    }
}
