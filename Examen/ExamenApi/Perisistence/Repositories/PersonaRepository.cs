using Domain.IRepositories;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Perisistence.Repositories
{
    public class PersonaRepository:IPersonaRepository
    {
        private readonly ApplicationDbContext _context;
        public PersonaRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Persona>> GetPersonas()
        {
            return await _context.Personas
                .Where(persona => persona.FechaNacimiento < new DateTime(2002, 1, 1))
                .Take(10).OrderBy(persona => persona.Nombre).ToListAsync();
        }

        public async Task CrearPersona(Persona persona)
        {
            if (persona == null)
            {
                throw new ArgumentNullException(nameof(persona));
            }
            _context.Add(persona);
            await _context.SaveChangesAsync();
        }
    }
}
