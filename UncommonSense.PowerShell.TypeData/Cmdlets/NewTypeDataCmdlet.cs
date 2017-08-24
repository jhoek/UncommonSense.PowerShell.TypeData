using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using System.Threading.Tasks;

namespace UncommonSense.PowerShell.TypeData.Cmdlets
{
    /// <summary>
    /// <para type="synopsis">Creates a new type file structure.</para>
    /// <para type="description">
    /// Types files are XML-based files that let you add PowerShell properties and methods to
    /// existing .NET objects.
    /// </para>
    /// </summary>
    [Cmdlet(VerbsCommon.New, "TypeData")]
    [OutputType(typeof(string))]
    [Alias("Types")]
    public class NewTypeDataCmdlet : Cmdlet
    {
        /// <summary>
        /// <para type="description">
        /// Text to be emitted before the actual type data, such as an XML declaration specifying the
        /// encoding. When specifying an encoding in -PreContent, make sure you use the same encoding
        /// when sending the cmdlet's output to a file or stream.
        /// </para>
        /// </summary>
        [Parameter()]
        public string PreContent
        {
            get; set;
        }

        /// <summary>
        /// <para type="description">A script block whose contents evaluate to Type objects.</para>
        /// </summary>
        [Parameter(Position = 0)]
        public ScriptBlock Types
        {
            get; set;
        }

#pragma warning disable 1591

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

#pragma warning restore 1591
    }
}