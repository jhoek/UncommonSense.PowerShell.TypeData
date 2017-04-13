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

        public virtual XNode ToXml() => new XElement(ElementName, new XElement("Name", Name), GetContentElements(), GetAttributes());

        public virtual string ElementName => GetType().Name;

        public virtual IEnumerable<XAttribute> GetAttributes()
        {
            yield break;
        }

        public virtual IEnumerable<XNode> GetContentElements()
        {
            yield break;
        }

        public string Name
        {
            get; protected set;
        }
    }
}

#pragma warning restore 1591