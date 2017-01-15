using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace UncommonSense.PowerShell.TypeData
{
    public class CodeReference
    {
        public CodeReference(string typeName, string methodName)
        {
            TypeName = typeName;
            MethodName = methodName;
        }

        public XNode ToXml(string elementName) => new XElement(elementName, new XElement("TypeName", TypeName), new XElement("MethodName", MethodName));

        public string TypeName
        {
            get; set;
        }

        public string MethodName
        {
            get; set;
        }
    }
}
