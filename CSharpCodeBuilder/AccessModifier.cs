using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;

namespace CSharpCodeBuilder
{
    [Flags]
    public enum AccessModifier
    {
        Public = 1,
        Private = 2,
        Internal = 4,
        Protected = 8,
        Static = 16,
        Sealed = 32,
        Abstract = 64,
    }

    public static class AccessModifiers
    {
        public static string ToSourceString(this AccessModifier modifier)
        {
            var strModifiers = new List<string>();
            foreach (var o in typeof(AccessModifier).GetEnumValues())
            {
                if (o is AccessModifier m)
                {
                    if (modifier.HasFlag(m))
                        strModifiers.Add(GetName(m));
                }
            }

            return string.Join(" ", strModifiers);
        }

        private static string GetName(AccessModifier modifier)
        {
            var fi = typeof(AccessModifier).GetField(modifier.ToString());
            var attr = fi.GetCustomAttribute<DescriptionAttribute>();
            if (attr is null)
                return modifier.ToString().ToLowerInvariant();
            return attr.Description;
        }
    }
}
