using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using System.Threading.Tasks;

namespace UncommonSense.PowerShell.TypeData.Cmdlets
{
    /// <summary>
    /// <para type="synopsis">Creates a new type converter.</para>
    /// <para type="description">
    /// Type converters can be used as a parameter value in the New-Type cmdlet.
    /// </para>
    /// </summary>
    [Cmdlet(VerbsCommon.New, "TypeConverter")]
    [OutputType(typeof(TypeConverter))]
    [Alias("TypeConverter")]
    public class NewTypeConverterCmdlet : Cmdlet
    {
        /// <summary>
        /// <para type="description">The type name for this type converter.</para>
        /// </summary>
        [Parameter(Mandatory = true, Position = 0)]
        public string TypeName
        {
            get; set;
        }

#pragma warning disable 1591

        protected override void ProcessRecord()
        {
            WriteObject(new TypeConverter(TypeName));
        }

#pragma warning restore 1591
    }
}