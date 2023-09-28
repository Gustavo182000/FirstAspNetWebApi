using FirstAspNetWebApi.Data;
using FirstAspNetWebApi.Model;
using Microsoft.AspNetCore.Mvc;

namespace FirstAspNetWebApi.Controllers
{
    [ApiController]
    [Route("api/v1/funcionario")]
    public class FuncionarioController : Controller
    {
        private readonly ApplicationDbContext _context;

        public FuncionarioController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult Add([FromForm] FuncionarioModel funcionario)
        {
            if (ModelState.IsValid)
            {
                if (funcionario.photo != null)
                {
                    var filePath = Path.Combine("Storage", Guid.NewGuid().ToString() + funcionario.photo.FileName);

                    using Stream fileStream = new FileStream(filePath, FileMode.Create);
                    funcionario.photo.CopyTo(fileStream);
                    funcionario.photoPath = filePath;
                }

                _context.Add(funcionario);
                _context.SaveChanges();

                return Ok();
            }

            return BadRequest();
        }

        [HttpGet]
        public IActionResult Get()
        {
            var funcionarios = _context.Funcionarios;

            return Ok(funcionarios);
        }
        [HttpGet("{id:int}")]
        public IActionResult GetById(int Id)
        {
            if (Id == null || Id == 0)
            {
                return BadRequest();
            }
            FuncionarioModel? funcionario = _context.Funcionarios.FirstOrDefault(el => el.Id == Id);

            if (funcionario == null)
            {
                return BadRequest();
            }
            return Ok(funcionario);
        }







    }
}
