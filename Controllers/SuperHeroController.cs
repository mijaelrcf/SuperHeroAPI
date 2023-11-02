using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SuperHeroAPI.Models;
using SuperHeroAPI.Services.SuperHeroService;
using System.Collections.Generic;

namespace SuperHeroAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuperHeroController : ControllerBase
    {
        private readonly ISuperHeroService _superHeroService;
        public SuperHeroController(ISuperHeroService superHeroService)
        {
            _superHeroService = superHeroService;
        }

        [HttpGet]
        public async Task<ActionResult<List<SuperHero>>> GetAll()
        {
            return await _superHeroService.GetAll();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<SuperHero>>> GetById(int id)
        {
            var hero = await _superHeroService.GetById(id);

            if (hero is null)
                return NotFound("Sorry, but the id doesn't exist");

            return Ok(hero);
        }

        [HttpPost]
        public async Task<ActionResult<List<SuperHero>>> Add(SuperHero hero)
        {
            var result = await _superHeroService.Add(hero);
            return Ok(result);
        }

        [HttpPut]
        public async Task<ActionResult<List<SuperHero>>> Update(int id, SuperHero request)
        {
            var result = await _superHeroService.Update(id, request);

            if (result == null)
                return NotFound("Sorry, but the id doesn't exist");            
            
            return Ok(result);
        }

        [HttpDelete]
        public async Task<ActionResult<List<SuperHero>>> Delete(int id)
        {
            var result = await _superHeroService.Delete(id);
            
            if (result == null)
                return NotFound("Sorry, but the id doesn't exist");            

            return Ok(result);
        }
    }
}
