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
    [Alias("PropertySet")]
    public class NewPropertySetCmdlet : NewMemberCmdlet
    {
        /// <summary> 
        /// <para type="description">
        /// Set true if the member is supposed to be hidden
        /// </para>
        /// </summary>
        [Parameter()]
        public SwitchParameter IsHidden { get; set; }

        /// <summary>
        /// <para type="description">
        /// Defines the properties that this property set references
        /// </para>
        /// </summary>
        [Parameter(Mandatory = true, Position = 1)]
        public string[] ReferencedProperties
        {
            get; set;
        }

        /// <exclude/>
        protected override void ProcessRecord()
        {
            WriteObject(new PropertySet(Name, ReferencedProperties) { IsHidden = IsHidden });
        }
    }
}