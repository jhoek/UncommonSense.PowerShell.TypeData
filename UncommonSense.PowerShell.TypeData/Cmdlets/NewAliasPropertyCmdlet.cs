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
    public class NewAliasPropertyCmdlet : NewMemberCmdlet
    {
        [Parameter(Mandatory = true, Position = 1)]
        public string ReferencedMemberName
        {
            get; set;
        }

        [Parameter()]
        public string TypeName
        {
            get; set;
        }

        protected override void ProcessRecord()
        {
            WriteObject(new AliasProperty(Name, ReferencedMemberName) { TypeName = TypeName });
        }
    }
}