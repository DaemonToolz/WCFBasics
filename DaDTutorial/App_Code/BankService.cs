using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;


namespace SoapWcf{
    /// <summary>
    /// Summary description for BankService
    /// </summary>
    [WebService(Name="Banking", Namespace="http://localhost/banking/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.None)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class BankService : System.Web.Services.WebService {
       
        public BankService()
        {

            //Uncomment the following line if using designed components 
            //InitializeComponent(); 
        }

        [WebMethod(EnableSession = false)]
        public Payment CreatePayment(String CardNumber, Double Amount) {
            return  PaymentDAO.Add(new Payment() { CcNumber = CardNumber, Amount = Amount });
        }

        [WebMethod(EnableSession = false)]
        public List<Payment> GetAllPayments(){
            return PaymentDAO.GetAllStoredPayments();
        }

        [WebMethod(EnableSession = false)]
        public Payment DeletePayment(long pid)
        {
            try
            {
                return PaymentDAO.Delete(pid);
            }
            catch
            {
                return null;
            }
        }

    }

}