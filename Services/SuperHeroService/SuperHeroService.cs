using Microsoft.EntityFrameworkCore;
using SuperHeroAPI.Data;
using SuperHeroAPI.Models;

namespace SuperHeroAPI.Services.SuperHeroService
{
    public class SuperHeroService : ISuperHeroService
    {
        //private static List<SuperHero> superHeroes = new List<SuperHero>
        //{
        //    new SuperHero
        //    {
        //        Id = 1,
        //        Name = "Spider Man",
        //        FirstName = "Peter",
        //        LastName = "Parker",
        //        Place = "New York City"
        //    },
        //    new SuperHero
        //    {
        //        Id = 2,
        //        Name = "Iron Man",
        //        FirstName = "Tony",
        //        LastName = "Stark",
        //        Place = "Malibu"
        //    }
        //};

        private readonly DataContext _context;

        public SuperHeroService(DataContext context)
        {
            _context = context;
        }

        public async Task<List<SuperHero>> Add(SuperHero hero)
        {
            await _context.SuperHeroes.AddAsync(hero);
            await _context.SaveChangesAsync();

            return await _context.SuperHeroes.ToListAsync();
        }

        public async Task<List<SuperHero>?> Delete(int id)
        {
            var hero = await _context.SuperHeroes.FindAsync(id);

            if (hero == null)
                return null;

            //superHeroes.Remove(hero);
            _context.SuperHeroes.Remove(hero);
            await _context.SaveChangesAsync();

            //return superHeroes;
            return await _context.SuperHeroes.ToListAsync();
        }

        public async Task<List<SuperHero>> GetAll()
        {
            var heroes = await _context.SuperHeroes.ToListAsync();
            return heroes;
        }

        public async Task<SuperHero?> GetById(int id)
        {
            var hero = await _context.SuperHeroes.FindAsync(id);

            if (hero == null)
                return null;

            return hero;
        }

        public async Task<List<SuperHero>?> Update(int id, SuperHero request)
        {
            var hero = await _context.SuperHeroes.FindAsync(id);

            if (hero == null)
                return null;

            hero.Name = request.Name;
            hero.FirstName = request.FirstName;
            hero.LastName = request.LastName;
            hero.Place = request.Place;

            await _context.SaveChangesAsync();

            return await _context.SuperHeroes.ToListAsync();
        }
    }
}
