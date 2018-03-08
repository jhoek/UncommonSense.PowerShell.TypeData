using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using System.Threading.Tasks;

namespace UncommonSense.PowerShell.TypeData.Cmdlets
{
    /// <summary>
    /// <para type="synopsis">Creates a new code method definition.</para>
    /// <para type="description">A code method references a static method of a .NET Framework object.</para>
    /// </summary>
    [Cmdlet(VerbsCommon.New, "CodeMethod")]
    [OutputType(typeof(CodeMethod))]
    [Alias("CodeMethod")]
    public class NewCodeMethodCmdlet : NewMemberCmdlet
    {
        /// <summary>
        /// <para type="description">
        /// The code reference for this code method. Code references instances can be created using
        /// the New-CodeReference cmdlet.
        /// </para>
        /// </summary>
        [Parameter(Mandatory = true, Position = 1)]
        public CodeReference CodeReference
        {
            get; set;
        }

        /// <exclude/>
        protected override void ProcessRecord()
        {
            WriteObject(new CodeMethod(Name, CodeReference));
        }
    }
}