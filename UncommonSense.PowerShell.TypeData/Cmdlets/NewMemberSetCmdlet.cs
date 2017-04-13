using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using System.Threading.Tasks;

namespace UncommonSense.PowerShell.TypeData.Cmdlets
{
    /// <summary>
    /// <para type="synopsis">Creates a new member set definition.</para>
    /// <para type="description">The PSStandardMembers member set is used by Windows PowerShell to define the default property sets for an object.</para>
    /// </summary>
    [Cmdlet(VerbsCommon.New, "MemberSet")]
    [OutputType(typeof(MemberSet))]
    public class NewMemberSetCmdlet : NewMemberCmdlet
    {
        [Parameter()]
        public bool? InheritMembers
        {
            get; set;
        }

        [Parameter()]
        public bool? IsHidden { get; set; }

        [Parameter(Position = 1)]
        public ScriptBlock Members
        {
            get; set;
        }

        protected override void ProcessRecord()
        {
            var memberSet = new MemberSet(Name) { IsHidden = IsHidden };
            memberSet.InheritMembers = InheritMembers;

            Members?
                .Invoke()
                .Select(o => o.BaseObject)
                .Cast<Member>()
                .ForEach(m => memberSet.Members.Add(m));

            WriteObject(memberSet);
        }
    }
}