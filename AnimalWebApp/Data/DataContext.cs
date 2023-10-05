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

    private SqlConnection GetDbConnection<T>()
    {
        return new SqlConnection(_configuration.GetConnectionString("Default"));
    }

    public IEnumerable<T> LoadData<T>(string sql)
    {
        var dbConnection = GetDbConnection<T>();
        return dbConnection.Query<T>("sql");
    }
    
    public T LoadDataSingle<T>(string sql)
    {
        var dbConnection = GetDbConnection<T>();
        return dbConnection.QuerySingle<T>("sql");
    }

    public bool Execute<T>(string sql)
    {
        var dbConnection = GetDbConnection<T>();
        return dbConnection.Execute("sql") > 0;
    }
}