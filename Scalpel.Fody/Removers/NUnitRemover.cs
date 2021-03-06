﻿using System.Collections.Generic;
using System.Linq;
using Mono.Cecil;

class NUnitRemover : IRemover
{
    public IEnumerable<string> GetReferenceNames()
    {
        yield return "nunit.framework";
    }

    public IEnumerable<string> GetModuleAttributeNames()
    {
        yield break;
    }

    public IEnumerable<string> GetAssemblyAttributeNames()
    {
        yield break;
    }

    public bool ShouldRemoveType(TypeDefinition typeDefinition)
    {
        return typeDefinition.CustomAttributes.Any(IsNUnitAttribute);
    }

    static bool IsNUnitAttribute(CustomAttribute y)
    {
        return y.AttributeType.Scope.Name == "nunit.framework";
    }
}