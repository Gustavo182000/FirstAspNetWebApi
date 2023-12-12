using FirstAspNetWebApi.Data;
using FirstAspNetWebApi.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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

        [HttpPut("{id:int}")]
        public  IActionResult Update(int Id, [FromBody] FuncionarioModel funcionario)
        {

            if (Id != funcionario.Id)
            {
                return BadRequest();
            }

            _context.Entry(funcionario).State = EntityState.Modified;

            try
            {
                 _context.SaveChangesAsync();
            }
            catch
            {

                return NotFound();

            }

            return NoContent();

        }

        [HttpDelete("{id:int}")]
        public IActionResult Delete(int Id)
        {

            if(Id == null || Id == 0)
            {
                return BadRequest();
            }

            var funcionario = _context.Funcionarios.FirstOrDefault(el => el.Id == Id);

            if(funcionario == null)
            {
                return BadRequest();
            }

            _context.Entry(funcionario).State = EntityState.Deleted;
            _context.SaveChanges();

            return Ok();

        }

        [HttpGet]
        [Route("{id}/download")]
        public IActionResult GetPhoto(int Id)
        {
            var funcionario = _context.Funcionarios.FirstOrDefault(el => el.Id == Id);

            if(funcionario == null)
            {
                return BadRequest();    
            }

            if (funcionario.photoPath != null)
            {
                var dataBytes = System.IO.File.ReadAllBytes(funcionario.photoPath);

                return File(dataBytes, "image/png");
            }

            return BadRequest();

        }

    }
}
