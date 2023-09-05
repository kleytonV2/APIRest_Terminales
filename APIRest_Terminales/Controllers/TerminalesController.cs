using APIRest_Terminales.Data;
using APIRest_Terminales.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APIRest_Terminales.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TerminalesController : ControllerBase
    {
        private ApplicationDbContext _context;

        public TerminalesController(ApplicationDbContext context) => _context = context;

        [HttpGet]
        public async Task<IEnumerable<Terminales>> Get() => await _context.Terminales.ToListAsync();

        [HttpGet("id")]
        [ProducesResponseType(typeof(Terminales),StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound )]
        public async Task<IActionResult> GetById(int id) { 
            var terminal = await _context.Terminales.FindAsync(id);
            return terminal == null ? NotFound() : Ok(id);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> Create(Terminales terminal)
        {
            await _context.Terminales.AddAsync(terminal);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { id = terminal.Id_terminal }, terminal);
        }

        [HttpPut("id")]
        [ProducesResponseType(StatusCodes.Status204NoContent )]
        [ProducesResponseType(StatusCodes.Status400BadRequest )]
        public async Task<IActionResult> Update(int id,Terminales terminal)
        {
            if (id != terminal.Id_terminal )  return BadRequest(id); 

            _context.Entry(terminal).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("id")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Delete(int id)
        {
            var terminal = await _context.Terminales.FindAsync (id);
            if (terminal == null) return NotFound();

            _context.Terminales.Remove(terminal);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
