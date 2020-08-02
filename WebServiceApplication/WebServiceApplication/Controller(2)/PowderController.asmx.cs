using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using WebServiceApplication.Handler_4_;
using WebServiceApplication.Model_7_;
using WebServiceApplication.Helper;
using System.Web.Script.Serialization;

namespace WebServiceApplication.Controller_2_
{
    /// <summary>
    /// Summary description for PowderController
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class PowderController : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }

        [WebMethod]
        public String getAllPowders()
        {
            return new PowderHandler().getAllPowders().convertToJSON();
        }
        [WebMethod]
        public String updateStocks(String stringPowders, String id)
        {

            List<Powder> powders = new JavaScriptSerializer().Deserialize<List<Powder>>(stringPowders);

            return new PowderHandler().updateStocks(powders, id);
        }
        [WebMethod]
        public String deletePowder(Int32 id)
        {
            return new PowderHandler().deletePowder(id);
        }

    }
}
