using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebServiceApplication.Model_7_;

namespace WebServiceApplication.Factory_6_
{
    public class PowderFactory
    {
        public static Powder createPowder(int id, String name, int price, int stock, String type, String acid)
        {
            return new Powder(id, name, price, stock, type, acid);
        }

    }
}