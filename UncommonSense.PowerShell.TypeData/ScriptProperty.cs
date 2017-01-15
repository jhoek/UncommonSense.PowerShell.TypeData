using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace UncommonSense.PowerShell.TypeData
{
    public class ScriptProperty : Member
    {
        public ScriptProperty(string name, string getScriptBlock, string setScriptBlock) : base(name)
        {
            GetScriptBlock = getScriptBlock;
            SetScriptBlock = setScriptBlock;
        }

        public override IEnumerable<XNode> GetContentElements()
        {
            if (!string.IsNullOrEmpty(GetScriptBlock))
            {
                yield return new XElement("GetScriptBlock", GetScriptBlock);
            }

            if (!string.IsNullOrEmpty(SetScriptBlock))
            {
                yield return new XElement("SetScriptBlock", SetScriptBlock);
            }
        }

        public string GetScriptBlock
        {
            get; set;
        }

        public string SetScriptBlock
        {
            get; set;
        }
    }
}
