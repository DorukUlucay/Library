using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LibraryUI
{
    public class BookRequestViewModel
    {
        public int? RequestId;
        public int? BookId;
        public int? UserId;
        public DateTime? Since;
        public DateTime? Until;
        public string Title;
        public string AuthorName;
        public string Name;
        public string Surname;
        public DateTime? RequestedOn;
    }
}