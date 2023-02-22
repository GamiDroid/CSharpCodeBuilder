using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;

namespace CSharpCodeBuilder
{
    [Flags]
    public enum AccessModifier
    {
        None = 0,
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
            if (modifier == AccessModifier.None)
                return string.Empty;

            var strModifiers = new List<string>();

            modifier.DoWhenFlag(AccessModifier.Public, f => strModifiers.Add(GetName(f)));
            modifier.DoWhenFlag(AccessModifier.Private, f => strModifiers.Add(GetName(f)));
            modifier.DoWhenFlag(AccessModifier.Internal, f => strModifiers.Add(GetName(f)));
            modifier.DoWhenFlag(AccessModifier.Protected, f => strModifiers.Add(GetName(f)));
            modifier.DoWhenFlag(AccessModifier.Static, f => strModifiers.Add(GetName(f)));
            modifier.DoWhenFlag(AccessModifier.Abstract, f => strModifiers.Add(GetName(f)));

            return string.Join(" ", strModifiers);
        }

        private static void DoWhenFlag(this AccessModifier modifier, AccessModifier flag, Action<AccessModifier> action)
        {
            if (modifier.HasFlag(flag))
                action(flag);
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
