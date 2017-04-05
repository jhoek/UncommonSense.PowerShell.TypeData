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

        public Members Members
        {
            get; protected set;
        }

        public string Name
        {
            get; protected set;
        }

        public TypeConverter TypeConverter
        {
            get; set;
        }

        public override string ToString() => Name;

        public XNode ToXml() => new XElement("Type", new XElement("Name", Name), GetContentElements());

        protected IEnumerable<XNode> GetContentElements()
        {
            yield return Members.ToXml();

            if (TypeConverter != null)
                yield return TypeConverter.ToXml();
        }
    }
}