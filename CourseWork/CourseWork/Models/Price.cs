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
    
    public partial class Price
    {
        public int PriceID { get; set; }
        public Nullable<decimal> PriceMeaning { get; set; }
        public Nullable<System.DateTime> PriceDate { get; set; }
        public Nullable<int> DishID { get; set; }
    
        public virtual Dish Dish { get; set; }
    }
}
