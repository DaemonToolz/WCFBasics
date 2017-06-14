using SoapWcf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.MsmqIntegration;
using System.Text;

// NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "MessageBroker" in code, svc and config file together.
[ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Multiple)]
[ServiceKnownType(typeof(Payment))]
public partial class MessageBroker : IMessageBroker
{
    private static ServiceHost _shost;
    public MessageBroker() { }


    static MessageBroker(){
        try
        {
            _shost = new ServiceHost(typeof(Payment));
            _shost.Open();
        }
        catch{
            _shost = null;
        }
     }

    public void ProcessMessage(MsmqMessage<Payment> msg){
        PaymentDAO.Add(msg.Body);
    }
}