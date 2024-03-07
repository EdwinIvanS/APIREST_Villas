using AutoMapper;
using VillaAPI.Infraestructura.Objetos.Models;
using VillaAPI.Infraestructura.Objetos.Models.Request;

namespace VillaAPI.Infraestructura.Objetos.Mappers
{
    public class Mapper:Profile
    {
        public Mapper()
        {            
            CreateMap<VillaEntity, VillaCreateDto>().ReverseMap();
        }
    }
}
