using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using System.Threading.Tasks;

namespace UncommonSense.PowerShell.TypeData.Cmdlets
{
    /// <summary>
    /// <para type="synopsis">Creates a new alias property definition.</para>
    /// <para type="description">An alias property defines a new name for an existing property.</para>
    /// </summary>
    [Cmdlet(VerbsCommon.New, "AliasProperty")]
    [OutputType(typeof(AliasProperty))]
    [Alias("AliasProperty")]
    public class NewAliasPropertyCmdlet : NewMemberCmdlet
    {
        [Parameter()]
        public SwitchParameter IsHidden { get; set; }

        /// <summary>
        /// <para type="description">
        /// The name of the referenced property that this alias refers to.
        /// </para>
        /// </summary>
        [Parameter(Mandatory = true, Position = 1)]
        public string ReferencedMemberName { get; set; }

        /// <summary>
        /// <para type="description">
        /// The full name of the .NET Framework type of the referenced property value.
        /// </para>
        /// </summary>
        [Parameter()]
        public string TypeName { get; set; }

        /// <exclude/>
        protected override void ProcessRecord()
        {
            WriteObject(new AliasProperty(Name, ReferencedMemberName) { TypeName = TypeName, IsHidden = IsHidden });
        }
    }
}