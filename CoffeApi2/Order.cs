//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CoffeApi2
{
    using System;
    using System.Collections.Generic;
    
    public partial class Order
    {
        public int Id { get; set; }
        public Nullable<int> DrinkId { get; set; }
        public Nullable<int> LandscapeId { get; set; }
        public Nullable<bool> Played { get; set; }
        public Nullable<int> Milk { get; set; }
        public Nullable<int> Strength { get; set; }
        public Nullable<int> Sugar { get; set; }
    
        public virtual Drink Drink { get; set; }
        public virtual Landscape Landscape { get; set; }
    }
}
