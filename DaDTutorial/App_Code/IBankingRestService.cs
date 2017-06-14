using SoapWcf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Web.Services;
using System.Text;

namespace  RestWcf
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IBankingRestService" in both code and config file together.
    [ServiceContract]
    public interface IBankingRestService
    {
        [OperationContract]
        [WebGet(UriTemplate = "banking/payments", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        List<Payment> GetAllStoredPayments();

        [OperationContract]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json,UriTemplate = "banking") ]
        bool Add(Payment p);
    }
}
