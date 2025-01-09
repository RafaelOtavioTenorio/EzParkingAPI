using ez_parking_api.Data;
using ez_parking_api.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ez_parking_api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly AppDbContext _context;

        public UsersController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetUsers()
        {
            var users = _context.Users.ToList();
            return Ok(users);
        }
        [HttpGet("/{id}")]
        public async Task<IActionResult> GetUser(string Login)
        {
            var user = await _context.Users.FindAsync(Login);
            if (user == null)
            {
                return BadRequest("Usuário não encontrado");
            }
            return Ok(user);
        }
        [HttpPost]
        public async Task<IActionResult> AddUser([FromBody] User user)
        {
            if (ModelState.IsValid)
            {
                _context.Users.Add(user);
                await _context.SaveChangesAsync();
                return CreatedAtAction(nameof(GetUsers), new { id = user.ID }, user);
            }
            return BadRequest(ModelState);
        }
        [HttpPatch]
        public async Task<IActionResult> UpdateUser([FromBody] JsonPatchDocument<User> patchDoc, string filterColumn, string filterValue)
        {
            if (patchDoc == null)
            {
                return BadRequest("Nenhuma alteração foi realizada.");
            }
            if(string.IsNullOrEmpty(filterColumn) || string.IsNullOrEmpty(filterValue))
            {
                return BadRequest("Filtro inválido.");
            }
            var userExistente = await _context.Users.AsQueryable().Where(u => EF.Property<string>(u, filterColumn) == filterValue).FirstOrDefaultAsync();
            if (userExistente == null)
            {
                return BadRequest("Usuário não encontrado");
            }
            patchDoc.ApplyTo(userExistente);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await _context.SaveChangesAsync();

            return Ok(userExistente);
        }
        //DEPRECATED
        //public async Task<IActionResult> UpdateUser([FromBody] JsonPatchDocument<User> patchDoc, int id)
        //{
        //    if (patchDoc == null)
        //    {
        //        return BadRequest("Nenhuma alteração foi realizada.");
        //    }
        //    var userExistente = await _context.Users.FindAsync(id);
        //    if (userExistente == null)
        //    {
        //        return BadRequest("Usuário não encontrado");
        //    }
        //    patchDoc.ApplyTo(userExistente);
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }
        //    await _context.SaveChangesAsync();

        //    return Ok(userExistente);
        //}
        [HttpDelete]
        public async Task<IActionResult> ApagarUser(int id)
        {
            if (id <= 0)
            {
                return BadRequest("ID inválido.");
            }
            var userExistente = await _context.Users.FindAsync(id);
            if (userExistente == null)
            {
                return NotFound();
            }
            userExistente.Active = false;
            _context.Users.Update(userExistente);
            await _context.SaveChangesAsync();
            return NoContent();
        }
        [HttpDelete("hard/{id}")]
        //USAR SOMENTE EM CASOS EXTREMOS!!!
        private async Task<IActionResult> HardDeleteUser(int id)
        {
            //Novamente... USAR SOMENTE EM CASOS EXTREMOS!!!
            if (id <= 0)
            {
                return BadRequest("ID inválido.");
            }
            var userExistente = await _context.Users.FindAsync(id);
            if (userExistente == null)
            {
                return NotFound();
            }
            _context.Users.Remove(userExistente);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
