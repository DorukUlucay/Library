//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace LibraryUI.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class BookRequest
    {
        public int BookRequestId { get; set; }
        public Nullable<int> BookId { get; set; }
        public Nullable<int> UserId { get; set; }
        public Nullable<System.DateTime> Since { get; set; }
        public Nullable<System.DateTime> Until { get; set; }
        public Nullable<System.DateTime> TakenOn { get; set; }
        public Nullable<System.DateTime> ReturnedOn { get; set; }
        public Nullable<System.DateTime> RequestedOn { get; set; }
        public Nullable<System.DateTime> ApprovedOn { get; set; }
        public Nullable<int> ApprovedBy { get; set; }
        public Nullable<System.DateTime> RejectedOn { get; set; }
        public Nullable<int> RejectedBy { get; set; }
    }
}
