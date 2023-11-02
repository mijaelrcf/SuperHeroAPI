using SuperHeroAPI.Models;

namespace SuperHeroAPI.Services.SuperHeroService
{
    public interface ISuperHeroService
    {
        Task<List<SuperHero>> GetAll();
        Task<SuperHero?> GetById(int id);
        Task<List<SuperHero>> Add(SuperHero hero);
        Task<List<SuperHero>?> Update(int id, SuperHero request);
        Task<List<SuperHero>?> Delete(int id);

    }
}
