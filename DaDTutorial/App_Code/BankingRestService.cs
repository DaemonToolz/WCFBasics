using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using SoapWcf;

// NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "BankingRestService" in code, svc and config file together.
namespace RestWcf{
    public class BankingRestService : IBankingRestService{
        public bool Add(Payment p){
            try
            {
                PaymentDAO.Add(p);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public List<Payment> GetAllStoredPayments(){
            return PaymentDAO.GetAllStoredPayments();
        }
    }

}