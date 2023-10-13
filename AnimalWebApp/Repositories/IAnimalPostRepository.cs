using AnimalWebApp.Models;

namespace AnimalWebApp.Repositories;

public interface IAnimalPostRepository
{
    public List<AnimalPost> GetAll();
    public AnimalPost? Get(int id);
    public bool Add(AnimalPost animalPost, List<int> tagIds);
    public bool Update(AnimalPost animalPost);
    public bool Delete(int id);
}