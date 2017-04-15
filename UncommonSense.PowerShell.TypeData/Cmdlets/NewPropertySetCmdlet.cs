using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using System.Threading.Tasks;

namespace UncommonSense.PowerShell.TypeData.Cmdlets
{
    /// <summary>
    /// <para type="synopsis">Creates a new property set definition.</para>
    /// <para type="description">A property set defines a group of extended properties that can be referenced by the name of the set.</para>
    /// </summary>
    [Cmdlet(VerbsCommon.New, "PropertySet")]
    [OutputType(typeof(PropertySet))]
    public class NewPropertySetCmdlet : NewMemberCmdlet
    {
        [Parameter()]
        public SwitchParameter IsHidden { get; set; }

        [Parameter(Mandatory = true, Position = 1)]
        public string[] ReferencedProperties
        {
            get; set;
        }

        protected override void ProcessRecord()
        {
            WriteObject(new PropertySet(Name, ReferencedProperties) { IsHidden = IsHidden });
        }
    }
}