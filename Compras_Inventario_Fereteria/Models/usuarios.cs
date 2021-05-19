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
    using System.ComponentModel.DataAnnotations;

    public partial class usuarios
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public usuarios()
        {
            this.empleado = new HashSet<empleado>();
        }
    
        public int id_usuario { get; set; }

        [Required()]
        [Display(Name ="Nombre de Usuario")]
        public string nombre { get; set; }

        [Required()]
        [Display(Name = "Correo Electronico")]
        [DataType(DataType.EmailAddress)]
        public string email { get; set; }

        [Required()]
        [Display(Name = "Contraseña")]
        public string pasword { get; set; }

        [Required()]
        [Display(Name = "Rol")]
        public int id_rol { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<empleado> empleado { get; set; }

        [Display(Name = "Rol")]
        public virtual roles roles { get; set; }
    }
}
