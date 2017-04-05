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
    /// <para type="description">Type converters can be used as a parameter value in the New-Type cmdlet.</para>
    /// </summary>
    [Cmdlet(VerbsCommon.New, "TypeConverter")]
    [OutputType(typeof(TypeConverter))]
    public class NewTypeConverterCmdlet : Cmdlet
    {
        [Parameter(Mandatory = true, Position = 0)]
        public string TypeName
        {
            get; set;
        }

        protected override void ProcessRecord()
        {
            WriteObject(new TypeConverter(TypeName));
        }
    }
}