using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;
using System.Xml.Serialization;

namespace SoapWcf
{
    /// <summary>
    /// Summary description for Payment
    /// </summary>
    [XmlRoot]
    [DataContract]
    [Serializable]
    public class Payment
    {
        [DataMember][XmlElement] public long Id { get; set; }
        [DataMember] [XmlElement] public PaymentStatus Status { get; set; }
        [DataMember(IsRequired = true)] [XmlElement(IsNullable = false)] public String CcNumber { get; set; }
        [DataMember(IsRequired = true)] [XmlElement(IsNullable = false)] public Double Amount { get; set; }
        public Payment()
        {
            //
            // TODO: Add constructor logic here
            //
        }
    }

    [XmlRoot]
    [DataContract]
    [Serializable]
    public enum PaymentStatus
    {
        [XmlEnum] [EnumMember]  WAITING,
        [XmlEnum] [EnumMember]  VALIDATED,
        [XmlEnum] [EnumMember]  CANCELLED,
        [XmlEnum] [EnumMember]  REJECTED

    }
}