using VillaAPI.Infraestructura.Objetos.Models;
using VillaAPI.Infraestructura.Objetos.Models.Request;

namespace VillaAPI.Infraestructura.Services
{
    public interface IVillaService
    {
        Task<List<VillaEntity>> GetVillas();
        Task<VillaEntity> GetVilla(int id);
        Task<VillaEntity> CrearVilla(VillaCreateDto villa);
        Task<VillaEntity> UpdateVilla(VillaUpdateDto villa);
        Task<VillaEntity> DeleteVilla(int id);
    }
}
