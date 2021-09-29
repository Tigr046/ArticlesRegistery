using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace ArticleWCF.Models.WCFModels
{
    [DataContract]
    public class ArticleTransfer
    {
        [DataMember]
        public string Title { get; set; }

        [DataMember]
        public string Text{get;set;}

        [DataMember]
        public string AuthorFirstName { get; set; }

        [DataMember]
        public string AuthorSecondName { get; set; }
    }
}