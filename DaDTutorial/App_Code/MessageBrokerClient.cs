using SoapWcf;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Messaging;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Dispatcher;
using System.Text;
using System.Threading;
using System.ServiceModel.MsmqIntegration;

// NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "MessageBrokerClient" in code, svc and config file together.

public class MessageBrokerClient : IMessageBrokerClient {
    
    private static readonly String MsmqEndpointAddress =  @".\private$\dadtutorial";
    private static MessageQueue CommonQueue;
    [OperationBehavior(TransactionScopeRequired = true, TransactionAutoComplete = true)]
    public void TransmitMessage(Payment msg)
    {
        if (CommonQueue == null)
        {
            Console.WriteLine("No Associated Queue.");
            return;
        }
        CommonQueue.Send(msg);
    }

    private static long ClientCount = 0;

    public void Register()
    {
        try{
            ClientCount = (Interlocked.Increment(ref ClientCount));
            if (ClientCount == 1){
                if (!MessageQueue.Exists(MsmqEndpointAddress)){
                    CommonQueue = MessageQueue.Create(MsmqEndpointAddress);
                }
                else
                {
                    CommonQueue = new MessageQueue(MsmqEndpointAddress);
                    CommonQueue.MessageReadPropertyFilter.Priority = true;
                }
            }
       
        }
        catch
        {
            Unregister();
        }
    }

    public void Unregister()
    {
        try
        {
            ClientCount = (Interlocked.Decrement(ref ClientCount));
            if (ClientCount == 0)
            {
                CommonQueue.Close();
            }
        }
        catch
        {

        }
    }
}
