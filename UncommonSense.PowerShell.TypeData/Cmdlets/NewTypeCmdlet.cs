using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using System.Threading.Tasks;

namespace UncommonSense.PowerShell.TypeData.Cmdlets
{
    [Cmdlet(VerbsCommon.New, "Type")]
    [OutputType(typeof(Type))]
    public class NewTypeCmdlet : Cmdlet
    {
        [Parameter(Mandatory = true, Position = 0)]
        public string Name
        {
            get; set;
        }

        [Parameter(Position = 1)]
        public ScriptBlock Members
        {
            get; set;
        }

        protected override void ProcessRecord()
        {
            var @type = new Type(Name);

            Members?
                .Invoke()
                .Select(o => o.BaseObject)
                .Cast<Member>()
                .ForEach(m => @type.Members.Add(m));

            WriteObject(@type);
        }
    }
}
