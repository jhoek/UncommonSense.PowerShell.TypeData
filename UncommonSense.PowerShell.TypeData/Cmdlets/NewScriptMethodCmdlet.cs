using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using System.Threading.Tasks;

namespace UncommonSense.PowerShell.TypeData.Cmdlets
{
    /// <summary>
    /// <para type="synopsis">Creates a new script method definition.</para>
    /// <para type="description">A script method defines a method whose value is the output of a script.</para>
    /// </summary>
    [Cmdlet(VerbsCommon.New, "ScriptMethod")]
    [OutputType(typeof(ScriptMethod))]
    [Alias("ScriptMethod")]
    public class NewScriptMethodCmdlet : NewMemberCmdlet
    {
        [Parameter(Mandatory = true, Position = 1)]
        public string Script
        {
            get; set;
        }

        /// <exclude/>
        protected override void ProcessRecord()
        {
            WriteObject(new ScriptMethod(Name, Script));
        }
    }
}