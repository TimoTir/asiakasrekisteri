//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace asiakasrekisteri.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Asiakastapahtumat
    {
        public int TapahtumaID { get; set; }
        public string Tapahtumanimi { get; set; }
        public string Kuvaus { get; set; }
        public Nullable<int> Asiakasnumero { get; set; }
        public Nullable<System.DateTime> Päivämäärä { get; set; }
    
        public virtual Asiakastiedot Asiakastiedot { get; set; }
    }
}
