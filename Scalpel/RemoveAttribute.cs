using System;

namespace Scalpel;

/// <summary>
/// Also remove this type.
/// </summary>
[AttributeUsage(AttributeTargets.Class | AttributeTargets.Interface | AttributeTargets.Struct | AttributeTargets.Enum, Inherited = false)]
public class RemoveAttribute : Attribute
{
}