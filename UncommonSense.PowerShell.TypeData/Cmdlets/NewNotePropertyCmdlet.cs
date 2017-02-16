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
    public class NewNotePropertyCmdlet : NewMemberCmdlet
    {
        [Parameter(Mandatory = true, Position = 1)]
        public string Value
        {
            get; set;
        }

        protected override void ProcessRecord()
        {
            WriteObject(new NoteProperty(Name, Value));
        }
    }
}
