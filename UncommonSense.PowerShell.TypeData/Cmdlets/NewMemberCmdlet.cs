using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using System.Threading.Tasks;

namespace UncommonSense.PowerShell.TypeData.Cmdlets
{
    /// <exclude/>
    public abstract class NewMemberCmdlet : Cmdlet
    {
        /// <summary>
        /// <para type="description">Name of this member</para>
        /// </summary>
        /// <returns></returns>
        [Parameter(Mandatory = true, Position =0)]
        public string Name
        {
            get; set;
        }
    }
}
