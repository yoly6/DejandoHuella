using System.ComponentModel;

namespace Carrito_de_compras.Models
{
    public class ModificacionRol
    {
        [DisplayName("Nombre Rol")]
        public string RoleName { get; set; }

        [DisplayName("Id Rol")]
        public string RoleId { get; set; }

        [DisplayName("Agregar Rol")]
        public string[] AumentarIds { get; set; }

        [DisplayName("Eliminar Rol")]
        public string[] BorrarIds { get; set; }
    }
}
