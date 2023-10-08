using Dapper;
using Microsoft.Data.SqlClient;

namespace AnimalWebApp.Data;

public class DataContext
{
    private readonly IConfiguration _configuration;

    public DataContext(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    private SqlConnection GetDbConnection()
    {
        return new SqlConnection(_configuration.GetConnectionString("Default"));
    }

    public IEnumerable<T> LoadData<T>(string sql)
    {
        var dbConnection = GetDbConnection();
        return dbConnection.Query<T>(sql);
    }
    
    public bool Execute(string sql)
    {
        var dbConnection = GetDbConnection();
        return dbConnection.Execute(sql) > 0;
    }
}