using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.IServices
{
    public interface IPersonaService
    {
        Task<IEnumerable<Persona>> GetPersonas();
        Task CrearPersona(Persona persona); 
    }
}
