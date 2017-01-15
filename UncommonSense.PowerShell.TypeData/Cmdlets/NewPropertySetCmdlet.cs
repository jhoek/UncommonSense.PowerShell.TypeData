using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using System.Threading.Tasks;

namespace UncommonSense.PowerShell.TypeData.Cmdlets
{
    [Cmdlet(VerbsCommon.New, "PropertySet")]
    [OutputType(typeof(PropertySet))]
    public class NewPropertySetCmdlet : NewMemberCmdlet
    {
        [Parameter(Mandatory = true, Position = 1)]
        public string[] ReferencedProperties
        {
            get; set;
        }

        protected override void ProcessRecord()
        {
            WriteObject(new PropertySet(Name, ReferencedProperties));
        }
    }
}