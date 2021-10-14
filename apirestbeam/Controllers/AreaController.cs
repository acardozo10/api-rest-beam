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
    public class AreaController : ApiController
    {
        // GET: api/Users
        public IHttpActionResult Get()
        {
            try
            {
                List<Area> result = AreaManagement.GetAreas();
                if (result!=null)
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
