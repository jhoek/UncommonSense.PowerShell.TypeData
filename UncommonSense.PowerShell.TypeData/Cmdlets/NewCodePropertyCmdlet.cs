using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using System.Threading.Tasks;

namespace UncommonSense.PowerShell.TypeData.Cmdlets
{
    /// <summary>
    /// <para type="synopsis">Creates a new code property definition.</para>
    /// <para type="description">
    /// A code property references a static property of a .NET Framework object.
    /// </para>
    /// </summary>
    [Cmdlet(VerbsCommon.New, "CodeProperty")]
    [OutputType(typeof(CodeProperty))]
    public class NewCodePropertyCmdlet : NewMemberCmdlet
    {
        /// <summary>
        /// <para type="description">
        /// The code reference for this accessor. Code references instances can be created using the
        /// New-CodeReference cmdlet.
        /// </para>
        /// </summary>
        [Parameter(Mandatory = true, Position = 1)]
        public CodeReference GetCodeReference
        {
            get; set;
        }

        /// <summary>
        /// <para type="description">
        /// The code reference for this accessor. Code references instances can be created using the
        /// New-CodeReference cmdlet.
        /// </para>
        /// </summary>
        [Parameter(Position = 2)]
        public CodeReference SetCodeReference
        {
            get; set;
        }

#pragma warning disable 1591

        protected override void ProcessRecord()
        {
            WriteObject(new CodeProperty(Name, GetCodeReference, SetCodeReference));
        }

#pragma warning restore 1591
    }
}