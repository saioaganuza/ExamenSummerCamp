using AutoMapper;
using Domain.Models;
using DTO.Persona;
using Utils;

namespace ExamenAPI.Profiles
{
    public class PersonaProfile : Profile
    {
        public PersonaProfile()
        {
            CreateMap<Persona, PersonaGetDTO>()
               .ForMember(dto => dto.Id, ent =>
               ent.MapFrom(val => $"{val.Id}"))
               .ForMember(dto => dto.Nombre, ent =>
               ent.MapFrom(val => $"{val.Nombre}"))
               .ForMember(dto => dto.Edad, ent =>
               ent.MapFrom(val => PersonaUtils.CalcularEdad(val.FechaNacimiento)))
               .ForMember(dto => dto.Telefono, ent =>
               ent.MapFrom(val => $"{val.Telefono}"));

            CreateMap<PersonaForCreationDTO, Persona>()
                .ForMember(model => model.Nombre, ent =>
                ent.MapFrom(dto => dto.Nombre))
                .ForMember(model => model.FechaNacimiento, ent =>
                ent.MapFrom(dto => dto.FechaNacimiento))
                .ForMember(model => model.Telefono, ent =>
                ent.MapFrom(dto => dto.Telefono));

        }
    }
}