using System.ComponentModel.DataAnnotations;

namespace ApiPedido.Models;

public class Producto
{

    [Key]

    public int ProductoID { get; set; }

    public int CategoriaID { get; set; }
    public string? Nombre { get; set; }
    public string? Descripcion { get; set; }

    public decimal PrecioCosto { get; set; }

    public decimal PrecioVenta { get; set; }

    public int Stock { get; set; }

    public virtual Categoria? Categoria{ get; set; }

    public ICollection<DetallePedido>? DetallePedidos { get; set; }



}