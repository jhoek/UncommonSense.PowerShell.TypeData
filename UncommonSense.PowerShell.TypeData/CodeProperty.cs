#pragma warning disable 1591

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

        public CodeReference GetCodeReference
        {
            get; set;
        }

        public bool? IsHidden { get; set; }

        public CodeReference SetCodeReference
        {
            get; set;
        }

        public override IEnumerable<XAttribute> GetAttributes()
        {
            if (IsHidden.HasValue)
                yield return new XAttribute("IsHidden", IsHidden.Value ? "true" : "false");
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
    }
}

#pragma warning restore 1591