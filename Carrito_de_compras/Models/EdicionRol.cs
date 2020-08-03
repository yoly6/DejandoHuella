﻿using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.ComponentModel;


namespace Carrito_de_compras.Models
{
    public class EdicionRol
    {
        [DisplayName("Rol")]
        public IdentityRole Rol { get; set; }

        [DisplayName("Miembros")]
        public IEnumerable<IdentityUser> miembros { get; set; }

        [DisplayName("No miembros")]
        public IEnumerable<IdentityUser> noMiembros { get; set; }
    }
}
