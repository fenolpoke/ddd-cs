using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebServiceApplication.Model_7_;
using WebServiceApplication.Repository_5_;

namespace WebServiceApplication.Handler_4_
{
    public class PowderHandler
    {


        PowderRepository powderRepository;

        public PowderHandler()
        {

            powderRepository = new PowderRepository();

        }

        public List<Powder> getAllPowders()
        {
            return powderRepository.getAllPowders();
        }
        public String updateStocks(List<Powder> powders, String id)
        {
            return powderRepository.updateStocks(powders, id);
        }
        public String deletePowder(Int32 id)
        {
            return powderRepository.deletePowder(id);
        }
    }
}