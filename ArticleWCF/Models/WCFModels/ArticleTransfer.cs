using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace ArticleWCF.Models.WCFModels
{
    [DataContract]
    public class ArticleTransfer
    {
        [DataMember]
        [Required]
        public string Title { get; set; }

        [DataMember]
        [Required]
        public string Text{get;set;}

        [DataMember]
        [StringLength(64)]
        [Required]
        public string AuthorEmail { get; set; }
    }
}