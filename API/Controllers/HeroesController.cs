using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using API.DTOs;
using API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{


  public class HeroesController : BaseApiController
  {
    private readonly DataContext _context;
    public HeroesController(DataContext context)
    {
      _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Hero>>> GetHeroes()
    {
        return await _context.Heroes.ToListAsync();

    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Hero>> GetHero(int id)
    {
        return await _context.Heroes.FindAsync(id);


    }
    [HttpPost("add")]
    public async Task<ActionResult<Hero>> AddHero(HeroDto heroDto)
    {
        var hero = new Hero
        {
          HeroName = heroDto.HeroName.ToLower(),
        };
        _context.Heroes.Add(hero);
        await _context.SaveChangesAsync();
        return hero;
    }

    // [HttpPut("edit/{Id}")]
    //     public async Task<ActionResult<Hero>> EditHero(EditHeroDto editHeroDto)
    // {
    //     var hero = _context.Heroes.Where(h => h.Id == editHeroDto.id).FirstOrDefault<HeroDto>();

    //     {
    //       HeroName = editHeroDto.HeroName.ToLower();
    //     };
    //     _context.Heroes.Update(hero);
    //     await _context.SaveChangesAsync();
    //     return hero;
    // }

    

  }
}