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
    
    public partial class Lectura
    {
        public int Id { get; set; }
        public string DatoLeido { get; set; }
        public string DatoDespachado { get; set; }
        public System.DateTime TimePrint { get; set; }
        public int DispositivoId { get; set; }
    
        public virtual Dispositivo Dispositivo { get; set; }
    }
}