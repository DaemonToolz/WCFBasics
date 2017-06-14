using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;

namespace SoapWcf
{
    /// <summary>
    /// Summary description for Class1
    /// </summary>
    public static class PaymentDAO
    {
        static PaymentDAO(){

        }

        //compteur initialisé à 1
        private static long count = 0L;
        private static ConcurrentDictionary<long, Payment> payments = new ConcurrentDictionary<long, Payment>();

        public static Payment Add(Payment payment)
        {
            if (payment.Amount <= 0)
                throw new InvalidOperationException("Invalid Amount");

            if (payment.CcNumber.Length != 10)
                throw new InvalidOperationException("Invalid Card");

            
            payment.Id = (Interlocked.Increment(ref count));//on génère l'id
            payment.Status = (PaymentStatus.VALIDATED);
            //on stocke l'ordre de paiement dans la Map - la clé est l'id.
            payments.TryAdd(payment.Id, payment);
            return payment;
        }


        public static  Payment Delete(long id)
        {
            Payment deletedPayment;
            payments.TryRemove(id, out deletedPayment);
            //on  supprime  de  l'entrée        
            //correspondant à l'id passé
            if (deletedPayment == null)
            {
                return null;
            }

            deletedPayment.Status = (PaymentStatus.CANCELLED);
            return deletedPayment;
        }


        public static  Payment Find(long id)
        {
            return payments[id];//récupération  dans  la    Map  de  l'objet  Payment  associé à la clé 
        }


        public static  List<Payment> GetAllStoredPayments()
        {
            List<Payment> paymentList = new List<Payment>(payments.Values);
            //Boucle pour tracer la liste - pourra être supprimée par la suite

            return paymentList;
        }

    }
}