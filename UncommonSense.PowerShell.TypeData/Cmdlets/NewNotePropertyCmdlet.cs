using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using System.Threading.Tasks;

namespace UncommonSense.PowerShell.TypeData.Cmdlets
{
    /// <summary>
    /// <para type="synopsis">Creates a new note property definition.</para>
    /// <para type="description">A note property defines a property that has a static value.</para>
    /// </summary>
    [Cmdlet(VerbsCommon.New, "NoteProperty")]
    [OutputType(typeof(NoteProperty))]
    [Alias("NoteProperty")]
    public class NewNotePropertyCmdlet : NewMemberCmdlet
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
        /// The full name of the .NET Framework type of the referenced property value.
        /// </para>
        /// </summary>
        [Parameter()]
        public string TypeName { get; set; }

        /// <summary>
        /// <para type="description">
        /// The (static) value for this note property
        /// </para>
        /// </summary>
        [Parameter(Mandatory = true, Position = 1)]
        public string Value { get; set; }

        /// <exclude/>
        protected override void ProcessRecord()
        {
            WriteObject(new NoteProperty(Name, Value) { TypeName = TypeName, IsHidden = IsHidden });
        }
    }
}