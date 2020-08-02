using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebViewApplication.CustomerAPI;
using WebViewApplication.ViewController;

namespace WebViewApplication
{
    public partial class LoginForm : System.Web.UI.Page
    {
        public String message;
        protected void Page_Load(object sender, EventArgs e)
        {
            message = Request.QueryString["error"];

            if(message == "")
            {
                Response.Redirect("MainForm.aspx");
            }

            if (!Page.IsPostBack)
            {
                if (Request.Cookies["username"] != null)
                {
                    username.Text = Request.Cookies["username"].Value.ToString();
                }
            }
        }

        protected void loginButton_Click(object sender, EventArgs e)
        {
            message = new CustomerController().getCustomer(username.Text,password.Text,remember.Checked);            

            Response.Redirect("LoginForm.aspx?error="+message);
//            Session.Clear()
        }

        protected void registerButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("RegisterForm.aspx");
        }
    }
}