using System;
using System.Collections.Generic;

namespace WEBAPICORETESTNEW.Models
{
    public partial class BookTest
    {
        public int BookId { get; set; }
        public string BookName { get; set; }
        public string Genre { get; set; }
        public string AuthorName { get; set; }
        public string PublisherName { get; set; }
   //     public int? BoookCost { get; set; }
        public string Edition { get; set; }
    }
}
