#pragma warning disable 1591

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace UncommonSense.PowerShell.TypeData
{
    public class ScriptMethod : Member
    {
        public ScriptMethod(string name, string script) : base(name)
        {
            Script = script;
        }

        public override IEnumerable<XNode> GetContentElements()
        {
            yield return new XElement("Script", Script);
        }

        public string Script
        {
            get; protected set;
        }
    }
}

#pragma warning restore 1591