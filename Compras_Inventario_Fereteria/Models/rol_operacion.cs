//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Compras_Inventario_Fereteria.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class rol_operacion
    {
        public int id_rol_operacion { get; set; }
        public int id_rol { get; set; }
        public int id_operacion { get; set; }
    
        public virtual operacioes operacioes { get; set; }
        public virtual roles roles { get; set; }
    }
}
