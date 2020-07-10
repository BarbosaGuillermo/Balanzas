//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Balanzas.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Dispositivo
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Dispositivo()
        {
            this.Lecturas = new HashSet<Lectura>();
            this.SystemLogs = new HashSet<SystemLog>();
        }
    
        public int Id { get; set; }
        public string Puesto { get; set; }
        public string Ubicacion { get; set; }
        public string URI { get; set; }
        public bool Habilitado { get; set; }
        public int DriverId { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Lectura> Lecturas { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SystemLog> SystemLogs { get; set; }
        public virtual Driver Driver { get; set; }
    }
}
