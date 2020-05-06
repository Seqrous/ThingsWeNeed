using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ThingsWeNeed.Shared
{
    [DataContract(IsReference = true)]
    public class LinkDto
    {
        [DataMember]
        public string Href { get; private set; }

        [DataMember]
        public string Rel { get; private set; }

        [DataMember]
        public string Method { get; private set; }

        public LinkDto(string href, string rel, string method)
        {
            this.Href = href;
            this.Rel = rel;
            this.Method = method;
        }

        public LinkDto() { }
    }
}
