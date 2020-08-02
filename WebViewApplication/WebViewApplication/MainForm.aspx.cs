using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebViewApplication.Model;
using WebViewApplication.ViewController;

namespace WebViewApplication
{
    public partial class MainForm : System.Web.UI.Page
    {
        public List<Powder> powders;
        public String error = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            powders = new PowderController().getAllPowders();
            if (!Page.IsPostBack)
            {
                if (Session["user"] == null)
                {
                    Response.Redirect("LoginForm.aspx");
                }
            }
            String id = Request.QueryString["id"];
            if (id != null)
            {
                if (Request.QueryString["insert"] != null) {
                    if (Session[id] == null)
                    {
                        Session[id] = "0";
                    }

                    if (Int32.Parse((String)Session[id]) >= powders[Int32.Parse(id) - 1].stock)
                    {

                        error = powders[Int32.Parse(id) - 1].name + " out of stock !";
                    }
                    else
                    {
                        Session[id] = (Int32.Parse((String)Session[id]) + 1).ToString();
                        error = powders[Int32.Parse(id) - 1].name + " added to cart into " + Session[id] + " !";

                    }
                }else if(Request.QueryString["update"] != null)
                {
                    if (Session[id] == null)
                    {
                        Session[id] = "0";
                    }

                    if (Session[id].Equals("0")){

                        error = powders[Int32.Parse(id) - 1].name + " already zero !";
                    }
                    else
                    {
                        Session[id] = (Int32.Parse((String)Session[id]) - 1).ToString();
                        error = powders[Int32.Parse(id) - 1].name + " deleted from cart into " + Session[id] + " !";

                    }
                }else if(Request.QueryString["delete"] != null)
                {
                    Response.Redirect("MainForm.aspx?error=" + new PowderController().deletePowder(Int32.Parse(id)));
                }
            }
            else
            {

                error = Request.QueryString["error"];
            }

        }
        
        protected void addToCart_Click(object sender, EventArgs e)
        {
            Response.Redirect("MainForm.aspx?"+((Button)sender).ID);
        }

        protected void Unnamed1_Click(object sender, EventArgs e)
        {
            List<Powder> cart = new List<Powder>();
            foreach (Powder powder in powders)
            {
                if(Session[powder.id.ToString()] != null && Int32.Parse(Session[powder.id.ToString()].ToString()) > 0)
                {
                    powder.stock = Int32.Parse(Session[powder.id.ToString()].ToString());
                    cart.Add(powder);
                }
                Session[powder.id.ToString()] = "0";
            }

            Response.Redirect("MainForm.aspx?error=" + new PowderController().updateStocks(cart, Session["id"].ToString()));
        }
    }
}