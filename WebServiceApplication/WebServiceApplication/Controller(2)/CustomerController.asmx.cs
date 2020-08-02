using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using WebServiceApplication.Handler_4_;
using WebServiceApplication.Helper;
using WebServiceApplication.Model_7_;

namespace WebServiceApplication.Controller_2_
{
    /// <summary>
    /// Summary description for UserController
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class UserController : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }
        [WebMethod]
        public String getCustomer(String username, String password)
        {
            String result = "Username and Password mismatch";
            Customer customer = new CustomerHandler().getCustomer(username, password);
            if (customer != null)
            {
                //                result = JSONHelper.convertToJSON(user);
                result = customer.convertToJSON();
            }
            return result;
        }

        [WebMethod]
        public String addCustomer(String name, String username, String password)
        {
            return new CustomerHandler().addCustomer(name, username, password);
        }

    }
}
