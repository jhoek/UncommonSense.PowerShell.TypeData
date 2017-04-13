using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using System.Threading.Tasks;

namespace UncommonSense.PowerShell.TypeData.Cmdlets
{
    /// <summary>
    /// <para type="synopsis">Creates a new script property definition.</para>
    /// <para type="description">
    /// A script property defines a property whose value is the output of a script.
    /// </para>
    /// </summary>
    [Cmdlet(VerbsCommon.New, "ScriptProperty")]
    [OutputType(typeof(ScriptProperty))]
    public class NewScriptPropertyCmdlet : NewMemberCmdlet
    {
        [Parameter(Mandatory = true, Position = 1)]
        public string GetScriptBlock
        {
            get; set;
        }

        [Parameter()]
        public bool? IsHidden { get; set; }

        [Parameter(Position = 2)]
        public string SetScriptBlock
        {
            get; set;
        }

        protected override void ProcessRecord()
        {
            WriteObject(new ScriptProperty(Name, GetScriptBlock, SetScriptBlock) { IsHidden = IsHidden });
        }
    }
}