//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ProgFarmes.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class farm_products
    {
        public farm_products()
        {
            this.farmer_product = new HashSet<farmer_product>();
        }

        //below are the gets and sets for farmer_product table
        public int ProductID { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public Nullable<decimal> Price { get; set; }
        public Nullable<System.DateTime> DateIn { get; set; } // date in specifies when the products came into the shop
        public Nullable<System.DateTime> DateOut { get; set; }//date out specifies when the products went out of the shop
    
        public virtual ICollection<farmer_product> farmer_product { get; set; }
    }
}
//--------------------------------------End of File -----------------------------------//
