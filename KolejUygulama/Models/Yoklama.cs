//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace KolejUygulama.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Yoklama
    {
        public int Id { get; set; }
        public int DersPlanId { get; set; }
        public int OgrenciId { get; set; }
        public Nullable<bool> Katilim { get; set; }
    
        public virtual DersPlani DersPlani { get; set; }
        public virtual Ogrenciler Ogrenciler { get; set; }
    }
}
