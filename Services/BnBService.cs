using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Dapper;
using System.Threading.Tasks;
using RealbnbDev.Data;
using RealbnbDev.Models;

namespace RealbnbDev.Services
{
    public class BnBService : IBnBService
    {
        private readonly SqlConnectionConfiguration _configuration;
        public BnBService(SqlConnectionConfiguration configuration)
        {
            _configuration = configuration;
        }


        /*************************************************************************************************/
        /*FOR*/


        public async Task<bool> CreateProperty(bnbProperties bnb)
        {
            using (var conn = new SqlConnection(_configuration.Value))
            {
                const string query = @"insert into dbo.bnbProperties (Name, Description, Category, Price, Location, Image) values (@Name, @Description, @Category, @Price, @Location, @Image)";
                if (conn.State == ConnectionState.Closed)
                    conn.Open();
                try
                {
                    await conn.ExecuteAsync(query, new { bnb.Name, bnb.Description, bnb.Category, bnb.Price, bnb.Location, bnb.Image}, commandType: CommandType.Text);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    if (conn.State == ConnectionState.Open)
                        conn.Close();
                }
            }
            return true;
        }
        public async Task<bool> DeleteProperty(int Id)
        {
            using (var conn = new SqlConnection(_configuration.Value))
            {
                const string query = @"delete from dbo.bnbProperties where PropertyId=@Id";
                if (conn.State == ConnectionState.Closed)
                    conn.Open();
                try
                {
                    await conn.ExecuteAsync(query, new { Id }, commandType: CommandType.Text);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    if (conn.State == ConnectionState.Open)
                        conn.Close();
                }
            }
            return true;
        }
        public async Task<bool> UpdateProperty(int Id, bnbProperties bnb)
        {
            using (var conn = new SqlConnection(_configuration.Value))
            {
                const string query = @"update dbo.bnbProperties set Name = @Name, Description = @Description, Category = @Category, Price = @Price, Location = @Location, Image = @Image where PropertyId=@Id";
                if (conn.State == ConnectionState.Closed)
                    conn.Open();
                try
                {
                    await conn.ExecuteAsync(query, new { bnb.Name, bnb.Description, bnb.Category, bnb.Price, bnb.Location, bnb.Image, bnb.PropertyId}, commandType: CommandType.Text);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    if (conn.State == ConnectionState.Open)
                        conn.Close();
                }
            }
            return true;
        }
        public async Task<IEnumerable<bnbProperties>> GetProperties()
        {
            IEnumerable<bnbProperties> bnblist;
            using (var conn = new SqlConnection(_configuration.Value))
            {
                const string query = @"select * from dbo.bnbProperties order by PropertyId DESC";

                if (conn.State == ConnectionState.Closed)
                    conn.Open();
                try
                {
                    bnblist = await conn.QueryAsync<bnbProperties>(query);

                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    if (conn.State == ConnectionState.Open)
                        conn.Close();
                }

            }
            return bnblist;
        }
        public async Task<bnbProperties> SingleProperty(int id)
        {
            bnbProperties bnb = new bnbProperties();

            using (var conn = new SqlConnection(_configuration.Value))
            {
                const string query = @"select * from dbo.bnbProperties where PropertyId =@Id";

                if (conn.State == ConnectionState.Closed)
                    conn.Open();
                try
                {
                    bnb = await conn.QueryFirstOrDefaultAsync<bnbProperties>(query, new { id }, commandType: CommandType.Text);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    if (conn.State == ConnectionState.Open)
                        conn.Close();
                }
            }
            return bnb;
        }


    }
}
