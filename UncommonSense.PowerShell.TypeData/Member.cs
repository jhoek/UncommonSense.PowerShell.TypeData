using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace UncommonSense.PowerShell.TypeData
{
    public abstract class Member
    {
        public Member(string name)
        {
            Name = name;
        }

        public override string ToString() => Name;

        public virtual XNode ToXml() => new XElement(GetType().Name, new XElement("Name", Name), GetContentElements());

        public abstract IEnumerable<XNode> GetContentElements();

        public string Name
        {
            get; protected set;
        }
    }
}
