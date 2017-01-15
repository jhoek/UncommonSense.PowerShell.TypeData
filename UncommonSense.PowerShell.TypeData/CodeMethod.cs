using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace UncommonSense.PowerShell.TypeData
{
    public class CodeMethod : Member
    {
        public CodeMethod(string name, CodeReference codeReference) : base(name)
        {
            CodeReference = codeReference;
        }

        public override IEnumerable<XNode> GetContentElements()
        {
            yield return CodeReference.ToXml("CodeReference");
        }

        //public override XNode ToXml() => new XElement("CodeMethod", new XElement("Name", Name), CodeReference.ToXml("CodeReference"));

        public CodeReference CodeReference
        {
            get; protected set;
        }
    }
}
