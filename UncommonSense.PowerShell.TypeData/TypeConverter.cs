using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace UncommonSense.PowerShell.TypeData
{
    public class TypeConverter
    {
        public TypeConverter(string typeName)
        {
            TypeName = typeName;
        }

        public string TypeName
        {
            get; set;
        }

        public XNode ToXml() => new XElement("TypeConverter", new XElement("TypeName", TypeName));
    }
}