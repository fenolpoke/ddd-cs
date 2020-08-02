using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebServiceApplication.Model_7_
{
    public class Powder
    {
        public int id { get; set; }
        public String name { get; set; }
        public int price { get; set; }
        public int stock { get; set; }
        public String type { get; set; }
        public String acid { get; set; }

        public Powder(int id, String name, int price, int stock, String type, String acid)
        {
            this.id = id;
            this.name = name;
            this.price = price;
            this.stock = stock;
            this.type = type;
            this.acid = acid;
        }
        public Powder() { }
    }
}