using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace UncommonSense.PowerShell.TypeData
{
    public class CodeProperty : Member
    {
        public CodeProperty(string name, CodeReference getCodeReference, CodeReference setCodeReference) : base(name)
        {
            GetCodeReference = getCodeReference;
            SetCodeReference = setCodeReference;
        }

        public override IEnumerable<XNode> GetContentElements()
        {
            if (GetCodeReference != null)
            {
                yield return GetCodeReference.ToXml("GetCodeReference");
            }

            if (SetCodeReference != null)
            {
                yield return SetCodeReference.ToXml("SetCodeReference");
            }
        }

        //public override XNode ToXml() => new XElement("CodeProperty", new XElement("Name", Name), GetCodeReference?.ToXml("GetCodeReference"), SetCodeReference?.ToXml("SetCodeReference"));

        public CodeReference GetCodeReference
        {
            get; set;
        }

        public CodeReference SetCodeReference
        {
            get; set;
        }
    }
}
