﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;

namespace CompilerCore.Enums
{
    public static class ExtensionMethods
    {
        public static string GetStringValue(this Enum value)
        {
            string stringValue = value.ToString();
            Type type = value.GetType();
            FieldInfo fieldInfo = type.GetField(value.ToString());
            StringValue[] attrs = fieldInfo.
                GetCustomAttributes(typeof(StringValue), false) as StringValue[];
            if (attrs.Length > 0)
            {
                stringValue = attrs[0].Value;
            }
            return stringValue;
        }
    }
}
