﻿#pragma warning disable 1591

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace UncommonSense.PowerShell.TypeData
{
    public class Types : KeyedCollection<string, Type>
    {
        protected override string GetKeyForItem(Type item) => item.Name;

        public override string ToString() => ToXml().ToString();

        public XNode ToXml() => new XElement("Types", this.Select(t => t.ToXml()));
    }
}

#pragma warning restore 1591