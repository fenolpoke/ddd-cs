using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebServiceApplication.Helper
{
    public class ConnectionHelper
    {
        public static String connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename="+HttpContext.Current.Server.MapPath(@"..\App_Data\BakingPowder.mdf")+";Integrated Security=True"; 
    }
}