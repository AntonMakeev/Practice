//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CourseWork.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class AllOrder
    {
        public int ChequeID { get; set; }
        public Nullable<System.DateTime> ChequeDate { get; set; }
        public Nullable<System.DateTime> OrderDate { get; set; }
        public string OrderStatusName { get; set; }
        public string VerifingCode { get; set; }
        public Nullable<int> ClientID { get; set; }
        public Nullable<decimal> Summ { get; set; }
    }
}