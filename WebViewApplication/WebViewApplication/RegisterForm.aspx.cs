using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebViewApplication.ViewController;

namespace WebViewApplication
{
    public partial class RegisterForm : System.Web.UI.Page
    {
        public String message;
        protected void Page_Load(object sender, EventArgs e)
        {
            message = Request.QueryString["error"];

        }

        protected void registerButton_Click(object sender, EventArgs e)
        {
            message = new CustomerController().addCustomer(name.Text,username.Text, password.Text);
        }

        protected void backButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("LoginForm.aspx");
        }
    }
}