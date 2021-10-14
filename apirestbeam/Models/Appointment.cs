using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace apirestbeam.Models
{
    public class Appointment
    {
        public int AppointmentId { get; set; }
        public string AppointmentName { get; set; }
        public int AreaId { get; set; }
    }
}