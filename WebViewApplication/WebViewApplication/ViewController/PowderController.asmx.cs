using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Services;
using WebViewApplication.Model;

namespace WebViewApplication.ViewController
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

        public List<Powder> getAllPowders()
        {
            PowderAPI.PowderController powderController = new PowderAPI.PowderController();

            List<Powder> powders = new List<Powder>();

            if (!powderController.getAllPowders().Equals("null"))
            {
                powders = new JavaScriptSerializer().Deserialize<List<Powder>>(powderController.getAllPowders());
                
            }

            return powders;
        }


        public String updateStocks(List<Powder> powders, String id)
        {
            PowderAPI.PowderController powderController = new PowderAPI.PowderController();
            return powderController.updateStocks(new JavaScriptSerializer().Serialize(powders), id);
        }

        public String deletePowder(Int32 id)
        {
            PowderAPI.PowderController powderController = new PowderAPI.PowderController();
            return powderController.deletePowder(id);
        }

    }
}
