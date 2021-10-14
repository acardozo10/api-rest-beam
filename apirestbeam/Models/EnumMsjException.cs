using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace apirestbeam.Models
{
    public enum EnumMsjException
    {
        msgConversionError = 0,
        msgParameterError = 1,
        msgInvalidOperation = 2,
        msgInvalidArgument = 3,
        msgErrorConvertidor = 4,
        msgErrorView = 5,
        msgNullObject = 6,
        msgConnection = 7,
        msgNoData=8,
        msgDefaultError = 9,
    }
}