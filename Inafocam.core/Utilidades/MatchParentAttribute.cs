using System;
using System.Collections.Generic;
using System.Text;

namespace Inafocam.core.Utilidades
{

    [AttributeUsage(AttributeTargets.Property)]
    public class MatchParentAttribute : Attribute
    {
        public readonly string ParentPropertyName;
        public MatchParentAttribute(string parentPropertyName)
        {
            ParentPropertyName = parentPropertyName;
        }
    }
}
