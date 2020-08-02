using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;

namespace WebServiceApplication.Helper
{
    public static class JSONHelper
    {
        public static String convertToJSON(this object obj)
        {
            return new JavaScriptSerializer().Serialize(obj);
        }
    }
}