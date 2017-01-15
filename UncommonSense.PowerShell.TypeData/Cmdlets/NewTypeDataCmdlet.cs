using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using System.Threading.Tasks;

namespace UncommonSense.PowerShell.TypeData.Cmdlets
{
    [Cmdlet(VerbsCommon.New, "TypeData")]
    [OutputType(typeof(TypeData))]
    public class NewTypeDataCmdlet : Cmdlet
    {
        [Parameter(Position = 0)]
        public ScriptBlock Types
        {
            get; set;
        }

        protected override void ProcessRecord()
        {
            var typeData = new TypeData();

            Types?
                .Invoke()
                .Select(o => o.BaseObject)
                .Cast<Type>()
                .ForEach(o => typeData.Add(o));

            WriteObject(typeData);
        }
    }
}
