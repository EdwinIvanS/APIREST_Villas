using System.ComponentModel.DataAnnotations;

namespace VillaAPI.Infraestructura.Objetos.Models.Request
{
    public class VillaUpdateDto
    {
        [Required]
        public int Id { get; set; }
        
        [Required]
        [MaxLength(30)]
        public string Nombre { get; set; }
        public string Detalle { get; set; }

        [Required]
        public string Tarifa { get; set; }

        [Required]
        public int Ocupantes { get; set; }

        [Required]
        public double MetrosCuadrados { get; set; }
        public string ImagenUrl { get; set; }
        public string Amenidad { get; set; }
    }
}
