using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace apirestbeam.Models
{
    public class Employe
    {
        [Required]
        public string GuidEmploye { get; set; }
        [Required]
        public string FullName { get; set; }
        [Required]
        public DateTime BirthDate { get; set; }
        [Required]
        public string Country { get; set; }
        [Required]
        public string User { get; set; }
        [Required]
        public DateTime DateContracting { get; set; }
        [Required]
        public int  State { get; set; }
        [Required]
        public int AreaId { get; set; }
        [Required]
        public int AppointmentId { get; set; }
        [Required]
        public double Commission { get; set; }

    }
}