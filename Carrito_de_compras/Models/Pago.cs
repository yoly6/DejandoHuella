using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;


namespace Carrito_de_compras.Models
{
    public class Pago
    {
        public Pago()
        {
            ModoPago = new HashSet<ModoPago>();
        }
  
    [Key]
    public int PagoId { get; set; }

    [DisplayName("Identificador")]
    public int? ClienteId { get; set; }

    [DisplayName("Fecha Transaccion")]
    public DateTime? PagoFecha { get; set; }

    [DisplayName("Identificador")]
    public int? ModoPagoId { get; set; }
        //Relacion Foreing Key
        public virtual ICollection<ModoPago> ModoPago { get; set; }
   }
  }