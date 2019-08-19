using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazorCRUD.Shared.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BlazorCRUD.Server.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PersonasController : ControllerBase
    {
        private readonly AppDbContext _context;

        public PersonasController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Persona>>> Get() => await _context.Personas.ToListAsync();

        [HttpGet("{id}", Name = "obtenerPersona")]
        public async Task<ActionResult<Persona>> Get(int id) => await _context.Personas.FirstOrDefaultAsync(p => p.Id.Equals(id));

        [HttpPost]
        public async Task<ActionResult> Post(Persona persona)
        {
            _context.Add(persona);
            await _context.SaveChangesAsync();

            return new CreatedAtRouteResult("obtenerPersona", new { id = persona.Id }, persona);
        }

        [HttpPut]
        public async Task<ActionResult> Put(Persona persona)
        {
            _context.Entry(persona).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            //var persona = new Persona { Id = id };
            var persona = await _context.Personas.Where(p => p.Id.Equals(id)).FirstOrDefaultAsync();
            _context.Remove(persona);
            await _context.SaveChangesAsync(); 
            return NoContent();
        }
    }
}