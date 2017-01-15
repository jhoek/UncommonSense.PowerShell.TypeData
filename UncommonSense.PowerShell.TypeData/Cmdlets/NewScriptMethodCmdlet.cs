using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using System.Threading.Tasks;

namespace UncommonSense.PowerShell.TypeData.Cmdlets
{
    [Cmdlet(VerbsCommon.New, "ScriptMethod")]
    [OutputType(typeof(ScriptMethod))]
    public class NewScriptMethodCmdlet : NewMemberCmdlet
    {
        [Parameter(Mandatory = true, Position=1)]
        public string Script
        {
            get; set;
        }

        protected override void ProcessRecord()
        {
            WriteObject(new ScriptMethod(Name, Script));
        }
    }
}
