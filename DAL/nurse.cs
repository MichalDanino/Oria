//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DAL
{
    using System;
    using System.Collections.Generic;
    
    public partial class nurse
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public nurse()
        {
            this.shiftt = new HashSet<shiftt>();
        }
    
        public string IDnurse { get; set; }
        public string NAMEnurse { get; set; }
        public string ADRESSnurse { get; set; }
        public Nullable<int> CITYnurse { get; set; }
        public Nullable<double> HOURsalaryNURSE { get; set; }
    
        public virtual city city { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<shiftt> shiftt { get; set; }
    }
}
