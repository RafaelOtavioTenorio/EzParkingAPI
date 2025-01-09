using ez_parking_api.Data;
using ez_parking_api.Models;
using Microsoft.AspNetCore.Mvc;

namespace ez_parking_api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EstacionamentosController : ControllerBase
    {
        private readonly AppDbContext _context;
        public EstacionamentosController(AppDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult GetEstacionamentos()
        {
            var estacionamentos = _context.Estacionamentos.ToList();
            return Ok(estacionamentos);
        }
        [HttpPost]
        public async Task<IActionResult> AddEstacionamento([FromBody] Estacionamento estacionamento)
        {
            if (ModelState.IsValid)
            {
                _context.Estacionamentos.Add(estacionamento);
                await _context.SaveChangesAsync();
                return CreatedAtAction(nameof(GetEstacionamentos), new { id = estacionamento.ID }, estacionamento);
            }
            return BadRequest(ModelState);
        }
        [HttpDelete]
        public async Task<IActionResult> ApagarEstacionamento(int id)
        {
            if (id <= 0)
            {
                return BadRequest("ID inválido.");
            }
            var estacionamentoExistente = await _context.Estacionamentos.FindAsync(id);
            if (estacionamentoExistente == null)
            {
                return NotFound();
            }
            estacionamentoExistente.Active = false;
            _context.Estacionamentos.Update(estacionamentoExistente);
            await _context.SaveChangesAsync();
            return NoContent();
        }
        [HttpDelete("hard/{id}")]
        //USAR SOMENTE EM CASOS EXTREMOS!!!
        private async Task<IActionResult> HardDeleteEstacionamento(int id)
        {
            //Novamente... USAR SOMENTE EM CASOS EXTREMOS!!!
            if (id <= 0)
            {
                return BadRequest("ID inválido.");
            }
            var estacionamentoExistente = await _context.Estacionamentos.FindAsync(id);
            if (estacionamentoExistente == null)
            {
                return NotFound();
            }
            _context.Estacionamentos.Remove(estacionamentoExistente);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
