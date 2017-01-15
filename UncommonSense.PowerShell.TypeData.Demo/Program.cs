using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UncommonSense.PowerShell.TypeData.Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            var aliasProperty = new AliasProperty("Count", "Length");

            var type = new Type("Foo");
            type.Members.Add(aliasProperty);

            var typeData = new TypeData();
            typeData.Add(type);

            Console.WriteLine(typeData.ToXml());
        }
    }
}
