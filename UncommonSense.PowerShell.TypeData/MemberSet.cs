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

        public override IEnumerable<XNode> GetContentElements()
        {
            yield return Members.ToXml();
        }

        public Members Members
        {
            get; protected set;
        }
    }
}
