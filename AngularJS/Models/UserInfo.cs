//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AngularJS.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class UserInfo
    {
        public int UserId { get; set; }
        public string Phone { get; set; }
        public int DistrictId { get; set; }
        public string UserName { get; set; }
    
        public virtual District District { get; set; }
    }
}
