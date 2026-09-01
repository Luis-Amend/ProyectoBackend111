using System.ComponentModel.DataAnnotations;

namespace ApiPedido.Models;

public class Pedido
{

    [Key]
    public int PedidoID { get; set; }
    public string? Nombre { get; set; }
    public Estado Estado { get; set; }

    public DateTime Fecha { get; set; }

    public ICollection<DetallePedido>? DetallePedidos { get; set; }

}

public enum Estado
{
     Pendiente,
    Envidado,

    Entregado
}