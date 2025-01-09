using ez_parking_api.Data;
using ez_parking_api.Models;
using Microsoft.AspNetCore.Mvc;

namespace ez_parking_api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VeiculosController : ControllerBase
    {
        private readonly AppDbContext _context;

        public VeiculosController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetVeiculos()
        {
            var veiculos = _context.Veiculos.ToList();
            return Ok(veiculos);
        }

        [HttpPost]
        public async Task<IActionResult> RegistrarVeiculo([FromBody] Veiculo veiculo)
        {
            if(ModelState.IsValid)
            {
                _context.Veiculos.Add(veiculo);
                await _context.SaveChangesAsync();
                return CreatedAtAction(nameof(GetVeiculos), new { id = veiculo.ID }, veiculo); ;
            }
            return BadRequest(ModelState);
        }

        [HttpDelete]
        public async Task<IActionResult> ApagarVeiculo(int id)
        {
            if(id <= 0)
            {
                return BadRequest("ID inválido.");
            }
            var veiculoExistente = await _context.Veiculos.FindAsync(id);
            if (veiculoExistente == null)
            {
                return NotFound();
            }
            veiculoExistente.Active = false;
            _context.Veiculos.Update(veiculoExistente);
            await _context.SaveChangesAsync();
            return NoContent();
        }
        [HttpDelete("hard/{id}")]
        //USAR SOMENTE EM CASOS EXTREMOS!!!
        private async Task<IActionResult> HardDeleteVeiculo(int id)
        {
            //Novamente... USAR SOMENTE EM CASOS EXTREMOS!!!
            if (id <= 0)
            {
                return BadRequest("ID inválido.");
            }
            var veiculoExistente = await _context.Veiculos.FindAsync(id);
            if (veiculoExistente == null)
            {
                return NotFound();
            }
            _context.Veiculos.Remove(veiculoExistente);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
