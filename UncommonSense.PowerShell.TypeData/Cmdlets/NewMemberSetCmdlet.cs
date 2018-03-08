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
    [Alias("MemberSet")]
    public class NewMemberSetCmdlet : NewMemberCmdlet
    {
        /// <summary>
        /// <para type="description">
        /// Inheriting members tells this MemberSet to walk the TypeNames during a lookup of members. This
        /// means that any members of a parent type that are in a MemberSet of the same name will be
        /// available through this MemberSet. Setting this switch turns off this behaviour.
        /// </para>
        /// </summary>
        [Parameter()]
        public SwitchParameter DoNotInheritMembers
        {
            get; set;
        }

        /// <summary> 
        /// <para type="description">
        /// Set true if the member is supposed to be hidden
        /// </para>
        /// </summary>
        [Parameter()]
        public SwitchParameter IsHidden { get; set; }

        /// <summary>
        /// <para type="description">
        /// Defines the members for this memberset
        /// </para>
        /// </summary>
        [Parameter(Position = 1)]
        public ScriptBlock Members
        {
            get; set;
        }

        /// <exclude/>
        protected override void ProcessRecord()
        {
            var memberSet = new MemberSet(Name) { IsHidden = IsHidden };
            memberSet.DoNotInheritMembers = DoNotInheritMembers;

            Members?
                .Invoke()
                .Select(o => o.BaseObject)
                .Cast<Member>()
                .ForEach(m => memberSet.Members.Add(m));

            WriteObject(memberSet);
        }
    }
}