using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SonOfCod.Models
{
    [Table("MarketingPageContents")]
    public class MarketingPageContent
    {
        [Key]
        public int ContentId { get; set; }
        public string Title { get; set; }
        public string Tagline { get; set; }
        public string Introduction { get; set; }
        public string ImageLink { get; set; }
    }
}
