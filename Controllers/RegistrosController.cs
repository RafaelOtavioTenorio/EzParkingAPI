using ez_parking_api.Data;
using ez_parking_api.Models;
using Microsoft.AspNetCore.Mvc;

namespace ez_parking_api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RegistrosController : ControllerBase
    {
        private readonly AppDbContext _context;
        public RegistrosController(AppDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult GetRegistros()
        {
            var registros = _context.Registros.ToList();
            return Ok(registros);
        }
        [HttpPost]
        public async Task<IActionResult> AddRegistro([FromBody] Registro registro)
        {
            if (ModelState.IsValid)
            {
                _context.Registros.Add(registro);
                await _context.SaveChangesAsync();
                return CreatedAtAction(nameof(GetRegistros), new { id = registro.ID }, registro);
            }
            return BadRequest(ModelState);
        }
        [HttpDelete]
        public async Task<IActionResult> ApagarRegistro(int id)
        {
            if (id <= 0)
            {
                return BadRequest("ID inválido.");
            }
            var registroExistente = await _context.Registros.FindAsync(id);
            if (registroExistente == null)
            {
                return NotFound();
            }
            registroExistente.Active = false;
            _context.Registros.Update(registroExistente);
            await _context.SaveChangesAsync();
            return NoContent();
        }
        [HttpDelete("hard/{id}")]
        //USAR SOMENTE EM CASOS EXTREMOS!!!
        private async Task<IActionResult> HardDeleteRegistro(int id)
        {
            //Novamente... USAR SOMENTE EM CASOS EXTREMOS!!!
            if (id <= 0)
            {
                return BadRequest("ID inválido.");
            }
            var registroExistente = await _context.Registros.FindAsync(id);
            if (registroExistente == null)
            {
                return NotFound();
            }
            _context.Registros.Remove(registroExistente);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
