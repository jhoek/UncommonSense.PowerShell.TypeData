using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using System.Threading.Tasks;

namespace UncommonSense.PowerShell.TypeData.Cmdlets
{
    [Cmdlet(VerbsCommon.New, "CodeMethod")]
    [OutputType(typeof(CodeMethod))]
    public class NewCodeMethodCmdlet : NewMemberCmdlet
    {
        [Parameter(Mandatory = true, Position =1)]
        public CodeReference CodeReference
        {
            get; set;
        }

        protected override void ProcessRecord()
        {
            WriteObject(new CodeMethod(Name, CodeReference));
        }
    }
}
