using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Carrito_de_compras.Models
{
    public class Cliente
     {
        public Cliente()
        { 
            Factura = new HashSet<Factura>();
           
         }
    //Propidades
    [Key]
    [DisplayName("Id")]
    public int ClienteId { get; set; }

    [DisplayName("Nombre")]
    [Required(ErrorMessage = "Nombre Obligatorio")]
    public string ClienteNombre { get; set; }

    [DisplayName("Apellido")]
    [Required(ErrorMessage = "Apellido Obligatorio")]
    public string ClienteApellido { get; set; }

    [DisplayName("Fecha Naciemiento")]
    public DateTime? PersonaFechaNacimiento { get; set; }

    [DisplayName("Emial")]
    [Required(ErrorMessage = "Email Obligatorio")]
     public string ClienteEmail { get; set; }

    [DisplayName("Direccion")]
    [Required(ErrorMessage = "Email Obligatorio")]
        public string ClienteDireccion { get; set; }

    [DisplayName("Telefono")]
    [Required(ErrorMessage = "Telefono Obligatorio")]
    public string ClienteTelefono { get; set; }

   
    [NotMapped]
    [DisplayName("Subir Imagen")]
    public IFormFile ImageFile { get; set; }

    [Column(TypeName = "nvarchar(100)")]
    [DisplayName("Fotografia")]
    public string ImageName { get; set; }

    //Relacion Foreing Keys
    public virtual ICollection<Factura> Factura { get; set; }

    }
}
