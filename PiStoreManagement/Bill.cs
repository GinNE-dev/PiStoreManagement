//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PiStoreManagement
{
    using System;
    using System.Collections.Generic;
    
    public partial class Bill
    {
        public string ID { get; set; }
        public string OrderID { get; set; }
        public string ClientID { get; set; }
        public string EmployeeID { get; set; }
        public Nullable<System.DateTime> BillDate { get; set; }
        public double TotalPrice { get; set; }
    
        public virtual Client Client { get; set; }
        public virtual Employee Employee { get; set; }
        public virtual Order Order { get; set; }
    }
}
