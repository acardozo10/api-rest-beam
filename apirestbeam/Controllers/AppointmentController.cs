using apirestbeam.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace apirestbeam.Controllers
{
    public class AppointmentController : ApiController
    {
        public IHttpActionResult Get(int id)
        {
            try
            {
                List<Appointment> result = AppointmentManagement.GetAppointment(id);
                if (result != null)
                {
                    return Ok(result);
                }
                else
                {
                    return BadRequest(ConfigurationManager.AppSettings[EnumMsjException.msgNoData.ToString()]);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
