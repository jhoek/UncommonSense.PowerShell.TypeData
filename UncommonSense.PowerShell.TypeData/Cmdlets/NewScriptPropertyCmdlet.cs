using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using System.Threading.Tasks;

namespace UncommonSense.PowerShell.TypeData.Cmdlets
{
    [Cmdlet(VerbsCommon.New, "ScriptProperty")]
    [OutputType(typeof(ScriptProperty))]
    public class NewScriptPropertyCmdlet : NewMemberCmdlet
    {
        [Parameter(Mandatory = true, Position = 1)]
        public string GetScriptBlock
        {
            get; set;
        }

        [Parameter(Position = 2)]
        public string SetScriptBlock
        {
            get; set;
        }

        protected override void ProcessRecord()
        {
            WriteObject(new ScriptProperty(Name, GetScriptBlock, SetScriptBlock));
        }
    }
}
