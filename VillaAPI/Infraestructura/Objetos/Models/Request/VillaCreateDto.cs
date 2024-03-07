using System.ComponentModel.DataAnnotations;

namespace VillaAPI.Infraestructura.Objetos.Models.Request
{
    public class VillaCreateDto
    {
        [Required]
        [MaxLength(30)]
        public string Nombre { get; set; }
        public string Detalle { get; set; }

        [Required]
        public string Tarifa { get; set; }

        public int Ocupantes { get; set; }
        public double MetrosCuadrados { get; set; }
        public string ImagenUrl { get; set; }
        public string Amenidad { get; set; }
    }
}
