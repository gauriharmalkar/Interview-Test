using System.Data.SqlClient;
using System.Data;

namespace JobPortalProject.Repository
{
    public class RepositoryBase
    {
        IConfiguration _IConfiguration;
        public RepositoryBase(IConfiguration Config)
        {
            _IConfiguration = Config;
        }
        public DataSet ExecuteSpGet(SqlParameter[] parameterList, string sprName)
        {
            var result = new DataSet("Result");

            string connString = _IConfiguration.GetConnectionString("DefaultConnection");
            using (var conn = new SqlConnection(connString))
            {
                using (var sqlCommand = new SqlCommand { CommandText = sprName, CommandType = CommandType.StoredProcedure, CommandTimeout = 600 })
                {
                    if (parameterList != null) sqlCommand.Parameters.AddRange(parameterList);
                    sqlCommand.Connection = conn;

                    using (var sqlAdapter = new SqlDataAdapter(sqlCommand))
                    {
                        sqlAdapter.Fill(result);
                    }
                }
            }

            return result;
        }

        public int ExecuteSpPut(SqlParameter[] parameterList, string sprName)
        {
            string connString = _IConfiguration.GetConnectionString("DefaultConnection");
            using (var conn = new SqlConnection(connString))
            {
                using (var sqlCommand = new SqlCommand { CommandText = sprName, CommandType = CommandType.StoredProcedure, CommandTimeout = 600 })
                {
                    conn.Open();
                    if (parameterList != null) sqlCommand.Parameters.AddRange(parameterList);
                    sqlCommand.Connection = conn;

                    int result = sqlCommand.ExecuteNonQuery();
                    return result;
                }
            }

        }

        
        

    }
}
