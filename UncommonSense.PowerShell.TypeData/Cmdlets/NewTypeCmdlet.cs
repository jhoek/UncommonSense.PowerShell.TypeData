using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using System.Threading.Tasks;

namespace UncommonSense.PowerShell.TypeData.Cmdlets
{
    /// <summary>
    /// <para type="synopsis">
    /// Adds a type to a type file structure, as a container for subsequent member definitions.
    /// </para>
    /// </summary>
    [Cmdlet(VerbsCommon.New, "Type")]
    [OutputType(typeof(Type))]
    [Alias("_Type")]
    public class NewTypeCmdlet : Cmdlet
    {
        /// <summary>
        /// <para type="description">A script block that evaluates to the members of this type.</para>
        /// </summary>
        [Parameter(Position = 1)]
        public ScriptBlock Members
        {
            get; set;
        }

        /// <summary>
        /// <para type="description">Name for this type.</para>
        /// </summary>
        [Parameter(Mandatory = true, Position = 0)]
        public string Name
        {
            get; set;
        }

        /// <summary>
        /// <para type="description">
        /// Optional type converter for this type. Pass in either a string containing the type
        /// converter type name, or a TypeConverter instance.
        /// </para>
        /// </summary>
        [Parameter()]
        public PSObject TypeConverter
        {
            get; set;
        }

#pragma warning disable 1591

        protected TypeConverter BuildTypeConverter(PSObject typeConverter)
        {
            if (typeConverter == null)
                return null;

            if (typeConverter.BaseObject is TypeConverter)
                return typeConverter.BaseObject as TypeConverter;

            if (typeConverter.BaseObject is string)
                return new TypeConverter(typeConverter.BaseObject as string);

            throw new ArgumentOutOfRangeException("TypeConverter");
        }

        protected override void ProcessRecord()
        {
            var @type = new Type(Name);

            @type.TypeConverter = BuildTypeConverter(TypeConverter);

            Members?
                .Invoke()
                .Select(o => o.BaseObject)
                .Cast<Member>()
                .ForEach(m => @type.Members.Add(m));

            WriteObject(@type);
        }

#pragma warning restore 1591
    }
}