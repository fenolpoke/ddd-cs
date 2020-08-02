using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebServiceApplication.Model_7_;

namespace WebServiceApplication.Factory_6_
{
    public class CustomerFactory
    {
        public static Customer createCustomer(int id, String name, String username, String password)
        {
            return new Customer(id, name, username, password);
        }
    }
}