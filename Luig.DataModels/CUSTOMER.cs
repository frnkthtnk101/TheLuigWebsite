//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Luig.DataModels
{
    using System;
    using System.Collections.Generic;
    
    public partial class CUSTOMER
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CUSTOMER()
        {
            this.INVOICEs = new HashSet<INVOICE>();
        }
    
        public int CUS_CODE { get; set; }
        public string CUS_LNAME { get; set; }
        public string CUS_FNAME { get; set; }
        public string CUS_INITIAL { get; set; }
        public string CUS_AREACODE { get; set; }
        public string CUS_PHONE { get; set; }
        public Nullable<decimal> CUS_BALANCE { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<INVOICE> INVOICEs { get; set; }
    }
}
