using AutoMapper;
using Domain.Models;
using Domain.IServices;
using DTO.Persona;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExamenApi.Controllers
{
    [Route("api/examen")]
    [ApiController]
    public class PersonaController : ControllerBase
    {
        private readonly IPersonaService _personaService;
        private readonly IMapper _mapper;
        public PersonaController(IPersonaService personaService, IMapper mapper)
        {
            _personaService = personaService;

            _mapper = mapper;

        }

        [HttpGet("listaPersonas")]
        public async Task<ActionResult<IEnumerable<PersonaGetDTO>>> GetPersonas()
        {
            try
            {
                var lista = await _personaService.GetPersonas();
                return Ok(_mapper.Map<IEnumerable<PersonaGetDTO>>(lista));
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.GetType() + " - ERROR YO" });
            }
        }
        [HttpPost("crearPersona")]
        public async Task<ActionResult> CrearPersona([FromBody] PersonaForCreationDTO personaDTO)
        {
            try
            {
                var persona = _mapper.Map<Persona>(personaDTO);
                await _personaService.CrearPersona(persona);
                return Ok(new { message = "Persona creada con exito"});
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.GetType() + "ERROR" });
            }
        }
    }
}
