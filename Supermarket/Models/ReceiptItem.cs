//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Supermarket.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class ReceiptItem
    {
        public int id { get; set; }
        public int id_receipt { get; set; }
        public int id_product { get; set; }
        public int quantity { get; set; }
        public decimal total_price { get; set; }
        public Nullable<bool> is_active { get; set; }
    
        public virtual Product Product { get; set; }
        public virtual Receipt Receipt { get; set; }
    }
}
