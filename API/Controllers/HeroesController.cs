using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{

  [ApiController]
  [Route("api/[controller]")]
  public class HeroesController : ControllerBase
  {
    private readonly DataContext _context;
    public HeroesController(DataContext context)
    {
      _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Hero>>> GetUsers()
    {
        return await _context.Heroes.ToListAsync();

    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Hero>> GetUser(int id)
    {
        return await _context.Heroes.FindAsync(id);


    }

  }
}