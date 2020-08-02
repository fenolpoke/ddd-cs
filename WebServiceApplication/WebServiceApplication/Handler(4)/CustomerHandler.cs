using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebServiceApplication.Model_7_;
using WebServiceApplication.Repository_5_;

namespace WebServiceApplication.Handler_4_
{
    public class CustomerHandler
    {
        CustomerRepository userRepository;

        public CustomerHandler()
        {

            userRepository = new CustomerRepository();

        }

        public Customer getCustomer(String username, String password)
        {
            return userRepository.getCustomer(username,password);
        }

        public String addCustomer(String name, String username, String password)
        {
            return userRepository.addCustomer(name, username, password);
        }

    }
}