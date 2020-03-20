using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using DatingApp.API.Data;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace DatingApp.API.Controllers
{
    [Authorize] // todo lo que esta en este controlador necesita un token
    [ApiController]
    [Route("[controller]")]
    public class ValuesController : ControllerBase
    {

        private readonly DataContext _context;

        // constructor para inyectar dependencias
        public ValuesController(DataContext context)
        {
            _context = context;
        }

        // GET Api/values
        [HttpGet]
        public async Task<IActionResult> GetValues()
        {
            // obtenemos la data de la tabla Values y lo convertimos a una lista
            var values = await _context.Values.ToListAsync();


            // retornamos OK con los valores al cliente
            return Ok(values);
        }

        [AllowAnonymous]
        // GET Api/values/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetValue(int id)
        {
            var value = await _context.Values.FirstOrDefaultAsync(x => x.Id == id);

            return Ok(value);
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {

        }
    }
}
