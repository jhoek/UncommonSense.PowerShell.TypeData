using System;
using System.Xml.Linq;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UncommonSense.PowerShell.TypeData
{
    public class Type
    {
        public Type(string name)
        {
            Name = name;
            Members = new Members();
        }

        public override string ToString() => Name;

        public XNode ToXml() => new XElement("Type", new XElement("Name", Name), Members.ToXml());

        public string Name
        {
            get; protected set;
        }

        public Members Members
        {
            get; protected set;
        }
    }
}