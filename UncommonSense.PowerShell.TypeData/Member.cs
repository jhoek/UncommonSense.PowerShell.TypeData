#pragma warning disable 1591

using System.Collections.Generic;
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

#pragma warning restore 1591