using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using System.Threading.Tasks;

namespace UncommonSense.PowerShell.TypeData.Cmdlets
{
    [Cmdlet(VerbsCommon.New, "CodeReference")]
    [OutputType(typeof(CodeReference))]
    public class NewCodeReferenceCmdlet : Cmdlet
    {
        [Parameter(Mandatory = true, Position=0)]
        public string TypeName
        {
            get; set;
        }

        [Parameter(Mandatory = true,Position =1)]
        public string MethodName
        {
            get; set;
        }

        protected override void ProcessRecord()
        {
            WriteObject(new CodeReference(TypeName, MethodName));
        }
    }
}
