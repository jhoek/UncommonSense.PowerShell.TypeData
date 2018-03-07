using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using System.Threading.Tasks;

namespace UncommonSense.PowerShell.TypeData.Cmdlets
{
    /// <summary>
    /// <para type="synopsis">Creates a new code reference.</para>
    /// <para type="description">
    /// Code references can be used as parameter values in the New-CodeMethod and New-CodeProperty cmdlets.
    /// </para>
    /// </summary>
    [Cmdlet(VerbsCommon.New, "CodeReference")]
    [OutputType(typeof(CodeReference))]
    [Alias("CodeReference")]
    public class NewCodeReferenceCmdlet : Cmdlet
    {
        [Parameter(Mandatory = true, Position = 1)]
        public string MethodName
        {
            get; set;
        }

        [Parameter(Mandatory = true, Position = 0)]
        public string TypeName
        {
            get; set;
        }

        /// <exclude/>
        protected override void ProcessRecord()
        {
            WriteObject(new CodeReference(TypeName, MethodName));
        }
    }
}