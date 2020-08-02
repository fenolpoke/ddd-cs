using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebViewApplication.Model
{
    public class Customer
    {
        public int id { get; set; }
        public String name { get; set; }
        public String username { get; set; }
        public String password { get; set; }

        public Customer()
        {

        }

        public Customer(int id, String name, String username, String password)
        {
            this.id = id;
            this.name = name;
            this.username = username;
            this.password = password;
        }

    }
}