using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FirstAspNetWebApi.Data;
using FirstAspNetWebApi.Model;

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
        public IActionResult Add(FuncionarioModel funcionario)
        {
             if(ModelState.IsValid)
            {
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
            if(Id == null || Id == 0)
            {
                return BadRequest();
            }
            FuncionarioModel? funcionario = _context.Funcionarios.FirstOrDefault(el => el.Id == Id);

            if(funcionario == null)
            {
                return BadRequest();
            }
            return Ok(funcionario);
        }







    }
}
