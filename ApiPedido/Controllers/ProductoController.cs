using Microsoft.AspNetCore.Mvc;
using ApiPedido.Models;
using ApiPedido.Data;
using Microsoft.EntityFrameworkCore;

namespace ApiPedidos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public ProductoController(ApplicationDbContext context)
        {
            _context = context;
        }
        
        [HttpGet]
        public async Task<IActionResult> ListadoProducto()
                {
                    var listadoProducto = await _context.Productos.Include(p => p.Categoria).ToListAsync();

                    var productoMostrar = listadoProducto.Select(p => new Producto
                    {
                        ProductoID = p.ProductoID,
                        Nombre = p.Nombre,
                        Descripcion = p.Descripcion,
                        PrecioCosto = p.PrecioCosto,
                        PrecioVenta = p.PrecioVenta,
                        Stock = p.Stock,
                        CategoriaID = p.CategoriaID,

                        Categoria = p.Categoria
                    }).ToList();
                    return Ok(productoMostrar);
                }
    }
}