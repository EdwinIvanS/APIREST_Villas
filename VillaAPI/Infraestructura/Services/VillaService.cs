using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using VillaAPI.Infraestructura.Objetos.Context;
using VillaAPI.Infraestructura.Objetos.Models;
using VillaAPI.Infraestructura.Objetos.Models.Request;

namespace VillaAPI.Infraestructura.Services
{
    public class VillaService : IVillaService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        public VillaService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<VillaEntity>> GetVillas()
        {
            return await _context.Villas.ToListAsync();
        }

        public async Task<VillaEntity> GetVilla(int id)
        {
            return await _context.Villas.FindAsync(id);
        }

        public async Task<VillaEntity> CrearVilla(VillaCreateDto villa)
        {
            var modelo = _mapper.Map<VillaEntity>(villa);
            var entity = await _context.Villas.AddAsync(modelo);
            await _context.SaveChangesAsync();
            return entity.Entity;
        }

        public async Task<VillaEntity> UpdateVilla(VillaUpdateDto villa) 
        {
            var existingVilla = await _context.Villas.FindAsync(villa.Id);
            if (existingVilla == null) return null;

            existingVilla.Nombre = (villa.Nombre == null) ? existingVilla.Nombre : villa.Nombre;
            existingVilla.Detalle = (villa.Detalle == null) ? existingVilla.Detalle : villa.Detalle;
            existingVilla.Tarifa = (villa.Tarifa == null) ? existingVilla.Tarifa : villa.Tarifa;
            existingVilla.Ocupantes = (villa.Ocupantes == null) ? existingVilla.Ocupantes : villa.Ocupantes;
            existingVilla.MetrosCuadrados = (villa.MetrosCuadrados == null) ? existingVilla.MetrosCuadrados : villa.MetrosCuadrados;
            existingVilla.ImagenUrl = (villa.ImagenUrl == null) ? existingVilla.ImagenUrl : villa.ImagenUrl;
            existingVilla.Amenidad = (villa.Amenidad == null) ? existingVilla.Amenidad : villa.Amenidad;

            await _context.SaveChangesAsync();
            return existingVilla;
        }

        public async Task<VillaEntity> DeleteVilla(int id)
        {
            var existingVilla = await _context.Villas.FindAsync(id);
            if (existingVilla is null) return null;            

            _context.Villas.Remove(existingVilla);
            await _context.SaveChangesAsync();
            return existingVilla;
        }

    }
}
