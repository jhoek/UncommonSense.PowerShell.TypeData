#pragma warning disable 1591

using System.Collections.Generic;
using System.Xml.Linq;

namespace UncommonSense.PowerShell.TypeData
{
    public class AliasProperty : Member
    {
        public AliasProperty(string name, string referencedMemberName) : base(name)
        {
            ReferencedMemberName = referencedMemberName;
        }

        public bool IsHidden
        {
            get; set;
        }

        public string ReferencedMemberName
        {
            get; protected set;
        }

        public string TypeName
        {
            get; set;
        }

        public override IEnumerable<XAttribute> GetAttributes()
        {
            if (IsHidden)
                yield return new XAttribute("IsHidden", "true");
        }

        public override IEnumerable<XNode> GetContentElements()
        {
            yield return new XElement("ReferencedMemberName", ReferencedMemberName);

            if (!string.IsNullOrEmpty(TypeName))
                yield return new XElement("TypeName", TypeName);
        }
    }
}

#pragma warning restore 1591