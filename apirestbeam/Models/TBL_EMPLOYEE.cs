//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace apirestbeam.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class TBL_EMPLOYEE
    {
        public int Id { get; set; }
        public string GuidEmployee { get; set; }
        public string FullName { get; set; }
        public System.DateTime BirthDate { get; set; }
        public string Country { get; set; }
        public string Username { get; set; }
        public System.DateTime HiringDate { get; set; }
        public int State { get; set; }
        public int AppointmentId { get; set; }
        public Nullable<double> Commision { get; set; }
    
        public virtual TBL_APPOINTMENT TBL_APPOINTMENT { get; set; }
    }
}
