using Domain.Models;
using Domain.IRepositories;
using Domain.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class PersonaService : IPersonaService
    {
        private readonly IPersonaRepository _personaRepository;

        public PersonaService(IPersonaRepository personaRepository)
        {
            _personaRepository = personaRepository;
        }
        public async Task<IEnumerable<Persona>> GetPersonas()
        {
            return await _personaRepository.GetPersonas();
        }
        public async Task CrearPersona(Persona persona)
        {
            await _personaRepository.CrearPersona(persona);
        }

    }
}