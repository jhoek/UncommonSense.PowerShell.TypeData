#pragma warning disable 1591

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace UncommonSense.PowerShell.TypeData
{
    public class Members : Collection<Member>
    {
        public Members()
        {
        }

        public XNode ToXml() => new XElement("Members", this.Select(m => m.ToXml()));

        public Members(IEnumerable<Member> values)
        {
            values.ForEach(v => Add(v));
        }
    }
}

#pragma warning restore 1591