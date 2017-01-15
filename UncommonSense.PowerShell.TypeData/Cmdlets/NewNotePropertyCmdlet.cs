using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using System.Threading.Tasks;

namespace UncommonSense.PowerShell.TypeData.Cmdlets
{
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
