using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VillaAPI.Infraestructura.Objetos.Models;
using VillaAPI.Infraestructura.Objetos.Models.Request;
using VillaAPI.Infraestructura.Services;

namespace VillaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VillaController : ControllerBase
    {
        private readonly IVillaService _service;
        public VillaController(VillaService service) 
        {
            _service = service;
        }


        [HttpGet]
        [Route("Consultar")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<List<VillaEntity>>> GetVillas()
        {
            try
            {
                var response = await _service.GetVillas();
                if (response is null) return NotFound();
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal error server : {ex.Message}");
            }
        }


        [HttpGet()]
        [Route("Buscar/{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<VillaEntity>> GetVilla(int id)
        {
            try
            {
                var response = await _service.GetVilla(id);
                if (response is null) return NotFound();
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal error server : {ex.Message}");
            }

        }


        [HttpPost]
        [Route("Insertar")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CrearVilla([FromBody] VillaCreateDto villaRequest)
        {
            try 
            {
                if (!ModelState.IsValid) return BadRequest(ModelState);
                var response = await _service.CrearVilla(villaRequest);
                if (response == null) return BadRequest("No se pudo crear la villa.");

                return CreatedAtAction(nameof(GetVilla), new { id = response.Id }, response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal error server : {ex.Message}");
            }
        }


        [HttpPut()]
        [Route("Actualizar/{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateVilla([FromBody] VillaUpdateDto villaRequest, int id)
        {
           try
            {   if (villaRequest.Id == id) 
                {
                    var response = await _service.UpdateVilla(villaRequest);
                    if (response == null) return BadRequest(response);
                    return NoContent();
                }
                return BadRequest();
            } 
            catch (Exception ex) 
            {
                return StatusCode(500, $"Internal error server : {ex.Message}");
            }
        }


        [HttpDelete()]
        [Route("Eliminar/{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteVilla(int id)
        {
            try
            {
                var response = await _service.DeleteVilla(id);
                if (response == null) return NotFound();
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal error server : {ex.Message}");
            }
        }
    }
}
