﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using System.Threading.Tasks;

namespace UncommonSense.PowerShell.TypeData.Cmdlets
{
    /// <summary>
    /// <para type="synopsis">Creates a new script property definition.</para>
    /// <para type="description">
    /// A script property defines a property whose value is the output of a script.
    /// </para>
    /// </summary>
    [Cmdlet(VerbsCommon.New, "ScriptProperty")]
    [OutputType(typeof(ScriptProperty))]
    [Alias("ScriptProperty")]
    public class NewScriptPropertyCmdlet : NewMemberCmdlet
    {
        /// <summary>
        /// <para type="description">
        /// Defines the getter script block for this script property
        /// </para>
        /// </summary>
        [Parameter(Mandatory = true, Position = 1)]
        public string GetScriptBlock
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
        /// Defines the setter script block for this script property
        /// </para>
        /// </summary>
        [Parameter(Position = 2)]
        public string SetScriptBlock
        {
            get; set;
        }

        /// <exclude/>
        protected override void ProcessRecord()
        {
            WriteObject(new ScriptProperty(Name, GetScriptBlock, SetScriptBlock) { IsHidden = IsHidden });
        }
    }
}