using System;
using System.ServiceModel.Channels;
using System.Configuration;
using System.Messaging;
using System.ServiceModel;
using System.Transactions;
using System.Runtime.Serialization;
using System.Collections.Generic;
using System.ServiceModel.Dispatcher;
using CSDummyClient.MsmqReference;

namespace CSDummyClient{


    class Program{
        static void Main(string[] args){
            MessageBrokerClientClient mbcc = new MessageBrokerClientClient();
            //mbcc.Open();
            mbcc.Register();
            mbcc.TransmitMessage(new Payment() { CcNumber = "0123456789", Amount = 100.0 });
            Console.ReadKey();
            mbcc.Close();
        }
    }
}
