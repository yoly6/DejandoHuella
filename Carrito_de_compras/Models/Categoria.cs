using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;


namespace Carrito_de_compras.Models
{
    public class Categoria
    {
        public Categoria()
        {
            Producto = new HashSet<Producto>();
        }
        [Key]
        public int CategoriaId { get; set; }

        [DisplayName("Nombre")]

        [Required(ErrorMessage = "Nombre Obligatorio")]
        public string CategoriaNombre { get; set; }

        [DisplayName("Descripcion")]
        public string FacturaDescripcion { get; set; }

        public virtual ICollection<Producto> Producto { get; set; }
    }
}
