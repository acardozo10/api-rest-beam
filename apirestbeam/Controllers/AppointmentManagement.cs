using apirestbeam.Models;
using log4net;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity.Core;
using System.Linq;
using System.Web;

namespace apirestbeam.Controllers
{
    public class AppointmentManagement
    {
        private static ILog loggerAppointment;
        public AppointmentManagement()
        {
            loggerAppointment = log4net.LogManager.GetLogger("AppointmentLogs");
            log4net.Config.XmlConfigurator.Configure();
        }
        public static List<Appointment> GetAppointment(int AreaId)
        {
            List<Appointment> lstAppointments = new List<Appointment>();
            List<TBL_APPOINTMENT> lstAppointmentsTemp = null;
            try
            {
                using (var entity = new BeamEntities())
                {
                    lstAppointmentsTemp = entity.TBL_APPOINTMENT.Where(x => x.AppointmentState == 1 && x.AreaId== AreaId).ToList();
                }
            }
            catch (InvalidOperationException ioex)
            {
                loggerAppointment.Error(String.Format("{0} Exception: {1} StackTrace: {2}",ConfigurationManager.AppSettings[EnumMsjException.msgInvalidOperation.ToString()],ioex.Message , ioex.StackTrace));
                throw new Exception(String.Format("{0}", ConfigurationManager.AppSettings[EnumMsjException.msgInvalidOperation.ToString()]));
            }
            catch (ArgumentException aex)
            {
                loggerAppointment.Error(String.Format("{0} Exception: {1} StackTrace: {2}", ConfigurationManager.AppSettings[EnumMsjException.msgInvalidArgument.ToString()], aex.Message , aex.StackTrace));
                throw new Exception(String.Format("{0}", ConfigurationManager.AppSettings[EnumMsjException.msgInvalidArgument.ToString()]));
            }
            catch (EntityException exc)
            {
                loggerAppointment.Error(String.Format("{0} Exception: {1} StackTrace: {2}", ConfigurationManager.AppSettings[EnumMsjException.msgConnection.ToString()], exc.Message , exc.StackTrace));
                throw new Exception(String.Format("{0}", ConfigurationManager.AppSettings[EnumMsjException.msgConnection.ToString()]));
            }
            try
            {
                
                foreach(var appointmentsTemp in lstAppointmentsTemp)
                {
                    Appointment appointment = new Appointment();
                    appointment.AppointmentId = appointmentsTemp.AppointmentId;
                    appointment.AppointmentName = appointmentsTemp.AppointmentName;
                    appointment.AreaId = appointmentsTemp.AreaId;
                    lstAppointments.Add(appointment);
                }
                return lstAppointments;
            }
            catch (Exception ex)
            {
                loggerAppointment.Error(String.Format("{0} Exception: {1} StackTrace: {2}", ConfigurationManager.AppSettings[EnumMsjException.msgConversionError.ToString()], ex.Message, ex.StackTrace));
                throw new Exception(String.Format("{0}", ConfigurationManager.AppSettings[EnumMsjException.msgConversionError.ToString()]));
            }
        }
    }
}