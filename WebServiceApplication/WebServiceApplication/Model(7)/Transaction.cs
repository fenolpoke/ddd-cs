using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebServiceApplication.Model_7_
{
    public class Transaction
    {

        public int id { get; set; }
        public Customer customer { get; set; }
        public DateTime date { get; set; }
        public List<DetailTransaction> details { get; set; }
    }
}