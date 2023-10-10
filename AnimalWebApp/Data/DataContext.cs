using Dapper;
using Microsoft.Data.SqlClient;

namespace AnimalWebApp.Data;

public class DataContext
{
    private readonly string _connectionString;
    

    public DataContext(IConfiguration configuration)
    {
        _connectionString = configuration.GetConnectionString("Default")!;
    }

    public List<T> LoadData<T>(string sql)
    {
        using var dbConnection = new SqlConnection(_connectionString);
        return dbConnection.Query<T>(sql).ToList();
    }

    public T LoadSingleData<T>(string sql)
    {
        using var dbConnection = new SqlConnection(_connectionString);
        return dbConnection.QuerySingle<T>(sql);
    }

    public bool Execute(string sql)
    {
        using var dbConnection = new SqlConnection(_connectionString);
        return dbConnection.Execute(sql) > 0;
    }
}