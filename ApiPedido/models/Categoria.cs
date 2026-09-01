using System.ComponentModel.DataAnnotations;

namespace ApiPedido.Models;

public class Categoria
{

    [Key]
    public int CategoriaID { get; set; }
    public string? Nombre { get; set; }

    public ICollection<Producto>? Productos { get; set;}


}