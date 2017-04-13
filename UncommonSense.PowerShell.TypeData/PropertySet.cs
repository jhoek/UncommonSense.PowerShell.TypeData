#pragma warning disable 1591

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace UncommonSense.PowerShell.TypeData
{
    public class PropertySet : Member
    {
        public const string DefaultDisplayPropertySet = "DefaultDisplayPropertySet";
        public const string DefaultKeyPropertySet = "DefaultKeyPropertySet";

        public PropertySet(string name, params string[] referencedProperties) : base(name)
        {
            ReferencedProperties = referencedProperties;
        }

        public bool? IsHidden { get; set; }

        public string[] ReferencedProperties
        {
            get; protected set;
        }

        public override IEnumerable<XAttribute> GetAttributes()
        {
            if (IsHidden.HasValue)
                yield return new XAttribute("IsHidden", IsHidden.Value ? "true" : "false");
        }

        public override IEnumerable<XNode> GetContentElements()
        {
            yield return new XElement("ReferencedProperties", ReferencedProperties.Select(p => new XElement("Name", p)));
        }
    }
}

#pragma warning restore 1591