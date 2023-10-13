using AnimalWebApp.Data;
using AnimalWebApp.Models;

namespace AnimalWebApp.Repositories;

public class AnimalPostRepository : IAnimalPostRepository
{
    private readonly DataContext _dataContext;


    public AnimalPostRepository(IConfiguration configuration)
    {
        _dataContext = new DataContext(configuration);
    }

    public List<AnimalPost> GetAll()
    {
        var sql = $"SELECT * FROM AnimalPosts";
        return _dataContext.LoadData<AnimalPost>(sql);
    }

    public AnimalPost Get(int id)
    {
        var sql = $"SELECT * FROM AnimalPosts WHERE Id={id}";
        return _dataContext.LoadSingleData<AnimalPost>(sql);
    }

    public bool Add(AnimalPost animalPost, List<int> tagIds)
    {
        var sql = $"INSERT INTO AnimalPosts ([Title], [Content], [Description], [ImageUrl], [HandleUrl], [PublishedDate] ,[Author] ,[Visible]) VALUES ('{animalPost.Title}', '{animalPost.Content}', '{animalPost.Description}', '{animalPost.ImageUrl}', '{animalPost.HandleUrl}', '{animalPost.PublishedDate}', '{animalPost.Author}', '{animalPost.Visible}') ; SELECT SCOPE_IDENTITY()";

        var recentId = _dataContext.LoadSingleData<int>(sql);
        foreach (var tagId in tagIds)
        {
            var tagSql = $"INSERT INTO TagsAnimalPosts (TagId, AnimalPostId) VALUES ({tagId}, {recentId})";
            var result = _dataContext.Execute(tagSql);
            if (!result)
            {
                return false;
            }
        }

        return true;
    }

    public bool Update(AnimalPost animalPost)
    {
        var sql = $"UPDATE AnimalPosts Set [Title]='{animalPost.Title}', [Content]='{animalPost.Content}', [Description]='{animalPost.Description}', [Author]='{animalPost.Author}' WHERE Id={animalPost.Id}";
        return _dataContext.Execute(sql);
    }

    public bool Delete(int id)
    {
        var sql = $"DELETE FROM TagsAnimalPosts WHERE AnimalPostId='{id}' ; DELETE FROM AnimalPosts WHERE Id={id}";
        return _dataContext.Execute(sql);
    }
}