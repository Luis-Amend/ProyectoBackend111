using ApiPedido.Data;
using ApiPedido.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiPedidos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public CategoriaController(ApplicationDbContext context)
        {
            _context = context;
        }



        [HttpGet]
        public async Task<IActionResult> ListadoCategoria()
        {
            var categorias = await _context.Categorias.ToListAsync();

            return Ok(categorias);
        }



        [HttpPost]
        public async Task<IActionResult> CrearCategoria([FromBody] Categoria categoria)
        {
            var nombreMayuscula = categoria.Nombre?.Trim().ToUpper();

            var existeCategoria = await _context.Categorias.AnyAsync(e => e.Nombre == nombreMayuscula);

            if (!existeCategoria)
            {
                var nuevaCategoria = new Categoria
                {
                    Nombre = nombreMayuscula,
                };
                             _context.Add(nuevaCategoria);
                await _context.SaveChangesAsync();
                return Ok("Categoria guardada");
            }


            return Ok();
        }




    }


}