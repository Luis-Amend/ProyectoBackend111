using System.ComponentModel.DataAnnotations;

namespace ApiPedido.Models;

public class DetallePedido
{

    [Key]
    public int DetallePedidoId { get; set; }
    public int ProductoID { get; set; }

    public int PedidoID { get; set; }
    public decimal PrecioUnitario { get; set; }
    public int Cantidad { get; set; }

    public virtual Producto? Productos { get; set; }

    public virtual Pedido? Pedidos { get; set; }

}
