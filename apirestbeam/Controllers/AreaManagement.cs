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
    public class AreaManagement
    {
        private static ILog loggerArea;
        public AreaManagement()
        {
            loggerArea = log4net.LogManager.GetLogger("AreaLogs");
            log4net.Config.XmlConfigurator.Configure();
        }
        public static List<Area> GetAreas()
        {
            List<Area> lstAreas = new List<Area>();
            List<TBL_AREA> lstAreasTemp = null;
            try
            {
                using (var entity = new BeamEntities())
                {
                    lstAreasTemp = entity.TBL_AREA.Where(x => x.AreaState == 1).ToList();
                }
            }
            catch (InvalidOperationException ioex)
            {
                loggerArea.Error(String.Format("{0} Exception: {1} StackTrace: {2}",ConfigurationManager.AppSettings[EnumMsjException.msgInvalidOperation.ToString()],ioex.Message , ioex.StackTrace));
                throw new Exception(String.Format("{0}", ConfigurationManager.AppSettings[EnumMsjException.msgInvalidOperation.ToString()]));
            }
            catch (ArgumentException aex)
            {
                loggerArea.Error(String.Format("{0} Exception: {1} StackTrace: {2}", ConfigurationManager.AppSettings[EnumMsjException.msgInvalidArgument.ToString()], aex.Message , aex.StackTrace));
                throw new Exception(String.Format("{0}", ConfigurationManager.AppSettings[EnumMsjException.msgInvalidArgument.ToString()]));
            }
            catch (EntityException exc)
            {
                loggerArea.Error(String.Format("{0} Exception: {1} StackTrace: {2}", ConfigurationManager.AppSettings[EnumMsjException.msgConnection.ToString()], exc.Message , exc.StackTrace));
                throw new Exception(String.Format("{0}", ConfigurationManager.AppSettings[EnumMsjException.msgConnection.ToString()]));
            }
            try
            {
                
                foreach(var areaTemp in lstAreasTemp)
                {
                    Area area = new Area();
                    area.AreaId = areaTemp.AreaId;
                    area.AreaName = areaTemp.AreaName;
                    lstAreas.Add(area);
                }
                return lstAreas;
            }
            catch (Exception ex)
            {
                loggerArea.Error(String.Format("{0} Exception: {1} StackTrace: {2}", ConfigurationManager.AppSettings[EnumMsjException.msgConversionError.ToString()], ex.Message, ex.StackTrace));
                throw new Exception(String.Format("{0}", ConfigurationManager.AppSettings[EnumMsjException.msgConversionError.ToString()]));
            }
        }
    }
}