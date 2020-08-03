using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Carrito_de_compras.Models
{
    public class Factura
    {
        public Factura()
        {
            Detalle = new HashSet<Detalle>();
        }
        //Propiedades
        [Key]
        public int FacturaId { get; set; }

        [DisplayName("Identificador")]
        public int? ClienteId { get; set; }

        [DisplayName("Fecha Transaccion")]
        public DateTime? FacturaFecha { get; set; }

        [DisplayName("Descripcion")]
        public string FacturaDescripcion { get; set; }

  
        

        //Relacion Foreing Key
        public virtual Cliente Cliente { get; set; }
        public virtual ICollection<Detalle> Detalle { get; set; }
    }
}