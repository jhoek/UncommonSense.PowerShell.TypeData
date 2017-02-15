using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using System.Threading.Tasks;

namespace UncommonSense.PowerShell.TypeData.Cmdlets
{
    [Cmdlet(VerbsCommon.New, "TypeData")]
    [OutputType(typeof(string))]
    public class NewTypeDataCmdlet : Cmdlet
    {
        [Parameter(Position = 0)]
        public ScriptBlock Types
        {
            get; set;
        }

        [Parameter()]
        public string PreContent
        {
            get; set;
        }

        protected override void ProcessRecord()
        {
            var typeData = new Types();

            Types?
                .Invoke()
                .Select(o => o.BaseObject)
                .Cast<Type>()
                .ForEach(o => typeData.Add(o));

            WriteObject(
                new[] { PreContent, typeData.ToXml().ToString() }
                    .Where(s => s != null)
                    .Join(Environment.NewLine)
                );
        }
    }
}
