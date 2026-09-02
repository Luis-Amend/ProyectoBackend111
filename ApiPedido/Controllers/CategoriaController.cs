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


        [HttpPut("{categoriaID}")]

        public async Task<IActionResult> EditarCategoria(int categoriaID, [FromBody] Categoria categoria)
            {
                var nombreMayuscula = categoria.Nombre?.Trim().ToUpper(); //guardar el nombre en mayuscula
                var editarCategoria = await _context.Categorias.Where(e => e.CategoriaID == categoriaID).SingleOrDefaultAsync();
                    // le decimos que busque en el contexto de categorias donde el id de la categoria coincida con el id del parametro

                if (editarCategoria == null)
                {
                return Ok("la categoria que quiere editar no existe");
                };

                var existeNombre = await _context.Categorias.AnyAsync(e => e.Nombre == nombreMayuscula && e.CategoriaID != categoriaID);

                //si el nombre es igual a la variable nombreMayuscula y que sea distinto al id guardado 

                if (!existeNombre)
                {
                    editarCategoria.Nombre = nombreMayuscula;
                    await _context.SaveChangesAsync();

                    return Ok("categoria editada exitosamente");
                }
                return Ok("ya existe una categoria con ese nombre");
            }

        [HttpDelete("{categoriaID}")]

        public async Task<IActionResult> Eliminar(int categoriaID)
        { 

            var categoria = await _context.Categorias.FindAsync(categoriaID);
             //pedimos que busque la categoria directamente por su id
            if (categoria == null)
            {
                return NotFound("categoria no encontrada");
            }
            _context.Categorias.Remove(categoria);
            await _context.SaveChangesAsync();
            return NoContent();

        }
    }
}