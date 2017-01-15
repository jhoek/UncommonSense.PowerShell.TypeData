using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using System.Threading.Tasks;

namespace UncommonSense.PowerShell.TypeData.Cmdlets
{
    [Cmdlet(VerbsCommon.New, "AliasProperty")]
    [OutputType(typeof(AliasProperty))]
    public class NewAliasPropertyCmdlet : NewMemberCmdlet
    {
        [Parameter(Mandatory = true, Position = 1)]
        public string ReferencedMemberName
        {
            get; set;
        }

        protected override void ProcessRecord()
        {
            WriteObject(new AliasProperty(Name, ReferencedMemberName));
        }
    }
}
