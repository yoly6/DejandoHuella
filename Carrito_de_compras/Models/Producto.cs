using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Carrito_de_compras.Models
{
    public class Producto
    {
        public Producto()
        {
            Detalle = new HashSet<Detalle>();
        }
        //Propiedades
        [Key]
        [DisplayName("Identificador")]
        public int ProductosId { get; set; }

        [DisplayName("Nombre")]
        [Required(ErrorMessage = "Nombre Obligatorio")]
        public string ProductosNombre { get; set; }

        [DisplayName("Precio")]
        [Required(ErrorMessage = "Precio Obligatorio")]
        public double? ProductosPrecio { get; set; }

        [DisplayName("Stock")]
        [Required(ErrorMessage = "Stock Obligatorio")]
        public double? ProductosStock { get; set; }

        [DisplayName("Categoria Id")]
        public int? CategoriaId { get; set; }

        [NotMapped]
        [DisplayName("Subir Imagen")]
        public IFormFile ImageFile { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        [DisplayName("Imagen")]
        public string ImageName { get; set; }

        //Relacion FKs
        public virtual Categoria Categoria { get; set; }
        public virtual ICollection<Detalle> Detalle { get; set; }
    }
}

