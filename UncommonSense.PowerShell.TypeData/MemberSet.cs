#pragma warning disable 1591

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace UncommonSense.PowerShell.TypeData
{
    public class MemberSet : Member
    {
        public const string StandardMembers = "PSStandardMembers";

        public MemberSet(string name, params Member[] members) : base(name)
        {
            Members = new Members(members);
        }

        public bool DoNotInheritMembers { get; set; }
        public bool IsHidden { get; set; }

        public Members Members
        {
            get; protected set;
        }

        public override IEnumerable<XAttribute> GetAttributes()
        {
            if (IsHidden)
                yield return new XAttribute("IsHidden", "true");
        }

        public override IEnumerable<XNode> GetContentElements()
        {
            if (DoNotInheritMembers)
                yield return new XElement("InheritMembers", "false");

            yield return Members.ToXml();
        }
    }
}

#pragma warning restore 1591