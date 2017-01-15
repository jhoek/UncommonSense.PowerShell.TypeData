using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace UncommonSense.PowerShell.TypeData
{
    public class AliasProperty : Member
    {
        public AliasProperty(string name, string referencedMemberName) : base(name)
        {
            ReferencedMemberName = referencedMemberName;
        }

        public override IEnumerable<XNode> GetContentElements()
        {
            yield return new XElement("ReferencedMemberName", ReferencedMemberName);
        }

        public string ReferencedMemberName
        {
            get; protected set;
        }
    }
}
