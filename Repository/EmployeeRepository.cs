using System;
using Microsoft.Data.SqlClient;
using ADOwebAPI.Models;
using System.Collections.Generic;

namespace ADOwebAPI.Repository
{
    public class EmployeeRepository
    {
        public readonly string cs;

        public EmployeeRepository(IConfiguration config)
        {
            cs = config.GetConnectionString("DefaultConnection");
        }

        public List<Employee> GetEmps()
        {
            List<Employee> list = new();
            using SqlConnection con = new SqlConnection(cs);
            con.Open();

            SqlCommand cmd = new SqlCommand("Select Name,Id from Employees", con);
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                list.Add(new Employee
                {
                    Id = dr.GetInt32(0),
                    Name = dr.GetString(1)
                });
            }
            return list;
        }
    }
}
