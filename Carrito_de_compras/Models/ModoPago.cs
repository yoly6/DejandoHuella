using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Carrito_de_compras.Models
{
    public class ModoPago
    {
       
    [Key]
        public int ModoPagoId { get; set; }

        [DisplayName("Modo de Pago")]
        public string ModoPagoDescripcion { get; set; }

      
    }
}
