using AnimalWebApp.Data;
using AnimalWebApp.Models;

namespace AnimalWebApp.Repositories;

public class TagRepository : ITagRepository
{
    private readonly DataContext _dataContext;


    public TagRepository(IConfiguration configuration)
    {
        _dataContext = new DataContext(configuration);
    }

    public Tag Get(int id)
    {
        var sql = $"SELECT * FROM TAGS WHERE Id={id}";
        return _dataContext.LoadSingleData<Tag>(sql);
    }

    public List<Tag> GetAll()
    {
        var sql = $"SELECT * FROM Tags";
        return _dataContext.LoadData<Tag>(sql);
    }

    public bool Add(Tag tag)
    {
        var sql = $"INSERT INTO Tags (Name, DisplayName) VALUES ('{tag.Name}', '{tag.DisplayName}')";
        return _dataContext.Execute(sql);
    }

    public bool Update(Tag tag)
    {
        var sql = $"UPDATE Tags Set Name='{tag.Name}', DisplayName= '{tag.DisplayName}' WHERE Id={tag.Id}";
        return _dataContext.Execute(sql);
    }

    public bool Delete(int id)
    {
        var sql = $"DELETE FROM Tags WHERE Id={id}";
        return _dataContext.Execute(sql);
    }
}