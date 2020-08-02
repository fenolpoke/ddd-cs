using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Services;
using WebViewApplication.Model;

namespace WebViewApplication.ViewController
{
    /// <summary>
    /// Summary description for CustomerController
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class CustomerController : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }
       
        public String getCustomer(String username, String password, Boolean remember)
        {
            if (username.Equals(""))
            {
                return "Username must be filled!";
            }
            else if (password.Equals(""))
            {
                return "Password must be filled!";
            }
            CustomerAPI.UserController customerController = new CustomerAPI.UserController();
            if (customerController.getCustomer(username, password).Contains("username"))
            {
                Session["user"] = new JavaScriptSerializer().Deserialize<Customer>(customerController.getCustomer(username, password)).username;

                Session["id"] = new JavaScriptSerializer().Deserialize<Customer>(customerController.getCustomer(username, password)).id;

                if (remember)
                {
                    HttpCookie cookie = new HttpCookie("username",username);
                    cookie.Expires = DateTime.Now.AddHours(9);
                    HttpContext.Current.Response.Cookies.Add(cookie);
                }

                return "";
            }
            else
            {
                return "Username and password mismatch you don't";
            }
        }


        public String addCustomer(String name, String username, String password)
        {
            if (name.Equals(""))
            {
                return "Name must be filled!";
            }
            else if (username.Equals(""))
            {
                return "Username must be filled!";
            }
            else if (password.Equals(""))
            {
                return "Password must be filled!";
            }
            else
            {
                CustomerAPI.UserController customerController = new CustomerAPI.UserController();
                if (!customerController.addCustomer(name, username, password).Equals("null"))
                {
                    return "Register success! Please go back to login";
                }
                else
                {
                    return "Some error in registering";
                }
            }
        }


    }
}
