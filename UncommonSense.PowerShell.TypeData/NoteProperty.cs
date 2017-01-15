﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace UncommonSense.PowerShell.TypeData
{
    public class NoteProperty : Member
    {
        public NoteProperty(string name, string value) : base(name)
        {
            Value = value;
        }

        public override IEnumerable<XNode> GetContentElements()
        {
            yield return new XElement("Value", Value);
        }

        public string Value
        {
            get; protected set;
        }
    }
}