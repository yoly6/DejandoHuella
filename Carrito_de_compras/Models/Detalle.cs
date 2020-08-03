using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Carrito_de_compras.Models
{
    public class Detalle
    {
        //Propiedades
        [Key]
        public int DetalleId { get; set; }

        [DisplayName("Factura Id")]
        public int? FacturaId { get; set; }

        [DisplayName("Producto Id")]
        public int? ProductoId { get; set; }

        [DisplayName("Cantidad")]
        public int? DetalleCantidad { get; set; }

        [DisplayName("Precio")]
        public double? DetallePrecio { get; set; }

        //Relaciones FKs
        public virtual Factura Factura { get; set; }
        public virtual Producto Producto { get; set; }
    }
}
