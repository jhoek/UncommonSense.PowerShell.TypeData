﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using System.Threading.Tasks;

namespace UncommonSense.PowerShell.TypeData.Cmdlets
{
    [Cmdlet(VerbsCommon.New, "MemberSet")]
    [OutputType(typeof(MemberSet))]
    public class NewMemberSetCmdlet : NewMemberCmdlet
    {
        [Parameter(Position =1)]
        public ScriptBlock Members
        {
            get; set;
        }

        protected override void ProcessRecord()
        {
            var memberSet = new MemberSet(Name);

            Members?
                .Invoke()
                .Select(o => o.BaseObject)
                .Cast<Member>()
                .ForEach(m => memberSet.Members.Add(m));

            WriteObject(memberSet);                   
        }
    }
}